using ProgrammingTheoryOOP.Task7.Entities;
using ProgrammingTheoryOOP.Task7.Exceptions;

namespace ProgrammingTheoryOOP.Tests.Task7;

[TestFixture]
[TestOf(typeof(Group))]
public class GroupTest {

	[Test]
	public void TryAddStudentWithinLimit() {
		// Arrange
		var group = new Group(1, 3, "Test Group");
		var student = new Student("John", "Doe");

		// Act
		group.TryAddStudent(student);

		// Assert
		Assert.That(group, Has.Count.EqualTo(1));
	}

	[Test]
	public void TryAddStudentAtLimit() {
		// Arrange
		var group = new Group(1, 1, "Test Group");
		var student1 = new Student("Jane", "Smith");
		var student2 = new Student("Smith", "Jane");

		// Act
		group.TryAddStudent(student1);
		group.TryAddStudent(student2);

		// Assert
		Assert.That(group, Has.Count.EqualTo(1));
	}

	[Test]
	public void AddStudentAtLimit() {
		// Arrange
		var group = new Group(1, 1, "Test Group");
		var student1 = new Student("Jane", "Smith");
		var student2 = new Student("Smith", "Jane");
		
		// Act
		group.AddStudent(student1);
		TestDelegate action = () => group.AddStudent(student2);
		
		// Assert
		Assert.Throws<IndexOutOfRangeException>(action);
	}

	[Test]
	public void RemoveStudentAtMinCount() {
		// Arrange
		var group = new Group(1, 3, "Test Group");
		var student = new Student("Alice", "Johnson");
		group.AddStudent(student);

		// Act
		TestDelegate action = () => group.RemoveStudent(student);
		
		// Assert
		Assert.Throws<TooFewException>(action);
	}

	[Test]
	public void FindStudentByNameAndSurname() {
		// Arrange
		var group = new Group(1, 3, "Test Group");
		var student1 = new Student("Alice", "Johnson");
		var student2 = new Student("Bob", "Smith");
		group.TryAddStudent(student1);
		group.TryAddStudent(student2);

		// Act
		var foundStudent = group.Find("Bob", "Smith");

		// Assert
        Assert.Multiple(() =>
        {
	        Assert.That(foundStudent, Is.Not.Null);
            Assert.That(foundStudent!.Name, Is.EqualTo("Bob"));
            Assert.That(foundStudent!.Surname, Is.EqualTo("Smith"));
        });
    }
}