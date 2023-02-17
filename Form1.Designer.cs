namespace Tank_Game
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
			this.button_Launch = new System.Windows.Forms.Button();
			this.buttonHowToPlay = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this._player1PictureBox = new System.Windows.Forms.PictureBox();
			this._player2PictureBox = new System.Windows.Forms.PictureBox();
			this.labelnotesChangeColor = new System.Windows.Forms.Label();
			this.labelPlayerOne = new System.Windows.Forms.Label();
			this.labelPlayer2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this._player1PictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._player2PictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// button_Launch
			// 
			this.button_Launch.Location = new System.Drawing.Point(87, 285);
			this.button_Launch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button_Launch.Name = "button_Launch";
			this.button_Launch.Size = new System.Drawing.Size(143, 32);
			this.button_Launch.TabIndex = 0;
			this.button_Launch.Text = "Start Game";
			this.button_Launch.UseVisualStyleBackColor = true;
			this.button_Launch.Click += new System.EventHandler(this.Button_Launch_Click);
			// 
			// buttonHowToPlay
			// 
			this.buttonHowToPlay.Location = new System.Drawing.Point(87, 240);
			this.buttonHowToPlay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.buttonHowToPlay.Name = "buttonHowToPlay";
			this.buttonHowToPlay.Size = new System.Drawing.Size(143, 32);
			this.buttonHowToPlay.TabIndex = 1;
			this.buttonHowToPlay.Text = "How To Play";
			this.buttonHowToPlay.UseVisualStyleBackColor = true;
			this.buttonHowToPlay.Click += new System.EventHandler(this.ButtonHowToPlay_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(72, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(158, 37);
			this.label1.TabIndex = 3;
			this.label1.Text = "Shoot Em";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// _player1PictureBox
			// 
			this._player1PictureBox.BackgroundImage = global::Tank_Game.Properties.Resources.tank_Blue_Oversized;
			this._player1PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this._player1PictureBox.Location = new System.Drawing.Point(2, 49);
			this._player1PictureBox.Name = "_player1PictureBox";
			this._player1PictureBox.Size = new System.Drawing.Size(147, 134);
			this._player1PictureBox.TabIndex = 4;
			this._player1PictureBox.TabStop = false;
			this._player1PictureBox.Click += new System.EventHandler(this.Player1PictureBox_Click);
			// 
			// _player2PictureBox
			// 
			this._player2PictureBox.BackgroundImage = global::Tank_Game.Properties.Resources.tank_Red;
			this._player2PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this._player2PictureBox.Location = new System.Drawing.Point(173, 49);
			this._player2PictureBox.Name = "_player2PictureBox";
			this._player2PictureBox.Size = new System.Drawing.Size(147, 134);
			this._player2PictureBox.TabIndex = 5;
			this._player2PictureBox.TabStop = false;
			this._player2PictureBox.Click += new System.EventHandler(this.Player2PictureBox_Click);
			// 
			// labelnotesChangeColor
			// 
			this.labelnotesChangeColor.AutoSize = true;
			this.labelnotesChangeColor.Location = new System.Drawing.Point(46, 177);
			this.labelnotesChangeColor.Name = "labelnotesChangeColor";
			this.labelnotesChangeColor.Size = new System.Drawing.Size(231, 20);
			this.labelnotesChangeColor.TabIndex = 6;
			this.labelnotesChangeColor.Text = "Click a Tank to change its color!";
			// 
			// labelPlayerOne
			// 
			this.labelPlayerOne.AutoSize = true;
			this.labelPlayerOne.Location = new System.Drawing.Point(35, 49);
			this.labelPlayerOne.Name = "labelPlayerOne";
			this.labelPlayerOne.Size = new System.Drawing.Size(84, 20);
			this.labelPlayerOne.TabIndex = 7;
			this.labelPlayerOne.Text = "Left Player";
			// 
			// labelPlayer2
			// 
			this.labelPlayer2.AutoSize = true;
			this.labelPlayer2.Location = new System.Drawing.Point(204, 49);
			this.labelPlayer2.Name = "labelPlayer2";
			this.labelPlayer2.Size = new System.Drawing.Size(94, 20);
			this.labelPlayer2.TabIndex = 8;
			this.labelPlayer2.Text = "Right Player";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.ClientSize = new System.Drawing.Size(327, 326);
			this.Controls.Add(this.labelPlayer2);
			this.Controls.Add(this.labelPlayerOne);
			this.Controls.Add(this.labelnotesChangeColor);
			this.Controls.Add(this._player2PictureBox);
			this.Controls.Add(this._player1PictureBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonHowToPlay);
			this.Controls.Add(this.button_Launch);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximumSize = new System.Drawing.Size(343, 365);
			this.MinimumSize = new System.Drawing.Size(343, 365);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Shoot Em";
			((System.ComponentModel.ISupportInitialize)(this._player1PictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._player2PictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_Launch;
		private System.Windows.Forms.Button buttonHowToPlay;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox _player1PictureBox;
		private System.Windows.Forms.PictureBox _player2PictureBox;
		private System.Windows.Forms.Label labelnotesChangeColor;
		private System.Windows.Forms.Label labelPlayerOne;
		private System.Windows.Forms.Label labelPlayer2;
	}
}

