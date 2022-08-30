using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace Arkose_maze_Solver
{
    public class ImageHelper
    {

        
        public Bitmap ImageCleanerANDFindTargets(Image img)
        {
            Bitmap btm = null;
            try
            {
                Bitmap imagem = new Bitmap(img);

                imagem = imagem.Clone(new Rectangle(0, 0, img.Width, img.Height), PixelFormat.Format24bppRgb);
                Invert inverter = new Invert();
                GaussianSharpen gsp = new GaussianSharpen(4, 11);
                EuclideanColorFiltering Eufilter = new EuclideanColorFiltering();
                Eufilter.CenterColor = new AForge.Imaging.RGB(200, 200, 200);
                Eufilter.Radius = 100;

                ConservativeSmoothing Cofilter = new ConservativeSmoothing();
                FiltersSequence seq = new FiltersSequence(inverter, gsp, Eufilter, Cofilter);
                btm = (Bitmap)seq.Apply(imagem);

                List<Point> pixels_loc = new List<Point>();

                for (int i = 0; i < imagem.Width; i++)
                {
                    for (int j = 0; j < imagem.Height; j++)
                    {
                        Color c = btm.GetPixel(i, j);
                        Color cOrg = imagem.GetPixel(i, j);
                        if (c.R > 50 && c.G > 50 && c.B > 50)  // turn all bright colors into white
                        {
                            btm.SetPixel(i, j, Color.White);
                        }
                        if (c.R <= 50 && c.G <= 50 && c.B <= 50) // turn all bright colors into arrows (The color of the walls is currently white, in line 59 the color of the walls will change to black) 
                        {
                            btm.SetPixel(i, j, Color.Black);
                        }
                        if (cOrg.R > 100 && cOrg.G > 100 && cOrg.B < 100) // add pixels of cheese colors to mark the list
                        {
                            pixels_loc.Add(new Point(i, j));
                        }
                        if (cOrg.R > 150 && cOrg.G > 150 && cOrg.B > 150) // add mouse (and cheese) pixels for marking in the list
                        {
                            pixels_loc.Add(new Point(i, j));
                        }
                    }
                }

                inverter.ApplyInPlace(btm); // Changing white and black colors to highlight the walls in black

                pixels_loc = pixels_loc.OrderBy(p => p.X).ThenBy(p => p.Y).ToList(); // Sort Pixels Location

                List<Point> pixels = new List<Point>(); // We have two targets, mouse and cheese. The variable < pixels_loc > contains the pixels of one target and the variable < pixels > contains the pixels of the second target.

                foreach (Point i in pixels_loc) // Mouse and cheese pixel separation loop
                {
                    if (pixels.Count == 0)
                    {
                        pixels.Add(i);
                        continue;
                    }
                    Point centerPoint = new Point
                    {
                        X = (int)Math.Round(pixels.Average(p => p.X)),
                        Y = (int)Math.Round(pixels.Average(p => p.Y))
                    };
                    if (Math.Abs(centerPoint.X - i.X) < 10 && Math.Abs(centerPoint.Y - i.Y) < 10)
                    {
                        pixels.Add(i);
                    }
                    else if (pixels.Count < 5)
                    {
                        pixels.Clear();
                    }

                }

                if (pixels.Count > 10) // If the second target is found
                {
                    pixels_loc = pixels_loc.Where(x => !pixels.Contains(x)).ToList(); // Remove the wrong pixels from the variable
                }

                List<Point> Temp = new List<Point>();
                Point centerpixelsPoint = new Point
                {
                    X = (int)Math.Round(pixels.Average(p => p.X)),
                    Y = (int)Math.Round(pixels.Average(p => p.Y))
                };
                Point avgTempPoint = new Point
                {
                    X = (int)Math.Round(pixels_loc.Average(p => p.X)),
                    Y = (int)Math.Round(pixels_loc.Average(p => p.Y))
                };

                List<Point> noise = new List<Point>(); // There may be some pixels in the image similar to mouse and cheese pixels, which are placed in this variable and finally deleted

                foreach (Point p in pixels_loc)
                {
                    if (Math.Sqrt(Math.Pow(p.X - avgTempPoint.X, 2) + Math.Pow(p.Y - avgTempPoint.Y, 2)) > 25)
                    {
                        if (Math.Sqrt(Math.Pow(p.X - centerpixelsPoint.X, 2) + Math.Pow(p.Y - centerpixelsPoint.Y, 2)) < 15)
                        {
                            Temp.Add(p);
                        }
                        else
                        {
                            noise.Add(p);
                        }
                    }
                    
                }
                pixels_loc = pixels_loc.Where(x => !Temp.Contains(x) && !noise.Contains(x)).ToList();// Remove the wrong pixels from the variable
                pixels.AddRange(Temp);// Add some pixels that were skipped
                Temp.Clear();

                if (pixels_loc.Count > 10)
                {
                    pixels_loc = clearnoise(pixels_loc);  // Removing pixels that are more than 15 pixels away from our target helps us find the center of the target image better

                    Point centerPoint = new Point
                    {
                        X = (int)Math.Round(pixels_loc.Average(p => p.X)),
                        Y = (int)Math.Round(pixels_loc.Average(p => p.Y))
                    };

                    int pensize = 5;
                    if (pixels_loc.Count > 75)
                    {
                        pensize = 7;
                    }
                    using (Graphics graphics = Graphics.FromImage(btm))
                    {
                        using (Pen pen = new Pen(Color.Red, pensize+1))
                        {
                            graphics.DrawRectangle(pen, centerPoint.X - (pensize / 2), centerPoint.Y - (pensize / 2), pensize, pensize);
                        }
                    }
                }


                if (pixels.Count > 10)
                {
                    pixels = clearnoise(pixels);// Removing pixels that are more than 15 pixels away from our target helps us find the center of the target image better

                    centerpixelsPoint = new Point
                    {
                        X = (int)Math.Round(pixels.Average(p => p.X)),
                        Y = (int)Math.Round(pixels.Average(p => p.Y))
                    };
                    int pensize = 5;
                    if (pixels.Count > 75)
                    {
                        pensize = 7;
                    }
                    using (Graphics graphics = Graphics.FromImage(btm))
                    {
                        using (Pen pen = new Pen(Color.Blue, pensize+1))
                        {
                            graphics.DrawRectangle(pen, centerpixelsPoint.X - (pensize / 2), centerpixelsPoint.Y - (pensize / 2), pensize, pensize);
                        }
                    }
                }

                

            }
            catch
            {
                return null;
            }

            return btm;
        }
        private List<Point> clearnoise(List<Point> lp)
        {
            List<Point> result = new List<Point>();
            Point centerPoint = new Point
            {
                X = (int)Math.Round(lp.Average(p => p.X)),
                Y = (int)Math.Round(lp.Average(p => p.Y))
            };
            foreach (Point p in lp)
            {
                if (Math.Sqrt(Math.Pow(p.X - centerPoint.X, 2) + Math.Pow(p.Y - centerPoint.Y, 2)) < 15) // Find pixels that are less than 15 pixels apart
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public List<Bitmap> cropImage(Bitmap img)
        {
            List<Bitmap> result = new List<Bitmap>();
            for (int x = 0; x < 300; x += 100)
            {
                for (int y = 0; y < 200; y += 100)
                {
                    Bitmap target = new Bitmap(100, 100);
                    using (Graphics g = Graphics.FromImage(target))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, target.Width, target.Height),
                                         new Rectangle(x, y, 100, 100),
                                         GraphicsUnit.Pixel);
                    }
                    result.Add(target);
                }
            }
            return result;
        }
        public Bitmap mergeImage(List<CropDetail> imgs, Bitmap orgImg, bool final = false)
        {
            Bitmap result = new Bitmap(300, 200);
            int counter = 0;
            for (int x = 0; x < 300; x += 100)
            {
                for (int y = 0; y < 200; y += 100)
                {

                    using (Graphics g = Graphics.FromImage(result))
                    {
                        if (imgs[counter].solve)
                        {
                            if (final)
                            {
                                g.DrawImage(orgImg, new Rectangle(x, y, 100, 100),
                                         new Rectangle(x, y, 100, 100),
                                         GraphicsUnit.Pixel);
                            }
                            else
                            {
                                g.DrawImage(imgs[counter].img, new Rectangle(x, y, 100, 100),
                                         new Rectangle(0, 0, 100, 100),
                                         GraphicsUnit.Pixel);
                            }

                        }
                        else
                        {
                            g.DrawImage(orgImg, new Rectangle(x, y, 100, 100),
                                         new Rectangle(x, y, 100, 100),
                                         GraphicsUnit.Pixel);
                            using (Pen pen = new Pen(Color.Red, 2))
                            {
                                g.DrawRectangle(pen, new Rectangle(x, y, 100, 100));
                            }
                        }
                        counter++;
                    }

                }
            }
            return result;
        }

    }
}
