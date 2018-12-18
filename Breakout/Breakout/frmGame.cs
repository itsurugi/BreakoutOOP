using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Breakout.Classes;

namespace Breakout
{
    public partial class frmGame : Form
    {
        Game game;
        PictureBox ball;
        PictureBox player1;
        PictureBox player2;
        public const int row = 5;
        public const int col = 10;
        PictureBox[,] gameblocks;

        public frmGame()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 600;
            game = new Game();
            DrawGameItems();
        }

        public void DrawGameItems()
        {
            DrawPaddles();
            DrawBall();
            DrawBlocks();
        }
        public void DrawPaddles()
        {     
            player1 = new PictureBox();
            player1.Height = game.Player1.Height;
            player1.Width = game.Player1.Width;
            player1.BackColor = game.Player1.Color;
            player1.Location = new Point(game.Player1.LocationX, game.Player1.LocationY);
            this.Controls.Add(player1);
            player2 = new PictureBox();
            player2.Height = game.Player2.Height;
            player2.Width = game.Player2.Width;
            player2.BackColor = game.Player2.Color;
            player2.Location = new Point(game.Player2.LocationX, game.Player2.LocationY);
            this.Controls.Add(player2);
        }
        public void DrawBall()
        {
            ball = new PictureBox();
            ball.Height = game.ball.Height;
            ball.Width = game.ball.Width;
            ball.BackColor = game.ball.Color;
            ball.Location = new Point(game.ball.LocationX, game.ball.LocationY);
            this.Controls.Add(ball);
        }

        public void DrawBlocks()
        {

            int i = 0;
            foreach (Block block in game.levelblocks)
            {
                i++;
                gameblocks = new PictureBox[row, col];
                for (int x = 0; x < row; x++)
                {
                    for (int y = 0; y < col; y++)
                    {
                        gameblocks[x, y] = new PictureBox();
                        gameblocks[x, y].Width = block.Width;
                        gameblocks[x, y].Height = block.Height;
                        gameblocks[x, y].Top = 100 + block.Height * x;
                        gameblocks[x, y].Left = 150 + block.Width * y;
                        gameblocks[x, y].BackColor = block.Color;
                        gameblocks[x, y].BorderStyle = BorderStyle.Fixed3D;
                        this.Controls.Add(gameblocks[x, y]);
                    }
                }
                
            }
        }

        private void tmMoveBall_Tick(object sender, EventArgs e)
        {
            ball.Top = game.ball.MoveHorizontal(ball);
            ball.Left = game.ball.MoveVertical(ball);



            if (ball.Bottom > this.ClientSize.Height || ball.Top < 0)
            {
                game.ball.ChangeDirectionVertical();
            }
            if (ball.Right > this.ClientSize.Width || ball.Left < 0)
            {
                game.ball.ChangeDirectionHorizontal();
            }

            if (ball.Bounds.IntersectsWith(player1.Bounds) == true || ball.Bounds.IntersectsWith(player2.Bounds))
            {
                game.ball.ChangeDirectionVertical();
            }
            for (int x = 0; x < row; x++)
            {
                for (int y = 0; y < col; y++)
                {
                    if (ball.Bounds.IntersectsWith(gameblocks[x, y].Bounds) && gameblocks[x, y].Visible == true)
                    {
                        gameblocks[x, y].Visible = false;
                        game.ball.ChangeDirectionVertical();
                    }
                }
            }
        }

        private void frmGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    game.Player1.MoveLeft(player1);
                    break;
                case Keys.Right:
                    game.Player1.MoveRight(player1);
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.A:
                    game.Player2.MoveLeft(player2);
                    break;
                case Keys.D:
                    game.Player2.MoveRight(player2);
                    break;
            }
        }

        
    }
}
