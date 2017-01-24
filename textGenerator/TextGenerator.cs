using System;
using Symbols;
using mazeGenerator;

namespace textGenerator
{
	public static class TextGenerator
	{
		public static string[] Generate(Direction[][] maze)
		{
			var data = new char[maze.Length][];
			for (int x = 0; x < maze.Length; x++)
			{
				data[x] = new char[maze[x].Length];
				for (int y = 0; y < maze[x].Length; y++)
				{
					data[x][y] = Symbols.Symbols.symbols[maze[x][y]];
				}
			}
			var result = new string[maze.Length];
			for (int i = 0; i < data.Length; i++)
			{
				result[i] = new string(data[i]);
			}
			return result;
		}

		public static void Save(string[] maze, string fName)
		{
			throw new NotImplementedException("Save not implemented yet");
		}

		public static void Main(string[] args)
		{
			var maze = BinaryTree.Generate(int.Parse(args[0]), int.Parse(args[1]));
			var text = Generate(maze);
			foreach (var line in text)
			{
				Console.WriteLine(line);
			}
			Save(text, args[2]);
		}
	}
}
