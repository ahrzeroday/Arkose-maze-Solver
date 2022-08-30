using System.Collections.Generic;
using System.Drawing;

namespace Arkose_maze_Solver
{
    public class MazeSolver
    {

        #region Variables   
        private Color StartColor;
        private Color FinishColor;
        private Color WallColor;
        private Color PathColor;
        private Bitmap mazeimg;
        private Node[,] Nodes;
        private Queue<Node> StartNodes;
        #endregion   // All Variables we need in this class

        public MazeSolver(Bitmap mazeImage, Color start, Color finish, Color wall, Color path)
        {
            mazeimg = mazeImage;
            StartColor = start;
            FinishColor = finish;
            WallColor = wall;
            PathColor = path;
            Nodes = new Node[mazeimg.Width, mazeimg.Height];
            StartNodes = new Queue<Node>();
        }

        public CropDetail SolveMaze()
        {

            for (int i = 0; i < mazeimg.Width; i++)// Find Start Color Pixels and add all other pixels to Nodes Queue
            {
                for (int j = 0; j < mazeimg.Height; j++)
                {
                    Color pixel = mazeimg.GetPixel(i, j);
                    Nodes[i, j] = new Node(null, pixel, i, j, false);
                    if (pixel.ToArgb().Equals(StartColor.ToArgb()))
                    {

                        StartNodes.Enqueue(new Node(null, pixel, i, j, true));

                    }

                }
            }

            if (StartNodes.Count == 0)
            {
                return new CropDetail(mazeimg, false);
            }

            Node finishNode = BFSSolver(); // Maze solution using Breadth-first search algorithm
            if (finishNode == null)
            {
                return new CropDetail(mazeimg, false);
            }
            using (Graphics graphics = Graphics.FromImage(mazeimg))
            {
                while (finishNode != null) // Create Path Color
                {
                    using (Pen pen = new Pen(PathColor, 1))
                    {
                        graphics.DrawRectangle(pen, finishNode.GetX(), finishNode.GetY(), 1, 1);
                    }
                    finishNode = finishNode.GetParent();
                }
               
            }
           

            return new CropDetail(mazeimg, true);
        }
        public Node BFSSolver()
        {
            Queue<Node> nodeQueue = new Queue<Node>();

            while (StartNodes.Count != 0)
            {
                nodeQueue.Enqueue(StartNodes.Dequeue());

                Node current;
                while (nodeQueue.Count != 0)
                {
                    current = nodeQueue.Dequeue();
                    Color nowColor = mazeimg.GetPixel(current.GetX(), current.GetY());
                    if (nowColor.ToArgb().Equals(WallColor.ToArgb())) // Skip Walls
                    {
                        continue;
                    }

                    if (nowColor.ToArgb().Equals(FinishColor.ToArgb())) // if Find FinishColor then we solved maze and return Node for create Path color
                    {
                        return current;
                    }

                    if (current.GetY() - 1 >= 0 && !Nodes[current.GetX(), current.GetY() - 1].isVisit())
                    {
                        Nodes[current.GetX(), current.GetY() - 1].isSeen(true);
                        Nodes[current.GetX(), current.GetY() - 1].SetParent(current);
                        nodeQueue.Enqueue(Nodes[current.GetX(), current.GetY() - 1]);
                    }
                    if (current.GetY() + 1 < mazeimg.Height && !Nodes[current.GetX(), current.GetY() + 1].isVisit())
                    {
                        Nodes[current.GetX(), current.GetY() + 1].isSeen(true);
                        Nodes[current.GetX(), current.GetY() + 1].SetParent(current);
                        nodeQueue.Enqueue(Nodes[current.GetX(), current.GetY() + 1]);
                    }

                    if (current.GetX() - 1 >= 0 && !Nodes[current.GetX() - 1, current.GetY()].isVisit())
                    {
                        Nodes[current.GetX() - 1, current.GetY()].isSeen(true);
                        Nodes[current.GetX() - 1, current.GetY()].SetParent(current);
                        nodeQueue.Enqueue(Nodes[current.GetX() - 1, current.GetY()]);
                    }

                    if (current.GetX() + 1 < mazeimg.Width && !Nodes[current.GetX() + 1, current.GetY()].isVisit())
                    {
                        Nodes[current.GetX() + 1, current.GetY()].isSeen(true);
                        Nodes[current.GetX() + 1, current.GetY()].SetParent(current);
                        nodeQueue.Enqueue(Nodes[current.GetX() + 1, current.GetY()]);
                    }
                }
            }

            return null;
        }




    }
}
