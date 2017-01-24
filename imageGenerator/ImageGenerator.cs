using System.Drawing;
using DirectionNs;

namespace imageGenerator
{
	public static class ImageGenerator
	{
		public static Image Generate(Direction[][] maze, int size = 16)
		{
			int width = 0;
			foreach (var item in maze)
			{
				if (item.Length > width) { width = item.Length; }
			}
			var img = new Bitmap(size * width, size*maze.Length);
			Point pos;
			var images = new Images(size, Color.Black).images;

			using (Graphics gfx = Graphics.FromImage(img))
			{
				for (int x = 0; x < maze.Length; x++)
				{
					for (int y = 0; y < maze[x].Length; y++)
					{	
						pos = new Point(y * size, x * size);
						gfx.DrawImage(images[maze[x][y]], pos);
					}
				}
			}
			return img;
		}
	}
}
