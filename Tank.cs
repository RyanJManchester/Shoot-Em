using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tank_Game
{
	public abstract class Tank : Sprite
	{
		//##########################################################
		#region Instance Variables


		/// <summary>
		/// the Enemy Tank to check its not using the same space
		/// </summary>
		private Tank _enemy;
		/// <summary>
		/// The tank image (with colour) chosen by the user.
		/// also used to maintain quality of image.
		/// </summary>
		private Image _tankImage;
		/// <summary>
		/// If the tank is currently rotating or not, negative if left, right positive.
		/// </summary>
		private int _turnMovement = 0;
		/// <summary>
		/// Movement backwards or forwards for the tank. - back, + forward.
		/// </summary>
		private int _movement = 0;
		/// <summary>
		/// the current rotation in degrees clockwise from north.
		/// </summary>
		private int _rotation = 0;
		/// <summary>
		/// The amount of rounds this tank / player has won in this game.
		/// </summary>
		private int _roundsWon = 0;
		/// <summary>
		/// if the tank / player is currently trying to shoot or not.
		/// </summary>
		private bool _shooting = false;
		/// <summary>
		/// the total bullet count this tank has on the screen.
		/// </summary>
		private int _bulletCount = 0;
		/// <summary>
		/// If this tank is dead / has been hit or not.
		/// </summary>
		private bool _dead = false;
		/// <summary>
		/// The time left before the tank can shoot again (styling)
		/// </summary>
		private int _bulletCoolDown = 0;


		#endregion
		//##########################################################
		#region Constructor


		/// <summary>
		/// Creates tank images references and calls base class sprite constructor.
		/// </summary>
		/// <param name="maze">The current maze</param>
		/// <param name="image"> selected tank colour / image</param>
		public Tank(Maze maze, Image image) :
			base(maze, 0, 0, 40, 40)
		{
			//set tank image
			_tankImage = image;
		}
		#endregion
		//##########################################################
		#region Propertys



		/// <summary>
		/// The amount of  rounds this tank has won.
		/// </summary>
		public int RoundsWon
		{
			get { return _roundsWon; }
			set { _roundsWon = value; }
		}
		/// <summary>
		/// The Cooldown period left before it can shoot again.
		/// </summary>
		public int BulletCoolDown
		{
			get { return _bulletCoolDown; }
			set
			{
				_bulletCoolDown = value;
			}
		}
		/// <summary>
		/// if the tank is currently Turning.
		/// left is negative, right positive, 0 not turning.
		/// </summary>
		public int Turn
		{
			get { return _turnMovement; }
			set { _turnMovement = value; }
		}
		/// <summary>
		/// the current rotation angle from north clockwise.
		/// </summary>
		public int Rotation
		{
			get { return _rotation; }
			set { _rotation = value; }
		}
		/// <summary>
		/// If the Tank is Moving Back or Forward. negative for backward,
		/// positive for forward, zero for not moving.
		/// </summary>
		public int Movement
		{
			get { return _movement; }
			set { _movement = value; }
		}
		/// <summary>
		/// If the tank is currently Trying to Shoot or not.
		/// </summary>
		public bool Shooting
		{
			get { return _shooting; }
			set
			{
				_shooting = value;
			}
		}
		/// <summary>
		/// The current amount of bullets
		/// </summary>
		public int BulletCount
		{
			get { return _bulletCount; }
			set { _bulletCount = value; }
		}
		/// <summary>
		/// If Dead / has been hit or not.
		/// </summary>
		public bool IsDead
		{
			get { return _dead; }
			set { _dead = value; }
		}
		/// <summary>
		/// Sets the other tank.
		/// </summary>
		public Tank SetEnemy
		{
			set { _enemy = value; }
			get { return _enemy; }
		}
		/// <summary>
		/// gets the radians calculated from current rotation.
		/// </summary>
		private double Radians
		{
			get { return (Math.PI / 180) * _rotation; }
		}

		#endregion
		//##########################################################
		#region Public Methods



		/// <summary>
		/// ABSTRACT gets movement input from user
		/// </summary>
		public abstract void StartMovement(KeyEventArgs e);
		/// <summary>
		/// ABSTRACT STOPS movement input from user
		/// </summary>
		public abstract void StopMovement(KeyEventArgs e);
		/// <summary>
		/// Draws The Tank appropiately
		/// </summary>
		/// <param name="graphics"> paper to be drawn on from picturebox paint</param>
		public override void Draw(Graphics graphics)
		{
			if (!_dead)
			{ // if not dead, draw image rotated to current rotaion.
				Image rotatedTankImage = RotateImage();
				graphics.DrawImage(rotatedTankImage, X - 10, Y - 10, (float)(Width * 1.5), (float)(Height * 1.5));
			}
			else
			{   //Draw explosion
				graphics.DrawImage(Properties.Resources.explosion, BoundingBox);
			}
		}
		/// <summary>
		/// Rotates and Moves the tank using current Movement / Rotating Values
		/// </summary>
		public override void Move()
		{
			if (!_dead)
			{   //change current rotation based on input
				_rotation += Turn;
				CheckRotation();
				if (_movement != 0)
				{
					///Doing the X and Y values seperately means that the tank
					///can slide along a wall at an angle if still trying to move.

					//new hypothetical position for y movement.
					RectangleF newXPosition = BoundingBox;
					//adds X movement based on current rotation
					newXPosition.X += (float)(Movement * Math.Sin(Radians));
					//if new position isnt in a wall or doesnt intersect with enemy, then move.
					if (!Maze.TouchesWall(newXPosition) && !newXPosition.IntersectsWith(_enemy.BoundingBox))
					{
						X = newXPosition.X;
					}
					//new hypothetical position for y movement.
					RectangleF newPositionY = BoundingBox;
					//adds Y movement based on current rotation
					newPositionY.Y += (float)(-Movement * Math.Cos(Radians));
					//if new position isnt in a wall or doesnt intersect with enemy, then move.
					if (!Maze.TouchesWall(newPositionY) && !newPositionY.IntersectsWith(_enemy.BoundingBox))
					{
						Y = newPositionY.Y;
					}
				}

			}
		}
		/// <summary>
		/// Attempts to shoot a bullet
		/// </summary>
		/// <returns>A Bullet if successful, else null</returns>
		public Bullet Shoot()
		{
			if (Shooting && BulletCount < 9 && !_dead)
			{
				//Calculate the x and y velocity / movement vertically and horizontally for bullet
				double xVelocity = Math.Sin(Radians);
				double yVelocity = -Math.Cos(Radians);
				//reset the cooldown since bullet is successful.
				_bulletCoolDown = 4;
				//return bullet to add to list.
				return new Bullet(X, Y, Maze, xVelocity, yVelocity, this);
			}
			else
			{
				return null;
			}

		}
		/// <summary>
		/// Sets Tank to new Position with default values.
		/// </summary>
		/// <param name="rand"></param>
		public void NewPosition(Random rand)
		{   //reset all values
			_bulletCount = 0;
			_movement = 0;
			_turnMovement = 0;
			_rotation = rand.Next(0, 360);
			_shooting = false;
			_dead = false;
			do  ///repeat until a valid position is found.
			{
				X = rand.Next((int)Maze.Boundary.Left, (int)Maze.Boundary.Right);
				Y = rand.Next((int)Maze.Boundary.Top, (int)Maze.Boundary.Bottom);
			} while (Maze.TouchesWall(BoundingBox) || CollidedWith(_enemy.BoundingBox));
		}
		/// <summary>
		/// Checks if this tank is hit by any bullets in the given list.
		/// </summary>
		/// <param name="bullets">The list of bullets to check through</param>
		/// <returns>True if the tank is hit, False if the tank is not Touching any of the bullets in the GIVEN list</returns>
		public bool IsHit(List<Bullet> bullets)
		{
			//IF not dead, else can already return false.
			if (!_dead)
			{
				foreach (Bullet bullet in bullets)
				{
					if (bullet.CollidedWith(this.BoundingBox))
					{
						bullet.Finished = true;
						_dead = true;
						return true;
					}
				}
				return false;
			}
			return true;
		}
		#endregion
		//##########################################################
		#region Private Methods

		/// <summary>
		/// Sets rotation to always be 0 - 360 degrees, and sets the bullet variables to the same
		/// rotation.
		/// </summary>
		private void CheckRotation()
		{
			if (_rotation > 359)
			{
				_rotation %= 360;
			}
			if (_rotation < 0)
			{
				_rotation += 360; ;
			}
		}

		/// <summary>
		/// Rotates the image according the the rotation of the tank
		/// </summary>
		/// <returns>returns the rotated image</returns>
		private Image RotateImage()
		{
			CheckRotation();
			//create a new empty bitmap to hold rotated image
			Bitmap returnBitmap = new Bitmap(_tankImage.Width, _tankImage.Height);
			using (Graphics g = Graphics.FromImage(returnBitmap))
			{
				//move rotation point to center of image
				g.TranslateTransform((float)_tankImage.Width / 2, (float)_tankImage.Height / 2);
				//rotate
				g.RotateTransform(_rotation);
				//move image back
				g.TranslateTransform(-(float)_tankImage.Width / 2, -(float)_tankImage.Height / 2);
				//draw passed in image onto graphics object
				g.DrawImage(_tankImage, new Point(0, 0));
			}
			return returnBitmap;
		}
		#endregion
	}
}