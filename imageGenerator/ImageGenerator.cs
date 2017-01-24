using System;
using System.Drawing;
using Symbols;
using mazeGenerator;

namespace imageGenerator
{
	public static class ImageGenerator
	{
		public static Bitmap Generate(Direction[][] maze)
		{
			throw new NotImplementedException("ImageGenerator not implemented yet");
		}

		public static void Main(string[] args)
		{
			var maze = BinaryTree.Generate(int.Parse(args[0]), int.Parse(args[1]));
			var img = Generate(maze);
			img.Save(args[2]);
		}
	}
}
