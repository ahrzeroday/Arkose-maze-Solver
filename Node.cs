using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkose_maze_Solver
{
    public class Node
    {
        private Color pixel;
        private Node parent;
        private int X;
        private int Y;
        private bool visited;

        public Node(Node Parent, Color pixelColor, int x, int y, bool visited)
        {
            pixel = pixelColor;
            parent = Parent;
            X = x;
            Y = y;
            this.visited = visited;
        }
        public Color GetPixelColor()
        {
            return pixel;
        }
        public void SetPixelColor(Color PixelColor)
        {
            pixel = PixelColor;
        }
        public Node GetParent()
        {
            return parent;
        }
        public void SetParent(Node Parent)
        {
            parent = Parent;
        }
        public int GetX()
        {
            return X;
        }
        public void SetX(int x)
        {
            SetLocation(x, Y);
        }
        public int GetY()
        {
            return Y;
        }
        public void SetY(int y)
        {
            SetLocation(X, y);
        }
        public void SetLocation(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool isVisit()
        {
            return visited;
        }
        public void isSeen(bool visited)
        {
            this.visited = visited;
        }
    }
}
