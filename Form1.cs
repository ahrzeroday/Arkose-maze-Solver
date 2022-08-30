using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Arkose_maze_Solver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "PNG File |*.png" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    orgimg.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color start = Color.Red;
            Color end = Color.Blue;
            Color wall = Color.Black;
            Color path = Color.Orange;
            Stopwatch time = new Stopwatch();

            ImageHelper imgHelper = new ImageHelper();

            Bitmap orgimage = new Bitmap(orgimg.Image);

            List<Bitmap> croped = imgHelper.cropImage(orgimage);// Divide the image into 6 pieces

            List<CropDetail> Solved = new List<CropDetail>();

            time.Start();
            foreach (Bitmap img in croped)
            {
                Bitmap newImg = null;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    newImg = new Bitmap(ms);
                }

                Bitmap cleanimg = imgHelper.ImageCleanerANDFindTargets(newImg);
                if (cleanimg == null)
                {
                   
                    MessageBox.Show("There is a problem with the photo");
                    return;
                }

                MazeSolver msolver = new MazeSolver(cleanimg, start, end, wall, path);


                Solved.Add(msolver.SolveMaze());
            }
            time.Stop();
            TimeLabel.Text = string.Format("{0}.{1}",time.Elapsed.Seconds,time.Elapsed.Milliseconds) + " Seconds";
            solveimg.Image = imgHelper.mergeImage(Solved, orgimage, false);
            finalimg.Image = imgHelper.mergeImage(Solved, orgimage, true);
           
        }
    }
}
