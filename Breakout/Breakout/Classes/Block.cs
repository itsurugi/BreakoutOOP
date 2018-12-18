using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakout.Classes
{
    public class Block
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Color Color { get; set; }
        public Block()
        {
            this.Height = 30;
            this.Width = 50;
            this.Color = Color.Red;
        }

        
    }
}
