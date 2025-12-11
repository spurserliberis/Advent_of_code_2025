using Xunit;
using System.Collections;
using Days;
using Moq;
using Assert = Xunit.Assert;

namespace DaysTests;

// Use IClassFixture to create a single shared instance of a fixture for all tests within this class
public class PuzzleFixture
{
    public List<string> MockPuzzles { get; } = new()
    {
        "11-22","95-115,", "998-1012","1188511880-1188511890","222220-222224",
        "1698522-1698528","446443-446449","38593856-38593862","565653-565659",
        "824824821-824824827","2121212118-2121212124"
    };
}

// Test class uses PuzzleFixture as a shared resource, creates once instance of PuzzleFixture and uses it for all tests
public class DayTwoTest : IClassFixture<PuzzleFixture>
{
    private readonly List<string> _mockPuzzles;

    public DayTwoTest(PuzzleFixture fixture)
    {
        _mockPuzzles = fixture.MockPuzzles;
    }
    
    [Fact]
    public void GetThePuzzleInputAndReturnAndCountArray()
    {
        // Arrange
        var dayTwo = new DayTwo(_mockPuzzles);

        // Act
        dayTwo.SolveDayTwoPuzzle();
        var result = _mockPuzzles;

        // Assert
        Assert.Equal(11, result.Count);

    }
    
    // [Fact]
    // public void GetThePuzzleInputAndReturnTheCorrectOutputForPartOne()
    // {
    //     // Arrange
    //     var dayTwo = new DayTwo(_mockPuzzles);
    //
    //     // Act
    //     var result = dayTwo.SolveDayTwoPuzzle();
    //
    //     // Assert
    //     Assert.Equal(1227775554, result);
    //     
    // }
    
    [Xunit.Theory]
    [InlineData(11)]             // "1" repeated twice
    [InlineData(1212)]           // "12" repeated twice
    [InlineData(123123)]         // "123" repeated twice
    [InlineData(111111)]         // "1" repeated six times
    [InlineData(565656)]         // "56" repeated three times
    [InlineData(824824824)]      // "824" repeated three times
    [InlineData(2121212121)]     // "21" repeated five times
    public void ContainsRepeatedSequenceShouldReturnTrueForInvalidRepeatedIds(long id)
    {
        var dayTwo = new DayTwo(_mockPuzzles);
        bool result = dayTwo.ContainsRepeatedSequence(id);
        Assert.True(result);
    }
    
    [Fact]
    public void GetThePuzzleInputAndReturnTheCorrectOutputForPartTwo()
    {
        // Arrange
        var dayTwo = new DayTwo(_mockPuzzles);
    
        // Act
        var result = dayTwo.SolveDayTwoPuzzle();
    
        // Assert
        Assert.Equal(4174379265, result);
        
    }

}