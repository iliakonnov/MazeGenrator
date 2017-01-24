using System;
using System.Drawing;
using DirectionNs;
using MazeGenerator;

namespace imageGenerator
{
	public static class ImageGenerator
	{
		public static Image Generate(Direction[][] maze, int size = 16)
		{
			var img = new Bitmap(size*maze.Length, size*maze[0].Length);
			Point pos;
			var images = new Images(size, Color.Black).images;

			using (Graphics gfx = Graphics.FromImage(img))
			{
				for (int x = 0; x < maze.Length; x++)
				{
					for (int y = 0; y < maze[x].Length; y++)
					{
						pos = new Point(x * size, y * size);
						gfx.DrawImage(images[maze[x][y]], pos);
					}
				}
			}
			return img;
		}

		public static void Main(string[] args)
		{
			var maze = BinaryTree.Generate(int.Parse(args[0]), int.Parse(args[1]));
			var img = Generate(maze);
			img.Save(args[2]);
		}
	}
}
