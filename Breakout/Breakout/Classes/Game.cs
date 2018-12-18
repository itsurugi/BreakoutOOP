using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Breakout.Classes
{
    public class Game
    {
        public Paddle Player1 { get; set; }
        public Paddle Player2 { get; set; }
        public Ball ball { get; set; }
        public List<Block> levelblocks = new List<Block>();
        public Game()
        {
            Player1 = new Paddle(100, 480, 375, Color.Black);
            Player2 = new Paddle(800, 0, 0, Color.Blue);
            ball = new Ball();
            
            for (int i = 0; i < 50; i++)
            {
                Block block = new Block();
                levelblocks.Add(block);
            }
        }

        
    }
}
