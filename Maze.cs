using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tank_Game
{
	public class Maze
	{
		//###############################
		#region Instance Variables


		/// <summary>
		/// Random variable used in the reset maze and delete randomWalls Methods.
		/// </summary>
		private Random _rand = new Random();
		/// <summary>
		/// 2d array that holds all the maze cell  values (pathway or wall)
		/// before the walls are created.
		/// 0 is a wall, 1 is a pathway.
		/// </summary>
		private int[,] _maze;
		/// <summary>
		/// Holds the column length of the maze, as this is changed each time it resets.
		/// </summary>
		private float _width;
		/// <summary>
		/// Holds the row length / height of the maze array, as this is changed each time it resets
		/// </summary>
		private float _height;
		/// <summary>
		/// Holds all the Rectangles / Walls generated and shown as the maze (including the boundary walls)
		/// </summary>
		private List<RectangleF> _walls;
		/// <summary>
		/// IS a rectangle of the bounds of the maze where sprites can move in.
		/// changes location and size 
		/// based on how big the cells are, as it redraws the maze on a grid basis on this
		/// </summary>
		private RectangleF _boundary;

		#endregion
		//###################################################
		#region Constructor

		public Maze(PictureBox pictureBox)
		{
			Reset(pictureBox);
		}
		#endregion
		//###################################################
		#region Propertys



		/// <summary>
		/// Gets the boundary of the generated maze that tanks can spawn in.
		/// </summary>
		public RectangleF Boundary
		{
			get
			{
				return _boundary;
			}
			set { _boundary = value; }
		}
		#endregion
		//################################################
		#region Public Methods


		/// <summary>
		/// Regenerates the maze using a random size for the pathway betwwen walls.
		/// </summary>
		/// <param name="game">the pictureBox the maze lives in and is drawn on.</param>
		public void Reset(PictureBox game)
		{
			/// set new pathway to a random number (current mins and max are nicest range).
			int pathSize = _rand.Next(46, game.Width / 9);
			//create random ODD number from picturebox size and width;
			_width = game.Width / pathSize;
			_height = game.Height / pathSize;
			///Round up width and height to the next odd number,
			///so that the outer walls always format correctly And
			/// the generation (recursion) will never go out of bounds by checking
			/// if 2 cells ahead is out of bouns / null.
			if (_width % 2 == 0) _width++;
			if (_height % 2 == 0) _height++;
			//initialize the maze array to the new sizes.
			_maze = new int[(int)_width, (int)_height];
			///set the starting cell to zero - pathway.
			_maze[1, 1] = 1;
			///create the randomized maze using the algorithm in the maze recurison method.
			GenerateMaze(1, 1);
			///delete some walls to open long mazes up and make game more fun
			DeleteRandomWallCells();
			///store the walls in a list for easy reference once created and drawing.
			_walls = CreateWalls(game);
		}

		/// <summary>
		/// Draws all the walls / rectangles in the walls List on the given pictureBox,
		/// including boundarys.
		/// </summary>
		/// <param name="paper"> The Graphics object the maze is to be drawn on.</param>
		public void Display(Graphics paper)
		{
			//brush for filling rectangles.
			SolidBrush br = new SolidBrush(Color.Black);
			foreach (RectangleF wall in _walls)
			{ //Draw each rectangle filled in in the list.
				paper.FillRectangle(br, wall);
			}
		}

		/// <summary>
		/// Returns true IF sprite not in a wall,
		/// </summary>
		/// <param name="sprite">The Sprite To be Checked.</param>
		/// <returns>True if sprite is inside a wall, otherwise false</returns>
		public bool TouchesWall(RectangleF sprite)
		{
			foreach (RectangleF wall in _walls)
			{
				if (wall.IntersectsWith(sprite))
				{
					return true;
				}
			}
			return false;
		}

		#endregion
		//################################################
		#region Private Methods


		/// <summary>
		/// uses Recursion to create a depth first seach algorithm, that starts at the first input given. it then
		/// creates pathways of 1s and 0's by exploring all possible directions one at a time in the current cell.
		/// it then calls itself each time one of these pathways is valid, so that it falls all possible squares 
		/// in the maze ( leaving space between pathways for wall cells, which stay 0.
		/// </summary>
		/// <param name="x">the X index of the maze the pathway is currently going from</param>
		/// <param name="y">the Y index of the maze the pathway is currently going from</param>
		private void GenerateMaze(int x, int y)
		{
			//Get A List of all possible directions, that are randomized.
			List<string> randomizedDirections = new List<string> { "Up", "Right", "Down", "Left" }.OrderBy(_ => _rand.Next()).ToList();
			//for each possible direction, cycle through the randomized direction.
			for (int i = 0; i < 4; i++)
			//check the current direction.
			{
				switch (randomizedDirections[i])
				{
					// _MAZE walls and pathway cells are both always 1 cell wide,
					// so to create a new path you always have to move two cells in a direction.
					// each case checks if that direction is valid and hasn't already been travelled - 
					// 0 is a wall, 1 is a path.
					case "Up":
						// Break current iteration loop if 2 cells up from current cell is out of bounds of maze
						if (y - 2 <= 0) { continue; }
						//if Next movement up HASNT already been used
						if (_maze[x, y - 2] != 1)
						{   //set Maze to Cells in this direction to path (One)
							_maze[x, y - 2] = 1;
							_maze[x, y - 1] = 1;
							GenerateMaze(x, y - 2);
						}
						break;
					case "Right":
						// Break current itereation if 2 cells to the right is out of bounds of the maze
						if (x + 2 >= _width - 1) { continue; }
						//if Next movement right hasnt already been used
						if (_maze[x + 2, y] != 1)
						{ //set Maze to Cells in this direction to path (One)
							_maze[x + 2, y] = 1;
							_maze[x + 1, y] = 1;
							GenerateMaze(x + 2, y);
						}
						break;
					case "Down":
						// Break current itereation if 2 cells Down is out of bounds of the maze
						if (y + 2 >= _height - 1) { continue; }
						//if Next movement Down hasnt already been used
						if (_maze[x, y + 2] != 1)
						{//set Maze to Cells in this direction to path (One)
							_maze[x, y + 2] = 1;
							_maze[x, y + 1] = 1;
							GenerateMaze(x, y + 2);
						}
						break;
					case "Left":
						// Break current itereation if 2 cells left is out of bounds of the maze
						if (x - 2 <= 0) { continue; }
						//if Next movement Left hasnt already been used
						if (_maze[x - 2, y] != 1)
						{//set Maze to Cells in this direction to path (One)
							_maze[x - 2, y] = 1;
							_maze[x - 1, y] = 1;
							GenerateMaze(x - 2, y);
						}
						break;
				}
			}
		}

		/// <summary>
		/// Deletes random walls in the _maze array.
		/// Done to open it up and make gameplay / tactics more fun.
		/// </summary>
		private void DeleteRandomWallCells()
		{ // random amound of walls to be removed.
		  // The width of the maze array i found is a nice number to remove up to (what GETLength is).
			int amountToBeRemoved = _rand.Next(0, _maze.GetLength(0));
			while (amountToBeRemoved >= 0)
			{   //get a random coordinate  cell in maze array that isnt on the outside.
				//GET Length returns the length of That arrays dimension in a multi dimensional array.
				int x = _rand.Next(1, _maze.GetLength(0) - 1);
				int y = _rand.Next(1, _maze.GetLength(1) - 1);
				//if the maze array is a wall, change it to a pathway. (1).
				if (_maze[x, y] == 0)
				{
					_maze[x, y] = 1;
				} // reduce the loop regardless as maze's can often not contain any internal walls.
				amountToBeRemoved--;
			}
		}

		/// <summary>
		/// Generates the maze wall rectangles based on the _maze cells
		/// Relies on the _maze array to know where to draw.
		/// </summary>
		/// <param name="pictureBox"></param>
		/// <returns>A List of walls that the maze is made up of / can draw.</returns>
		private List<RectangleF> CreateWalls(PictureBox pictureBox)
		{
			//sets the walls list to a new (Empty) list of rectangles.
			List<RectangleF> walls = new List<RectangleF>();
			{   // Get the width and height of each cell in the maze relative to the pictureBox.
				float cellLength = (pictureBox.Width / _width / 2);
				float cellHeight = (pictureBox.Height / _height / 2);
				// Set the maze Boundary to the center of the outside cells.     //  - lengthS * 3  to account for the first offset.
				_boundary = new RectangleF(cellLength * 1.5f, cellHeight * 1.5f, pictureBox.Width - cellLength * 3, pictureBox.Height - cellHeight * 3);
				//for every column of the maze array
				for (int col = 0; col < _width; col++)
				{   //for every row of the maze array
					for (int row = 0; row < _height; row++)
					{   // If 
						if (_maze[col, row] != 1)
						{   //Get Location of current cell as a starting point to draw from.
							PointF current = new PointF(col * (pictureBox.Width / _width), row * (pictureBox.Height / _height));
							//IF current cell has a wall cell above it, draw a wall to that cell.
							if (row - 1 >= 0 && _maze[col, row - 1] != 1)
							{
								walls.Add(new RectangleF(current.X + cellLength, current.Y, 8, cellHeight + 8));
							}//IF current cell has a wall cell to the BOTTOM, draw a wall to that cell.
							if (row + 1 < _height && _maze[col, row + 1] != 1)
							{
								walls.Add(new RectangleF(current.X + cellLength, current.Y + cellHeight, 8, cellHeight));
							}
							//IF current cell has a wall cell to the right, draw a wall to that cell.
							if (col + 1 < _width && _maze[col + 1, row] != 1)
							{
								walls.Add(new RectangleF(current.X + cellLength, current.Y + cellHeight, cellLength, 8));
							}//IF current cell has a wall cell to the left, draw a wall to that cell.
							if (col - 1 >= 0 && _maze[col - 1, row] != 1)
							{
								walls.Add(new RectangleF(current.X, current.Y + cellHeight, cellLength, 8));
							}
						}
					}
				}
				return walls;
			}
			#endregion
		}
		//End of class
	}
}