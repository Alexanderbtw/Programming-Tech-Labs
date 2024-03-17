namespace ProgrammingTheoryOOP.Task3.Entities;

public sealed class Bowl : Entity {
	public override string Title { get; set; } = "Plate";
	public override decimal Cost { get; set; }
	

	public Bowl(decimal cost, string? title, int length = 4, int width = 4, int height = 3) : base(length, width, height) { 
		Cost = cost;
		Title = title ?? Title;
	}
}