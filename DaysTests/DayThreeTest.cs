using Xunit;
using System.Collections;
using Days;
using Moq;
using Assert = Xunit.Assert;

namespace DaysTests;

public class PuzzleFixtureDayThree
{
    public List<string> MockPuzzlesDayThree { get; } = new()
    {

    };
}

public class DayThreeTest : IClassFixture<PuzzleFixtureDayThree>
{
    private readonly List<string> _mockPuzzlesDayThree;

    public DayThreeTest(PuzzleFixture fixture)
    {
        _mockPuzzlesDayThree = fixture.MockPuzzlesDayThree;
    }
}