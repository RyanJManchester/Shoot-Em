using System.Drawing;

namespace Tank_Game
{
	public class Bullet : Sprite
	{

		//##############################################
		#region Instance Variables

		/// <summary>
		/// _the horozintal velocity the bullet is travelling in.
		/// </summary>
		private float _xVelocity;
		/// <summary>
		/// _the vertival velocity the bullet is travelling in.
		/// </summary>
		private float _yVelocity;
		/// <summary>
		/// _countdown is the time the bullet lasts for in the game.  
		/// Is often set to zero as a way to finish the bullet if it collides with a tank.
		/// </summary>
		private int _countdown;

		#endregion
		//##############################################
		#region Constructors
		/// <summary>
		/// Creates a new Bullet
		/// </summary>
		/// <param name="xPosition"> the starting X location</param>
		/// <param name="yPosition">the starting Y location</param>
		/// <param name="maze">the maze the bullet lives in.</param>
		/// <param name="xVelocity">the horziontal velocity of the bullet</param>
		/// <param name="yVelocity">the vertical velocity of the bullet</param>
		/// <param name="tank">The Tank that created the bullet</param>
		public Bullet(float xPosition, float yPosition, Maze maze, double xVelocity, double yVelocity, Tank tank) :
			// + 16 on both x and y positions sets the bullet start point to the center of the tank.
			base(maze, (int)xPosition + 16, (int)yPosition + 16, 8, 8)
		{
			_xVelocity = (float)xVelocity;
			_yVelocity = (float)yVelocity;
			//Move start position outside of tank so you dont hit yourself
			while (tank.CollidedWith(this.BoundingBox))
			{  //move bullet in given direction until outside turret.
				X += _xVelocity;
				Y += _yVelocity;
			}
			//If closest starting position is inside a wall, tank has to be dead.
			//Bullet is never drawn or started unless countdown is set above zero.
			if (Maze.TouchesWall(BoundingBox))
			{
				tank.IsDead = true;

			}
			else
			{ //initiate time left (start bullet)
				_countdown = 150;
			}

		}
		#endregion
		//##############################################
		#region Propertys


		/// <summary>
		/// Gets / sets whether the bullet has finished or not so it can be deleted.
		/// </summary>
		public bool Finished
		{
			get
			{
				if (_countdown == 0)
				{
					return true;
				}
				else return false;
			}
			set { _countdown = 0; }
		}
		#endregion
		//##############################################
		#region Public Methods



		/// <summary>
		/// Draws the bullet in its current location
		/// </summary>
		/// <param name="paper">the garphics object the bullet is to be drawn on.</param>
		public override void Draw(Graphics paper)
		{ //if not finished then draw.
			if (_countdown > 0)
			{
				paper.FillEllipse(new SolidBrush(Color.Black), BoundingBox);
			}
		}

		/// <summary>
		/// Moves Bullet, Checking each time if the bullet is in a wall.
		/// the speed of the bullet is increased by changing the for loop count.
		/// </summary>
		public override void Move()
		{
			//If NOT Timed out/ finished 
			if (_countdown > 0)
			{
				///This for loop is needed so that you can increase the speed by increasing the iterations,
				/// and you cant be in more than one of the generated maze rectangles at once because the 
				/// velocitys will always be less than 1.
				for (int i = 0; i < 6; i++)
				{
					//set a new hypothetical X position with the adjusted X value
					RectangleF newXPosition = BoundingBox;
					newXPosition.X += _xVelocity;
					//if new position IS not in wall, move to new position
					if (!Maze.TouchesWall(newXPosition))
					{ //set the current position to the new position since valid.
						X += _xVelocity;
					}
					else
					{  //if there is a collision, reverse the X Velocity
						_xVelocity = -_xVelocity;
					}
					//set a new hypothetical Y position with the adjusted Y value
					RectangleF newYPosition = BoundingBox;
					newYPosition.Y += _yVelocity;
					//if new position IS not in wall, move to new position
					if (!Maze.TouchesWall(newYPosition))
					{   //if there is a collision, reverse the Y velocity
						Y += _yVelocity;
					}
					else { _yVelocity = -_yVelocity; }
				}
			}
			//reduce the time left since it has attempted to move.
			_countdown--;
		}


		#endregion
		//##############################################
		//end of class
	}
}