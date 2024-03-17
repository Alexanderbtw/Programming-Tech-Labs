namespace ProgrammingTheoryOOP.Task3.Entities;

public sealed class Spoon : Entity {
	public override string Title { get; set; } = "Spoon";
	public override decimal Cost { get; set; }
	

	public Spoon(decimal cost, string? title, int length = 5, int width = 1, int height = 1) : base(length, width, height) { 
		Cost = cost;
		Title = title ?? Title;
	}
}