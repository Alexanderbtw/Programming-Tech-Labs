namespace ProgrammingTheoryOOP.Task3.Entities;

public sealed class Plate : Entity {
	public override string Title { get; set; } = "Plate";
	public override decimal Cost { get; set; }
	

	public Plate(decimal cost, string? title, int length = 4, int width = 4, int height = 1) : base(length, width, height) { 
		Cost = cost;
		Title = title ?? Title;
	}
}