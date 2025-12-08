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
            var raw = File.ReadAllText("../Inputs/PuzzleInput.txt");
            this.puzzles = raw
            // Takes the contents of the input file (raw).
            // Splits it into separate lines on newline characters ('\n').
            // Removes any empty lines.
            // Trims whitespace from each line.
            // Converts the result into a List<string>.
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
                // dial -= number;
                // When going left from 0 the numbers restart from 99
                // When the dial is less than 0 start from 99 and continue with rotation
                // wrap below 0
                // if the dial goes below zero, do not go into negative numbers, instead add 100
                // Use a while, so if the subtracted number is larger than 100, it will rotate for any number of subtractions
                // i.e if only acts once, whereas while will keep adding 100 until it is no longer below 0.

                
                // while (dial < 0)
                // {
                //     dial += 100;
                // }
                //

                // PART TWO: each time the dial clicks past 0 during a rotation or at the end, increment password
                for (int click = 0; click < number; click++)
                {
                    // decrement dial by one, rather than by the number as seen in the while loop in part one
                    dial --;
                    if (dial < 0)
                    {
                        // Anytime the dial reaches 0, the dial returns to 99 and starts to decrement again from 99
                        dial = 99;
                    }

                    if (dial == 0)
                    {
                        password++;
                    }
                }

            }
            else
            {
                // dial += number;
                // when going right from 99 the dial resets to 0
                // while (dial > 99)
                // {
                //     dial -= 100;
                // }
                
                // PART TWO: each time the dial clicks past 0 during a rotation or at the end, increment password
                for (int click = 0; click < number; click++)
                {
                    // increment dial by one, rather than the number as seen in the while loop in part one
                    dial ++;
                    if (dial > 99)
                    {
                        // Anytime the dial reaches 99, the dial returns to 0
                        dial = 0;
                        // as it lands on zero above, it also counts as a zero click
                        password++;
                        // skip the next if block. If dial is greater than 99 it is reset to  0, that meets the criteria for the if 
                        // block below, so that same zero click is counted twice
                        continue;
                    }

                    if (dial == 0)
                    {
                        password++;
                    }
                }
                
            }

            // FOR PART ONE
            // When dial hits zero add one to password
            // if (dial == 0)
            // {
            //     password++;
            // }

        }
        return password;
    }
}
