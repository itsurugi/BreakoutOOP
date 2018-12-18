using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout.Classes
{
    public class Ball
    {
        public int Width { get; set; }
        public int Height { get; }
        public int LocationY { get; set; }
        public int LocationX { get; set; }
        public int hSpeed { get; set; }
        public int vSpeed { get; set; }
        public Color Color { get; set; }

        public Ball()
        {
            this.Width = 25;
            this.Height = 25;
            this.LocationY = 250;
            this.LocationX = 400;
            this.hSpeed = 5;
            this.vSpeed = 5;
            this.Color = Color.Yellow;
        }

        public int MoveHorizontal(PictureBox ball)
        {
            int hBallPosition = 0;

            ball.Top += vSpeed;
            hBallPosition = ball.Top;

            return hBallPosition;
        }

        public int MoveVertical(PictureBox ball)
        {
            int vBallPosition = 0;
            ball.Left += hSpeed;
            vBallPosition = ball.Left;

            return vBallPosition;
        }

        public void ChangeDirectionHorizontal()
        {
            hSpeed = -hSpeed;
        }

        public void ChangeDirectionVertical()
        {
            vSpeed = -vSpeed;
        }
    }
}
