namespace Tank_Game
{
	partial class Game
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this._buttonResetMaze = new System.Windows.Forms.Button();
			this._buttonPause = new System.Windows.Forms.Button();
			this.pictureBoxGame = new System.Windows.Forms.PictureBox();
			this._labelLeftPlayerScore = new System.Windows.Forms.Label();
			this._labelRightPlayerTally = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 30;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// _buttonResetMaze
			// 
			this._buttonResetMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonResetMaze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._buttonResetMaze.Location = new System.Drawing.Point(795, 578);
			this._buttonResetMaze.Name = "_buttonResetMaze";
			this._buttonResetMaze.Size = new System.Drawing.Size(104, 32);
			this._buttonResetMaze.TabIndex = 3;
			this._buttonResetMaze.Text = "Reset Maze";
			this._buttonResetMaze.UseVisualStyleBackColor = true;
			this._buttonResetMaze.Click += new System.EventHandler(this.ButtonResetMaze_Click);
			// 
			// _buttonPause
			// 
			this._buttonPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this._buttonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._buttonPause.Location = new System.Drawing.Point(905, 578);
			this._buttonPause.Name = "_buttonPause";
			this._buttonPause.Size = new System.Drawing.Size(142, 32);
			this._buttonPause.TabIndex = 7;
			this._buttonPause.Text = "Pause Game";
			this._buttonPause.UseVisualStyleBackColor = true;
			this._buttonPause.Click += new System.EventHandler(this.ButtonPause_Click);
			// 
			// pictureBoxGame
			// 
			this.pictureBoxGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBoxGame.Location = new System.Drawing.Point(13, 14);
			this.pictureBoxGame.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pictureBoxGame.Name = "pictureBoxGame";
			this.pictureBoxGame.Size = new System.Drawing.Size(1033, 566);
			this.pictureBoxGame.TabIndex = 0;
			this.pictureBoxGame.TabStop = false;
			this.pictureBoxGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxGame_Paint);
			// 
			// _labelLeftPlayerScore
			// 
			this._labelLeftPlayerScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._labelLeftPlayerScore.AutoSize = true;
			this._labelLeftPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._labelLeftPlayerScore.Location = new System.Drawing.Point(12, 585);
			this._labelLeftPlayerScore.Name = "_labelLeftPlayerScore";
			this._labelLeftPlayerScore.Size = new System.Drawing.Size(208, 25);
			this._labelLeftPlayerScore.TabIndex = 8;
			this._labelLeftPlayerScore.Text = "Left Player Score: ";
			// 
			// _labelRightPlayerTally
			// 
			this._labelRightPlayerTally.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this._labelRightPlayerTally.AutoSize = true;
			this._labelRightPlayerTally.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._labelRightPlayerTally.Location = new System.Drawing.Point(388, 585);
			this._labelRightPlayerTally.Name = "_labelRightPlayerTally";
			this._labelRightPlayerTally.Size = new System.Drawing.Size(223, 25);
			this._labelRightPlayerTally.TabIndex = 9;
			this._labelRightPlayerTally.Text = "Right Player Score: ";
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1059, 614);
			this.Controls.Add(this._labelRightPlayerTally);
			this.Controls.Add(this._labelLeftPlayerScore);
			this.Controls.Add(this._buttonPause);
			this.Controls.Add(this._buttonResetMaze);
			this.Controls.Add(this.pictureBoxGame);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MinimumSize = new System.Drawing.Size(825, 511);
			this.Name = "Game";
			this.Text = "Game";
			this.SizeChanged += new System.EventHandler(this.GameDisplay_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameDisplay_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameDisplay_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxGame)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxGame;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button _buttonResetMaze;
		private System.Windows.Forms.Button _buttonPause;
		private System.Windows.Forms.Label _labelLeftPlayerScore;
		private System.Windows.Forms.Label _labelRightPlayerTally;
	}
}