using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using DirectionNs;

namespace imageGenerator
{
	public class Images
	{
		public Dictionary<Direction, Image> images = new Dictionary<Direction, Image>();
		int _size;
		Color _color;
		public Images(int size, Color color)
		{
			_size = size;
			_color = color;
			int third = size / 3;
			int doubleThird = third * 2;

			// Look at positions.png
			size--;
			var ps = new Point[] {
				new Point(0, 0),            // 0
				new Point(third, 0),        // 1
				new Point(doubleThird, 0),  // 2
				new Point(size, 0),         // 3

				new Point(0, third),            // 4
				new Point(third, third),        // 5
				new Point(doubleThird, third),  // 6
				new Point(size, third),         // 7

				new Point(0, doubleThird),            // 8
				new Point(third, doubleThird),        // 9
				new Point(doubleThird, doubleThird),  // 10
				new Point(size, doubleThird),         // 11

				new Point(0, size),            // 12
				new Point(third, size),        // 13
				new Point(doubleThird, size),  // 14
				new Point(size, size),         // 15
			};

			#region 0
			AddImage(
				new Point[][] {
				new Point[] { ps[0], ps[15] },
				new Point[] { ps[3], ps[12] },
				new Point[] { ps[0], ps[12] },
				new Point[] { ps[0], ps[3] },
				new Point[] { ps[3], ps[15] },
				new Point[] { ps[12], ps[15] }
				},
				new Direction { }
			);
			#endregion

			#region 1
			//
			AddImage(
				new Point[][] {
				new Point[] { ps[4], ps[6] },
				new Point[] { ps[6], ps[10] },
				new Point[] { ps[8], ps[10] }
				},
				new Direction { IsLeft = true }
			);

			// Right
			AddImage(
				new Point[][] {
				new Point[]{ ps[5], ps[7] },
				new Point[]{ ps[5], ps[9] },
				new Point[]{ ps[9], ps[11] }
				},
				new Direction { IsRight = true }
			);

			// Up
			AddImage(
				new Point[][] {
				new Point[] { ps[1], ps[9] },
				new Point[] { ps[9], ps[10] },
				new Point[] { ps[2], ps[10] }
				},
				new Direction { IsUp = true }
			);

			// Down
			AddImage(
				new Point[][] {
				new Point[] { ps[13], ps[5] },
				new Point[] { ps[5], ps[6] },
				new Point[] { ps[6], ps[14] },
				},
				new Direction { IsDown = true }
			);
			#endregion

			#region 2
			// Left
				// Up (4,5,1; 8,10,2)
				AddImage(
					new Point[][] {
					new Point[] { ps[4], ps[5] },
					new Point[] { ps[5], ps[1] },
					new Point[] { ps[8], ps[10] },
					new Point[] { ps[10], ps[2] },
					},
					new Direction { IsLeft = true, IsUp = true }
				);

				// Down (8,9,13; 4,6,14)
				AddImage(
					new Point[][] {
					new Point[] { ps[8], ps[9] },
					new Point[] { ps[9], ps[13] },
					new Point[] { ps[4], ps[6] },
					new Point[] { ps[6], ps[14] },
					},
					new Direction { IsLeft = true, IsDown = true }
				);

				// Right (4,7; 8,11)
				AddImage(
					new Point[][] {
					new Point[] { ps[4], ps[7] },
					new Point[] { ps[8], ps[11] }
					},
					new Direction { IsLeft = true, IsRight = true }
				);

			// Up
				// Down (1,13; 2,14)
				AddImage(
					new Point[][] {
					new Point[] { ps[1], ps[13] },
					new Point[] { ps[2], ps[14] },
					},
					new Direction { IsUp = true, IsDown = true }
				);

				// Right (2,6,7; 1,9,11)
				AddImage(
					new Point[][] {
						new Point[] { ps[2], ps[6] },
						new Point[] { ps[6], ps[7] },
						new Point[] { ps[1], ps[9] },
						new Point[] { ps[9], ps[11] },
					},
					new Direction { IsUp = true, IsRight = true }
				);

			// Down
				// Right (13,5,7; 14,10,11)
				AddImage(
					new Point[][] {
					new Point[] { ps[13], ps[5] },
					new Point[] { ps[5], ps[7] },
					new Point[] { ps[14], ps[10] },
					new Point[] { ps[10], ps[11] }
					},
					new Direction { IsDown = true, IsRight = true }
				);
			#endregion

			#region 3
			// Left
				// Up
					// Down (4,5,1; 2,14; 8,9,13)
					AddImage(
						new Point[][] {
						new Point[] { ps[4], ps[5] },
						new Point[] { ps[5], ps[1] },
						new Point[] { ps[2], ps[14] },
						new Point[] { ps[8], ps[9] },
						new Point[] { ps[9], ps[13] }
						},
						new Direction { IsLeft = true, IsUp = true, IsDown = true }
					);
					
					// Right (4,5,1; 2,6,7; 8,11)
					AddImage(
						new Point[][] {
						new Point[] { ps[4], ps[5] },
						new Point[] { ps[5], ps[1] },
						new Point[] { ps[2], ps[6] },
						new Point[] { ps[6], ps[7] },
						new Point[] { ps[8], ps[11] },
						},
						new Direction { IsLeft = true, IsUp = true, IsRight = true }
					);
			// Down
				// Right (8,9,13; 14,10,11; 4,7)
				AddImage(
					new Point[][] {
					new Point[] { ps[8], ps[9] },
					new Point[] { ps[9], ps[13] },
					new Point[] { ps[14], ps[10] },
					new Point[] { ps[10], ps[11] },
					new Point[] { ps[4], ps[7] }
					},
					new Direction { IsLeft = true, IsDown = true, IsRight = true }
				);

			// Up
				// Down
					// Right (2,6,7; 11,10,14; 1,13)
					AddImage(
						new Point[][] {
						new Point[] { ps[2], ps[6] },
						new Point[] { ps[6], ps[7] },
						new Point[] { ps[11], ps[10] },
						new Point[] { ps[10], ps[14] },
						new Point[] { ps[1], ps[13] },
						},
						new Direction { IsUp = true, IsDown = true, IsRight = true }
					);

			#endregion

			#region 4
			// All (4,5,1; 2,6,7; 8,9,13; 11,10,14)
			AddImage(
				new Point[][] {
				new Point[] { ps[4], ps[5] },
				new Point[] { ps[5], ps[1] },
				new Point[] { ps[2], ps[6] },
				new Point[] { ps[6], ps[7] },
				new Point[] { ps[8], ps[9] },
				new Point[] { ps[9], ps[13] },
				new Point[] { ps[11], ps[10] },
				new Point[] { ps[10], ps[14] },
				},
				new Direction { IsUp = true, IsDown = true, IsLeft = true, IsRight = true }
			);
			#endregion
		}
		void AddImage(Point[][] positions, Direction key)
		{
			var img = new Bitmap(_size, _size);

			using (Graphics gfx = Graphics.FromImage(img))
			using (Pen pen = new Pen(new SolidBrush(_color)))
			{
				foreach (var pos in positions)
				{
					gfx.DrawLine(pen, pos[0], pos[1]);
				}
			}
			images.Add(key, img);
		}
	}
}
