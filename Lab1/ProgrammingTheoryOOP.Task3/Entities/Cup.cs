namespace ProgrammingTheoryOOP.Task3.Entities;

public sealed class Cup : Entity {
	public override string Title { get; set; } = "Cup";
	public override decimal Cost { get; set; }
	

	public Cup(decimal cost, string? title, int length = 2, int width = 2, int height = 5) : base(length, width, height) { 
		Cost = cost;
		Title = title ?? Title;
	}
}