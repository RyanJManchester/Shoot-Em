using System.Drawing;
namespace Tank_Game
{
	public abstract class Sprite
	{
		//########################################################################
		#region Instance Variables
		/// <summary>
		/// The Maze is needed in each sprite to check if positions are valid.
		/// </summary>
		private Maze _maze;
		/// <summary>
		/// the X- horizontal coordinate of the sprite (left)
		/// </summary>
		private float _x;
		/// <summary>
		/// The Y - vertical coordinate of the sprite (top)
		/// </summary>
		private float _y;
		/// <summary>
		/// The width of the sprite, in pixels.
		/// </summary>
		private int _width;
		/// <summary>
		/// The height of the sprite, in pixels.
		/// </summary>
		private int _height;

		#endregion
		//########################################################################
		#region Constructors


		/// <summary>
		/// Creates a new sprite.
		/// </summary>
		/// <param name="x">the X- horizontal coordinate of the sprite (left).</param>
		/// <param name="y"> The Y - vertical coordinate of the sprite (top).</param>
		/// <param name="width">The width of the sprite.</param>
		/// <param name="height">The height of the sprite.</param>
		public Sprite(Maze maze, int x, int y, int width, int height)
		{
			_maze = maze;
			_x = x;
			_y = y;
			_width = width;
			_height = height;
		}
		#endregion
		//########################################################################
		#region Properties
		/// <summary>
		/// The x-coordinate of the left edge of the sprite.
		/// </summary>
		public float X
		{
			get { return _x; }
			set { _x = value; }
		}

		/// <summary>
		/// The y-coordinate of the top edge of the sprite.
		/// </summary>
		public float Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		/// <summary>
		/// The width of the sprite, in pixels.
		/// </summary>
		public int Width
		{
			get
			{
				return _width;
			}
		}

		/// <summary>
		/// The height of the sprite, in pixels.
		/// </summary>
		public int Height
		{
			get
			{
				return _height;
			}
		}

		/// <summary>
		/// The rectangular area ocupied by the sprite.
		/// </summary>
		public RectangleF BoundingBox
		{
			get
			{
				return new RectangleF(_x, _y, _width, _height);
			}
		}
		public Maze Maze
		{
			get { return _maze; }
			set { _maze = value; }
		}

		#endregion
		//########################################################################
		#region Public Methods
		/// <summary>
		/// Moves the sprite by a small amount.
		/// This method is called periodically using a timer and should move the
		/// sprite according to its speed and/or behaviour. This is an abstract
		/// method with different implementations in every subclass.
		/// </summary>
		public abstract void Move();

		/// <summary>
		/// Displays the sprite in the given graphics context.
		/// This method is called periodically by a paint event handler and should
		/// draw the sprite. It is an abstract method with different implementations 
		/// in every subclass.
		/// </summary>
		public abstract void Draw(Graphics graphics);

		/// <summary>
		/// Checks whether this sprite has a collision with another sprite.
		/// This method compares the rectangular regions of two sprites to
		/// check for an overlap.
		/// </summary>
		/// <param name="other">The other sprite to check for collision with.</param>
		/// <returns>true if the two sprites overlap, false otherwise.</returns>
		public bool CollidedWith(RectangleF box)
		{
			return BoundingBox.IntersectsWith(box);
		}

		#endregion

	}
}
