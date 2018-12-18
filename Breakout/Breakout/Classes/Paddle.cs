using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Classes
{
    public class Paddle
    {
        public int Width { get; set; }
        public int Height { get; }
        public int LocationY { get; set; }
        public int LocationX { get; set; }
        public int Speed { get; set; }
        public Color Color { get; set; }

        public Paddle(int width, int locationy, int locationx, Color color)
        {
            this.Width = width;
            this.Height = 25;
            this.LocationY = locationy;
            this.LocationX = locationx;
            this.Speed = 5;
            this.Color = color;

        }

        public int MoveLeft(PictureBox paddle)
        {
            int location = 0;

            paddle.Left -= Speed;
            location = paddle.Left;

            return location;
        }
        public int MoveRight(PictureBox paddle)
        {
            int location = 0;

            paddle.Left += Speed;
            location = paddle.Left;

            return location;
        }

    }
}
