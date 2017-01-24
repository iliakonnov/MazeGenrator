namespace DirectionNs
{
	public class Direction
	{
		public bool IsLeft { get; set; }
		public bool IsRight { get; set; }
		public bool IsDown { get; set; }
		public bool IsUp { get; set; }
		public override int GetHashCode()
		{
			return
				IsLeft.GetHashCode() * 1000 +
				IsRight.GetHashCode() * 100 +
				IsDown.GetHashCode() * 10 +
				IsUp.GetHashCode();
		}
		public override bool Equals(object obj)
		{
			return GetHashCode() == obj.GetHashCode();
		}
	}
}
