using Lab2.Task4.Entities;

namespace Lab2.Tests;

public class Task4_Tests
{
    [Test]
    public void TryParseReturnsTrue() 
    {
        // Arrange
        string date = "1/20/2022";

        // Act
        MyDate.TryParse(date, out MyDate? result);
    }
}
