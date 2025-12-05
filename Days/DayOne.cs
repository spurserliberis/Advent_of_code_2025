using System.Linq;
using System;

namespace Days;

public class DayOne
{
    // Get the data
    // Define what to do
    // Implement the action
    // Process the result

    // Take puzzle input
    private readonly List<string> puzzles;

    // Constructor accepts test data, or reads from file if null
    public DayOne(List<string>? puzzles = null)
    {
        if (puzzles != null)
        {
            this.puzzles = puzzles;
        }
        else
        {
            var raw = File.ReadAllText("PuzzleInput.txt");
            this.puzzles = raw
                .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList();
        }

    }

    public int SolvePuzzle()
    {

        int dial = 50;
        int password = 0;
        // Iterate over array
        foreach (var puzzle in puzzles)
        {
            // Get each letter and convert to operation
            // L = minus, R = plus
            // Use this to add or subtract the numbers
            var letter = puzzle[0];
            var number = Int32.Parse(puzzle[1..]);
            
            if (letter == 'L')
            {
                dial -= number;
                // When going left from 0 the numbers restart from 99
                // When the dial is less than 0 start from 99 and continue with rotation
                // wrap below 0
                // if the dial goes below zero, do not go into negative numbers, instead add 100
                // Use a while, so if the subtracted number is larger than 100, it will rotate for any number of subtractions
                // i.e if only acts once, whereas while will keep adding 100 until it is no longer below 0.
                
                // Amend it so that it add every times it passes 0
                while (dial < 0)
                {
                    dial += 100;
                    // For part two add one to password each time the dials passes 0
                    password++;
                }

            }
            else
            {
                dial += number;
                // when going right from 99 the dial resets to 0
                while (dial > 99)
                {
                    dial -= 100;
                    // For part two add one to password each time the dials passes 0
                    password++;
                }
            }

            // When dial hits zero add one to password
            if (dial == 0)
            {
                password++;
            }

        }
        return password;
    }
}
