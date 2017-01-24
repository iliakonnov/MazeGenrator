﻿using System.Collections.Generic;
using System.Linq;

namespace Symbols
{
	public class Direction
	{
		public bool IsLeft { get; set; }
		public bool IsRight { get; set; }
		public bool IsDown { get; set; }
		public bool IsUp { get; set; }
	}

	public static class Symbols
	{
		public static Dictionary<Direction, char> symbols = new Dictionary<Direction, char>
		{
			// None
			{ new Direction { }, '▒'},

			// ===1==
				{ new Direction { IsLeft = true }, '╡'},
				{ new Direction { IsUp = true }, '╨'},
				{ new Direction { IsDown = true }, '╥'},
				{ new Direction { IsRight = true }, '╞'},

			// ===2===
				// Left
					{ new Direction { IsLeft = true, IsUp = true }, '╝'},  // Up
					{ new Direction { IsLeft = true, IsDown = true }, '╗'},  // Down
					{ new Direction { IsLeft = true, IsRight = true }, '═'},  // Right

				// Up
					{ new Direction { IsUp = true, IsDown = true }, '║'},  // Down
					{ new Direction { IsUp = true, IsRight = true }, '╚'},  // Right

				// Down
					{ new Direction { IsDown = true, IsRight = true}, '╔'},  // Right

			// ===3===
				// Left
					// Up
						{ new Direction { IsLeft = true, IsUp = true, IsDown = true }, '╣'},  // Down
						{ new Direction { IsLeft = true, IsUp = true, IsRight = true }, '╩'},  // Right
					// Down
						{ new Direction { IsLeft = true, IsDown = true, IsRight = true }, '╦'},  // Right
				// Up
					// Down
						{ new Direction { IsUp = true, IsDown = true, IsRight = true }, '╠'},  // Right

			// ===4===
				{ new Direction { IsLeft = true, IsUp = true, IsRight = true, IsDown = true }, '╬'}  // All
		};

		public static Dictionary<char, Direction> directions = symbols.ToDictionary(x => x.Value, x => x.Key);
	}
}
