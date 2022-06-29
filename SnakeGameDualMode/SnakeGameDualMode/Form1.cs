using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Imaging; // add this for the JPG compressor
using SnakeGameDualMode;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private List<Circle> SnakeTwo = new List<Circle>();

        private List<Snakes> players = new List<Snakes>();

        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score, score2nd;
        int highScore;

        Random rand = new Random();
        bool dualMode = false;
        bool draw = false;

        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && players[0].directions != "right") 
            {
                players[0].goLeft = true;
            }
            if (e.KeyCode == Keys.Right && players[0].directions != "left")
            {
                players[0].goRight = true;
            }
            if (e.KeyCode == Keys.Up && players[0].directions != "down")
            {
                players[0].goUp = true;
            }
            if (e.KeyCode == Keys.Down && players[0].directions != "up")
            {
                players[0].goDown = true;
            }

            // second snake
            if (e.KeyCode == Keys.A && players[1].directions != "right")
            {
                players[1].goLeft = true;
            }
            if (e.KeyCode == Keys.D && players[1].directions != "left")
            {
                players[1].goRight = true;
            }
            if (e.KeyCode == Keys.W && players[1].directions != "down")
            {
                players[1].goUp = true;
            }
            if (e.KeyCode == Keys.S && players[1].directions != "up")
            {
                players[1].goDown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                players[0].goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                players[0].goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                players[0].goUp = false;
            }
            if (e.KeyCode == Keys.Down )
            {
                players[0].goDown = false;
            }

            // second snake
            if (e.KeyCode == Keys.A)
            {
                players[1].goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                players[1].goRight = false;
            }
            if (e.KeyCode == Keys.W)
            {
                players[1].goUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                players[1].goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            dualMode = false;
            players.Clear();
            players.Add(new Snakes(Snake, "left", false, false, false, false, Brushes.Black, Brushes.DarkGreen));
            RestartGame();
        }

        private void Start2Players(object sender, EventArgs e)
        {
            dualMode = true;
            players.Clear();
            players.Add(new Snakes(Snake, "left", false, false, false, false, Brushes.Black, Brushes.DarkGreen));
            players.Add(new Snakes(SnakeTwo, "left", false, false, false, false, Brushes.Black, Brushes.DarkBlue));
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label();

            if (!dualMode) 
            {
                caption.Text = "I scored: " + score + " and my Highscore is " + highScore;
                caption.Font = new Font("Ariel", 12, FontStyle.Bold);
                caption.ForeColor = Color.Red;
                caption.AutoSize = false;
                caption.Width = picCanvas.Width;
                caption.Height = 30;
                caption.TextAlign = ContentAlignment.MiddleCenter;
                picCanvas.Controls.Add(caption);
            }
            else
            {
                caption.Text = "Player one scored: " + score + ", Player two scored: " + score2nd + ", and my Highscore is " + highScore;
                caption.Font = new Font("Ariel", 12, FontStyle.Bold);
                caption.ForeColor = Color.Red;
                caption.AutoSize = false;
                caption.Width = picCanvas.Width;
                caption.Height = 30;
                caption.TextAlign = ContentAlignment.MiddleCenter;
                picCanvas.Controls.Add(caption);
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "Snake Game SnapShot";
            dialog.DefaultExt = "jpg";
            dialog.Filter = "JPG Image File | *.jpg";
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = Convert.ToInt32(picCanvas.Width);
                int height = Convert.ToInt32(picCanvas.Height);

                Bitmap bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Add(caption);
            }
        }

        private void GameTimeEvent(object sender, EventArgs e)
        {
            // setting the directions
            foreach (Snakes player in players)
            {
                if (player.goLeft)
                {
                    player.directions = "left";
                }
                if (player.goRight)
                {
                    player.directions = "right";
                }
                if (player.goDown)
                {
                    player.directions = "down";
                }
                if (player.goUp)
                {
                    player.directions = "up";
                }
            }

            // events
            foreach (Snakes player in players)
            {
                for (int i = player.snake.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        switch (player.directions)
                        {
                            case "left":
                                player.snake[i].X--;
                                break;
                            case "right":
                                player.snake[i].X++;
                                break;
                            case "down":
                                player.snake[i].Y++;
                                break;
                            case "up":
                                player.snake[i].Y--;
                                break;
                        }

                        WalkingThroughWalls(player, i); // behavior when the snake hits the border

                        // eating food
                        if (player.snake[i].X == food.X && player.snake[i].Y == food.Y)
                        {
                            EatFood(player.snake);
                        }

                        Suicide(player, i); // behavior when the snake eats itself
                    }
                    else
                    {
                        player.snake[i].X = player.snake[i - 1].X;
                        player.snake[i].Y = player.snake[i - 1].Y;
                    }

                    if (dualMode)
                    {
                        Collision(players); // behavior when the snake hits other snake
                    }
                }
            }
                
            picCanvas.Invalidate();
        }
        private void Suicide(Snakes player, int i)
        {
            for (int j = 1; j < player.snake.Count; j++)
            {
                if (player.snake[i].X == player.snake[j].X && player.snake[i].Y == player.snake[j].Y)
                {
                    GameOver();
                }
            }
        }
        private void WalkingThroughWalls(Snakes player, int i)
        {
            if (player.snake[i].X < 0)
            {
                player.snake[i].X = maxWidth;
            }
            if (player.snake[i].X > maxWidth)
            {
                player.snake[i].X = 0;
            }
            if (player.snake[i].Y < 0)
            {
                player.snake[i].Y = maxHeight;
            }
            if (player.snake[i].Y > maxHeight)
            {
                player.snake[i].Y = 0;
            }
        }
        private void Collision(List<Snakes> players)
        {
            for (int j = 1; j < players[0].snake.Count; j++)
            {
                for (int k = 1; k < players[1].snake.Count; k++)
                {
                    // draw
                    if (players[1].snake[0].X == players[0].snake[0].X && players[1].snake[0].Y == players[0].snake[0].Y)
                    {
                        draw = true;
                        GameOver();
                    }
                    // player 1 lose
                    if (players[0].snake[0].X == players[1].snake[k].X && players[0].snake[0].Y == players[1].snake[k].Y)
                    {
                        GameOver(player1Won: false);
                    }
                    // player 2 lose
                    if (players[1].snake[0].X == players[0].snake[j].X && players[1].snake[0].Y == players[0].snake[j].Y)
                    {
                        GameOver(player1Won: true);
                    }
                }
            }
        }
        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColour;
            foreach (Snakes dup in players)
            {
                
                for (int i = 0; i < dup.snake.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColour = dup.head;
                    }
                    else
                    {
                        snakeColour = dup.body;
                    }
                    canvas.FillEllipse(snakeColour, new Rectangle
                        (
                        dup.snake[i].X * Settings.Width,
                        dup.snake[i].Y * Settings.Height,
                        Settings.Width, Settings.Height
                        ));
                }
            }           

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                    (
                    food.X * Settings.Width,
                    food.Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));

        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            Snake.Clear();
            SnakeTwo.Clear();
            draw = false;

            startButton.Enabled = false;
            start2PlayersButton.Enabled = false;
            snapButton.Enabled = false;
            score = 0;
            score2nd = 0;
            txtScore.Text = "Score: " + score;
            txtScore2ndPlayer.Text = "----";
            txtWinDualMode.Text = "----";

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);    // adding the head part of the snake to the list

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            // adding the second snake
            if (dualMode)
            {
                head = new Circle { X = 40, Y = 35 };
                SnakeTwo.Add(head);    // adding the head part of the snake to the list

                for (int i = 0; i < 10; i++)
                {
                    Circle body = new Circle();
                    SnakeTwo.Add(body);

                    txtScore.Text = "1st player score: " + score;
                    txtScore2ndPlayer.Text = "2st player score: " + score;
                }
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimer.Start();
        }

        private void EatFood(List<Circle> snake)
        {
            if(snake == Snake)
            {
                score += 1;
                txtScore.Text = "1st player score: " + score;
            }
            else
            {
                score2nd += 1;
                txtScore2ndPlayer.Text = "2st player score: " + score2nd;
            }
            
            Circle body = new Circle
            { 
                X = snake[snake.Count - 1].X,
                Y = snake[snake.Count - 1].Y
            };

            snake.Add(body);

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        private void GameOver(bool player1Won = false)
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            start2PlayersButton.Enabled = true;
            snapButton.Enabled = true;

            if (score > highScore && !dualMode)
            {
                highScore = score;

                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
            else if (draw)
            {
                txtWinDualMode.Text = "DRAW!";

                if (score > score2nd && score > highScore)
                {
                    highScore = score;
                    txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                    txtHighScore.ForeColor = Color.Maroon;
                    txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                }
                else if (score2nd > score && score2nd > highScore)
                {
                    highScore = score2nd;
                    txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                    txtHighScore.ForeColor = Color.Maroon;
                    txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
            else if (dualMode && player1Won && !draw)
            {
                txtWinDualMode.Text = "Player 1 won!";

                if (score > score2nd && score > highScore)
                {
                    highScore = score;
                    txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                    txtHighScore.ForeColor = Color.Maroon;
                    txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                }
            }
            else if (dualMode && !player1Won && !draw)
            {
                txtWinDualMode.Text = "Player 2 won!";

                if (score2nd > score && score2nd > highScore)
                {
                    highScore = score2nd;
                    txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                    txtHighScore.ForeColor = Color.Maroon;
                    txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
                }
            }

        }  
    }
}
