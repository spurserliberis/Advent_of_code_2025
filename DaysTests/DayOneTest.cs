using System.Collections;
using Days;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace DayOneScenario;

public class DayOneTest()
{
    [Fact]
    public void GetThePuzzleInputAndReturnTheFirstElement()
    {
        // Arrange
        var mockPuzzles = new List<string> { "L12", "R4", "L16", "L27" };
        var dayOne = new DayOne(mockPuzzles);
        dayOne.SolvePuzzle();

        // Act
        var firstElement = mockPuzzles[0];
        var listCount = mockPuzzles.Count();
        
        // Assert
        Assert.Equal(4, listCount);
        Assert.Equal("L12", firstElement); 

    }
    [Fact]
    public void GetTheListAndReturnPasswordThree()
    {
        // Arrange
        var mockPuzzlesTwo = new List<string> { "L68", "L30", "R48", "L5", "R60", "L55", "L1", "L99", "R14", "L82"};
        var dayOne = new DayOne(mockPuzzlesTwo);
        
        // Act
        var result = dayOne.SolvePuzzle();
        
        // Assert
        Assert.Equal(3, result);
    }
}