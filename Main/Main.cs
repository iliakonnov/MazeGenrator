using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Mono.Options;
using DirectionNs;
using MazeGenerator;
using imageGenerator;
using textGenerator;

namespace Main
{
	public static class MainClass
	{
		public static void Main(string[] args)
		{
			string text = null;
			string image = null;
			string load = null;
			string testDicts = null;
			bool print = false;
			bool showHelp = false;
			int height = -1;
			int width = -1;
			int size = 16;

			var os = new OptionSet {
				{ "H|height=", "Height of new maze", v => height = v != null? int.Parse(v): -1 },
				{ "w|width=", "Width of new maze", v => width = v != null? int.Parse(v): -1 },
				{ "l|load=", "Load maze from text file", v => load = v },
				{ "t|text=", "Output file for text maze", v => text = v },
				{ "p|print", "Print maze to stdout", v => print = v != null },
				{ "i|image=", "Output file for png maze", v => image = v },
				{ "s|size=", "Image element size", v => size = v != null? int.Parse(v): 16 },
				{ "h|help",  "show this message and exit", v => showHelp = v != null },
				{ "test",  "generate test folder", v => testDicts = v },
			};
			os.Parse(args);

			if (showHelp)
			{
				os.WriteOptionDescriptions(Console.Out);
				return;
			} 	
			if (load == null && (height <= 0 || width <= 0))
			{
				Console.WriteLine("Maze size must be more than zero");
				return;
			}
			if (text == null && image == null && !print)
			{
				Console.WriteLine("-t|text= or -i|image= or -p|print must be specified");
				return;
			}
			if (image != null && size <= 0)
			{
				Console.WriteLine("Image element size must be more than zero");
				return;
			}

			Direction[][] maze;
			if (load == null)
			{
				maze = BinaryTree.Generate(width, height);
			}
			else
			{
				maze = TextGenerator.Parse(File.ReadLines(load).ToArray());
			}

			if (print || text != null)
			{
				var textMaze = TextGenerator.Generate(maze);
				if (print)
				{
					foreach (var line in textMaze)
					{
						Console.WriteLine(line);
					}
				}
				if (text != null)
				{
					File.WriteAllLines(text, textMaze);
				}
			}

			if (image != null)
			{
				ImageGenerator.Generate(maze, size).Save(image);
			}

			if (testDicts != null)
			{
				string name;
				foreach (KeyValuePair<Direction, Image> entry in new Images(256, Color.Black).images)
				{
					name = testDicts + "/";
					name += Symbols.symbols[entry.Key] + "_";
					if (entry.Key.IsUp) { name += "Up"; }
					if (entry.Key.IsDown) { name += "Down"; }
					if (entry.Key.IsLeft) { name += "Left"; }
					if (entry.Key.IsRight) { name += "Right"; }
					name += ".png";

					entry.Value.Save(name);
				}
			}
		}
	}
}
