namespace ProgrammingTheoryOOP.Task3.Entities;

public abstract class Entity {
	public int Length { init; get; }
	public int Width { init; get; }
	public int Height { init; get; }
	public virtual string Title { get; set; } = string.Empty;
	public virtual decimal Cost { get; set; }

	public int MinEdge => Math.Min(Length, Math.Min(Width, Height));
	
	public int MinSurface {
		get {
			if (Length > Width)
				if (Length > Height)
					return Height * Width;
				else
					return Length * Width;
			else
				if (Width > Height)
					return Height * Length;
				else
					return Width * Length;
		}
	}

	public Entity(int? length, int? width, int? height) {
		Length = length ?? Length;
		Width = width ?? Width;
		Height = height ?? Height;
	}

	public override string ToString() {
		return $"{Title} ({Length}x{Width}x{Height}) \nCost: {Cost}";
	}
}