using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkose_maze_Solver
{
    public class CropDetail
    {
        public Bitmap img { set; get; }
        public bool solve { set; get; }
        public CropDetail(Bitmap img, bool solve)
        {
            this.img = img;
            this.solve = solve;
        }
    }
}
