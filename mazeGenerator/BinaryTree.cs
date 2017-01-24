using System;
using Symbols;

namespace mazeGenerator
{
	public static class BinaryTree
	{
		public static Direction[][] Generate(int width, int height)
		{
			var result = new Direction[height][];

			var randomer = new Random();
			var directions = new Direction[] {
				new Direction { IsUp = true },
				new Direction { IsLeft = true },
				new Direction { IsUp = true, IsLeft = true }
			};
			for (int x = 0; x < height; x++)
			{
				for (int y = 0; y < width; y++)
				{
					if (x != 0 && y != 0)
					{
						result[x][y] = directions[randomer.Next(0, 2)];
						if (result[x][y].IsUp)
						{
							result[x - 1][y].IsDown = true;
						}
						if (result[x][y].IsLeft)
						{
							result[x][y - 1].IsRight = true;
						}
					}
					else if ( x == 0 )
					{
						result[x][y] = directions[1];  // Up side always left
						result[x][y - 1].IsRight = true;
					}
					else if ( y == 0 )
					{
						result[x][y] = directions[0];  // Left side always up
						result[x - 1][y].IsDown = true;
					}
				}
			}

			return result;
		}
	}
}
