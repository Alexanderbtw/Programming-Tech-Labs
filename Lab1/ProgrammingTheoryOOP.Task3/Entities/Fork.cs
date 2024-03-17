namespace ProgrammingTheoryOOP.Task3.Entities;

public sealed class Fork : Entity {
	public override string Title { get; set; } = "Fork";
	public override decimal Cost { get; set; }
	

	public Fork(decimal cost, string? title, int length = 4, int width = 1, int height = 1) : base(length, width, height) { 
		Cost = cost;
		Title = title ?? Title;
	}
}