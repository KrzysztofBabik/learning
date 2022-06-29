
namespace SnakeGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.snapButton = new System.Windows.Forms.Button();
            this.txtScore = new System.Windows.Forms.Label();
            this.txtHighScore = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.txtScore2ndPlayer = new System.Windows.Forms.Label();
            this.start2PlayersButton = new System.Windows.Forms.Button();
            this.txtWinDualMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(580, 680);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.startButton.Location = new System.Drawing.Point(623, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(113, 64);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartGame);
            // 
            // snapButton
            // 
            this.snapButton.BackColor = System.Drawing.Color.DarkTurquoise;
            this.snapButton.Location = new System.Drawing.Point(623, 187);
            this.snapButton.Name = "snapButton";
            this.snapButton.Size = new System.Drawing.Size(113, 64);
            this.snapButton.TabIndex = 4;
            this.snapButton.Text = "Snap";
            this.snapButton.UseVisualStyleBackColor = false;
            this.snapButton.Click += new System.EventHandler(this.TakeSnapShot);
            // 
            // txtScore
            // 
            this.txtScore.AutoSize = true;
            this.txtScore.Location = new System.Drawing.Point(620, 293);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(47, 13);
            this.txtScore.TabIndex = 5;
            this.txtScore.Text = "Score: 0";
            // 
            // txtHighScore
            // 
            this.txtHighScore.AutoSize = true;
            this.txtHighScore.Location = new System.Drawing.Point(620, 343);
            this.txtHighScore.Name = "txtHighScore";
            this.txtHighScore.Size = new System.Drawing.Size(61, 13);
            this.txtHighScore.TabIndex = 6;
            this.txtHighScore.Text = "High score:";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 40;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimeEvent);
            // 
            // txtScore2ndPlayer
            // 
            this.txtScore2ndPlayer.AutoSize = true;
            this.txtScore2ndPlayer.Location = new System.Drawing.Point(620, 319);
            this.txtScore2ndPlayer.Name = "txtScore2ndPlayer";
            this.txtScore2ndPlayer.Size = new System.Drawing.Size(19, 13);
            this.txtScore2ndPlayer.TabIndex = 7;
            this.txtScore2ndPlayer.Text = "----";
            // 
            // start2PlayersButton
            // 
            this.start2PlayersButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.start2PlayersButton.Location = new System.Drawing.Point(623, 82);
            this.start2PlayersButton.Name = "start2PlayersButton";
            this.start2PlayersButton.Size = new System.Drawing.Size(113, 64);
            this.start2PlayersButton.TabIndex = 8;
            this.start2PlayersButton.Text = "Start multiplayer";
            this.start2PlayersButton.UseVisualStyleBackColor = false;
            this.start2PlayersButton.Click += new System.EventHandler(this.Start2Players);
            // 
            // txtWinDualMode
            // 
            this.txtWinDualMode.AutoSize = true;
            this.txtWinDualMode.Location = new System.Drawing.Point(620, 379);
            this.txtWinDualMode.Name = "txtWinDualMode";
            this.txtWinDualMode.Size = new System.Drawing.Size(19, 13);
            this.txtWinDualMode.TabIndex = 9;
            this.txtWinDualMode.Text = "----";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 725);
            this.Controls.Add(this.txtWinDualMode);
            this.Controls.Add(this.start2PlayersButton);
            this.Controls.Add(this.txtScore2ndPlayer);
            this.Controls.Add(this.txtHighScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.snapButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.picCanvas);
            this.Name = "Form1";
            this.Text = "SnakeGame";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button snapButton;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label txtHighScore;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label txtScore2ndPlayer;
        private System.Windows.Forms.Button start2PlayersButton;
        private System.Windows.Forms.Label txtWinDualMode;
    }
}

