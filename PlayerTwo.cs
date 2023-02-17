using System.Drawing;
using System.Windows.Forms;
namespace Tank_Game
{
	internal class PlayerTwo : Tank
	{
		//Calls the base constructer tank class with the corresponding values.
		//Inherits ALL Behaviour from tank class,
		// Only difference is the different player classes have different Keys used for their controls
		// that move their respective tanks.
		public PlayerTwo(Maze maze, Image image) : base(maze, image)
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
				case Keys.I:
					Movement = 3;
					break;
				case Keys.K:
					Movement = -3;
					break;
				case Keys.J:
					Turn = -4;
					break;
				case Keys.L:
					Turn = 4;
					break;
				case Keys.P:
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
				case Keys.I:
					Movement = 0;
					break;
				case Keys.K:
					Movement = 0;
					break;
				case Keys.J:
					Turn = 0;
					break;
				case Keys.L:
					Turn = 0;
					break;
				case Keys.P:
					//SHOOT
					Shooting = false;
					break;
				default:
					break;
			}

			#endregion
		}
	}
}
