using System.Collections;
using Moq;
using Xunit;

namespace DayOneScenario;

public class DayOneTest()
{
    [Fact]
    public void GetThePuzzleInputAndReturnTheFirstElement()
    {
        // Arrange
        var mockPuzzles = new List<string> { "L12", "R4", "L16", "L27" };
        var dayOne = new DayOne(mockPuzzles, 0);
        dayOne.SolvePuzzle();

        // Act
        var firstElement = mockPuzzles[0];
        var listCount = mockPuzzles.Count();
        
        // Assert
        Assert.Equal(4, listCount);
        Assert.Equal("L12", firstElement); 

    }
    [Fact]
    public void GetTheLetterConvertToOperationAndAddToDial()
    {
        // Arrange
        var mockPuzzlesTwo = new List<string> { "L12"};
        var dayOne = new DayOne(mockPuzzlesTwo, 0);
        
        // Act
        dayOne.SolvePuzzle();
        
        // Assert
        Assert.Equivalent(38, dayOne.SolvePuzzle());
    }
}