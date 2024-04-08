using System.Globalization;
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
        MyDate.TryParse(date, out MyDate? result, CultureInfo.GetCultureInfo("en-US"));
        
        // Assert
        Assert.That(result, Is.Not.Null);
    }

    [Test]
    public void TryParseReturnsFalse()
    {
        // Arrange
        string date = "1/20/2022";
        
        // Act
        MyDate.TryParse(date, out MyDate? result, CultureInfo.GetCultureInfo("ru-RU"));
        
        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public void ToStringReturnsCorrectValue()
    {
        // Arrange
        string expected = "1/20/2022";
        
        // Act
        MyDate date = new MyDate(20, 1, 2022);
        string? actual = date.ToString();
        
        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void ComparisonReturnsTrue()
    {
        // Arrange
        MyDate date1 = new MyDate(10, 1, 2023);
        MyDate date2 = new MyDate(28, 12, 2022);
        
        // Act
       bool actual = date1 > date2;
        
        // Assert
        Assert.That(actual, Is.True);
    }
}
