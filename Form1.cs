using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tank_Game
{
	/// <summary>
	/// Menu Form of the game
	/// </summary>
	public partial class Form1 : Form
	{    //###################################################
		#region Instance Variables

		/// <summary>
		/// Holds the Index of the colour the left player chooses in their respective picturebox.
		/// </summary>
		private int _leftPlayerColourIndex = 0;
		/// <summary>
		/// Holds the Index of the colour the right player chooses in their respective picturebox.
		/// </summary>
		private int _rightPlayerColourIndex = 4;
		/// <summary>
		/// The selected colour image the left player has chosen.
		/// </summary>
		private Image _leftPlayerSelectedColourImage;
		/// <summary>
		/// The selected colour image the right player has chosen.
		/// </summary>
		private Image _rightPlayerSelectedColourImage;

		#endregion
		//#######################################################################
		#region Constructor



		/// <summary>
		/// Initialises form, sets default images for players and pictureboxes.
		/// </summary>
		public Form1()
		{
			InitializeComponent();
			//update the player selected image and picturebox for each player.
			_leftPlayerSelectedColourImage = UpdateImages(_leftPlayerColourIndex, _player1PictureBox);
			_rightPlayerSelectedColourImage = UpdateImages(_rightPlayerColourIndex, _player2PictureBox);
		}



		#endregion
		//#######################################################################
		#region Private Methods


		/// <summary>
		/// Launches the game with the player Selected Images.
		/// </summary>=
		private void Button_Launch_Click(object sender, EventArgs e)
		{
			Form game = new Game(_leftPlayerSelectedColourImage, _rightPlayerSelectedColourImage);
			game.ShowDialog();
		}
		/// <summary>
		/// returns desired colour image from list using the index and updates picturebox
		/// </summary>
		/// <param name="index">the colour index the user has choses</param>
		/// <param name="pictureBox"> the picturebox changed to reflect the new colour</param>
		/// <returns>an Image of the selected colour to update the player image</returns>
		private Image UpdateImages(int index, PictureBox pictureBox)
		{ //create empty image to set to selected index
			Image tankImage;
			switch (index)
			{ /// give the colour associated with that index in this list
				case 0: tankImage = Properties.Resources.tank_Blue_Oversized; break;
				case 1: tankImage = Properties.Resources.tank_Red; break;
				case 2: tankImage = Properties.Resources.tank_Purple; break;
				case 3: tankImage = Properties.Resources.tank_Orange; break;
				case 4: tankImage = Properties.Resources.tank_Green; break;
				case 5: tankImage = Properties.Resources.tank_Yellow; break;
				case 6: tankImage = Properties.Resources.tank_Pink; break;
				case 7: tankImage = Properties.Resources.tank_Dark_Green2; break;
				default: tankImage = Properties.Resources.tank_LightBrown; break;
			}

			tankImage = (Image)(new Bitmap(tankImage, new Size(600, 600)));
			//Update the picturebox
			pictureBox.BackgroundImage = tankImage;
			//return selected colour image to update player.
			return tankImage;
		}
		/// <summary>
		/// Launches the how to play guide form
		/// </summary>
		private void ButtonHowToPlay_Click(object sender, EventArgs e)
		{   //create new guide and display
			Form guide = new Guide();
			guide.ShowDialog();
		}
		/// <summary>
		/// Update the Players Colour to the next available colour index
		/// </summary>
		private void Player1PictureBox_Click(object sender, EventArgs e)
		{
			_leftPlayerColourIndex++;
			//set it back to the start of the list if out of range.
			if (_leftPlayerColourIndex > 8)
			{
				_leftPlayerColourIndex = 0;
			} // go to the next colour if other player has already picked this colour.
			if (_rightPlayerColourIndex == _leftPlayerColourIndex)
			{
				_leftPlayerColourIndex++;
			}
			//set the players colour and picturebox to the new selected index in the list (in UpdateImages)
			_leftPlayerSelectedColourImage = UpdateImages(_leftPlayerColourIndex, _player1PictureBox);
		}

		/// <summary>
		/// Update the Players Colour to the next available colour index
		/// </summary>
		private void Player2PictureBox_Click(object sender, EventArgs e)
		{
			_rightPlayerColourIndex++;

			//set it back to the start of the list if out of range.
			if (_rightPlayerColourIndex > 8)
			{
				_rightPlayerColourIndex = 0;
			} // go to the next colour if other player has already picked this colour.
			if (_rightPlayerColourIndex == _leftPlayerColourIndex)
			{
				_rightPlayerColourIndex++;
			}
			//set the players colour and picturebox to the new selected index in the list (in UpdateImages)
			_rightPlayerSelectedColourImage = UpdateImages(_rightPlayerColourIndex, _player2PictureBox);
		}
		#endregion

		//end of form class
	}
}
