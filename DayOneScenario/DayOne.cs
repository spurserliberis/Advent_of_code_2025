using System.Linq;
using System;

namespace DayOneScenario;

public class DayOne
{
    // Get the data
    // Define what to do
    // Implement the action
    // Process the result
    
    // Take puzzle input
    List<string> puzzles;
    int password;

    public DayOne(List<string> puzzles, int password)
    {
        this.puzzles = puzzles;
        this.password = password;
    }

    public int SolvePuzzle()
    {
        int dial = 50;
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
                // When the dial is less than 0 start from 99
                if (dial < 0)
                {
                    dial = 99;
                }
                
            }
            else 
            {
                dial += number;
                // when going right from 99 the dial resets to 0
                if (dial > 99)
                {
                    dial = 0;
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