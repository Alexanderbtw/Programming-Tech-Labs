using ProgrammingTheoryOOP.Task3.Entities;
using ProgrammingTheoryOOP.Task3.Exceptions;
using ProgrammingTheoryOOP.Task3.Infrastructure;

namespace ProgrammingTheoryOOP.Tests.Task3;

[TestFixture]
[TestOf(typeof(Table))]
public class TableTest {
	[SetUp]
	public void Setup() {
	}

	[Test]
	public void PutCupNotNull()
	{
		// Arrange
		var table = new Table(10, 10);
		var cup = new Cup(100, "Cup 1", 1, 1, 1);
    
		// Act
		table.Put(cup);
    
		// Assert
		Assert.That(table.Find("Cup 1"), Is.Not.Null);
	}

	[Test]
	public void PutCupIsTooBig() {
		// Arrange
		var table = new Table(1, 1);
		var cup = new Cup(100, "Cup 1", 2, 2, 2);

		// Act
		// Assert
		Assert.Throws<TooBigException>(() => table.Put(cup));
	}

	[Test]
	public void TakeCupNull()
	{
		// Arrange
		var table = new Table(10, 10);
		var cup = new Cup(100, "Cup 1", 1, 1, 1);
		table.Put(cup);
    
		// Act
		table.Take(cup);
    
		// Assert
		Assert.That(table.Find("Cup 1"), Is.Null);
	}

	[Test]
	public void TakeCupNotFound() {
		// Arrange
		var table = new Table(10, 10);
		var cup = new Cup(100, "Cup 1", 1, 1, 1);
		
		// Act
		// Assert
		Assert.Throws<EntityNotFoundException>(() => table.Take(cup));
	}
}