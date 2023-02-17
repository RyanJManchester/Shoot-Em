using System.Drawing;
using System.Windows.Forms;

namespace Tank_Game
{
	internal class LeftPlayer : Tank
	{
		//Creates a New Tank with LeftPlayer  WASD Controls.
		public LeftPlayer(Maze maze, Image image) : base(maze, image)
		{
		}
		#region Key Inputs for Movement
		/// <summary>
		/// Starts any movement on key Down
		/// by setting the tank superclass corresponding value.
		/// </summary>
		/// <param name="e"> the KeyDown KeyEventArgs of any controls.</param>

		public override void StartMovement(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					Movement = 3;
					break;
				case Keys.S:
					Movement = -3;
					break;
				case Keys.A:
					Turn = -4;
					break;
				case Keys.D:
					Turn = 4;
					break;
				case Keys.Q:
					//SHOOT
					Shooting = true;
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Cancels any movement given from the inputted key  on key UP
		/// by setting the tank superclass corresponding valuo to 0 - NOT moving..
		/// </summary>
		/// <param name="e"> the Up key event of any controls.</param>
		public override void StopMovement(KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.W:
					Movement = 0;
					break;
				case Keys.S:
					Movement = 0;
					break;
				case Keys.A:
					Turn = 0;
					break;
				case Keys.D:
					Turn = 0;
					break;
				case Keys.Q:
					//Shoot
					Shooting = false;
					break;
				default:
					break;
			}
		}
		#endregion
	}
}
