using System.Linq;
using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Days;

public class DayTwo
{
    // Get the data
    // Define what to do
    // Implement the action
    // Process the result
    
    // Take the product ID ranges. Represented as a single long line
    // each ID is separated by a comma
    // first and last id is separated by a dash
    // find invalid ids where some sequence of digits is repeated twice
    // e.g 55, 6464, 123123
    // none of the ids have leading zeroes
    
    // csv, separate each pair to those within commas
    // find all the ids within the pairs, including the first and last ids
    // if any of the ids contain a sequence of digits repreated twice add to invalidIds
    // return the sum of the invalidIds


    private readonly List<string> productIdRanges;

    public DayTwo(List<string>? productIdRanges = null)
    {
        // Constructor accepts test data, or reads from file if null
        if (productIdRanges != null)
        {
            this.productIdRanges = productIdRanges;
        }
        else
        {
            var raw = File.ReadAllText("../Inputs/DayTwoPuzzleInput.txt");
            this.productIdRanges = raw
                // Takes the contents of the input file (raw).
                // Splits it into separate lines on newline characters ('\n').
                // Removes any empty lines.
                // Trims whitespace from each line.
                // Converts the result into a List<string>.
                .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList();

        }
    }

    public long SolveDayTwoPuzzle()
    {
        // Step 1: Flatten comma-separated ranges into a single list of ints
        var productId = productIdRanges
            .SelectMany(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .ToList();
        
        var invalidIds = new List<long>();
        // Remove hyphen and find all the ids within the pairs, including the first and last ids
        foreach (var id in productId)
        {
            var range = id.Split('-');
            if (long.TryParse(range[0], out long start) &&
                long.TryParse(range[1], out long end))
            {
                // Iterate over the expanded ranges and implement ContainsRepeatedSequence method
                for (long num = start; num <= end; num++)
                {
                    if (ContainsRepeatedSequence(num))
                        invalidIds.Add(num);
                }
                
                
            }
            
        }
        // Treat the range as a string and find half the length and then compare both halves
        // return the sum of the invalidIds
        return invalidIds.Sum();
    }
    
    // part one
    // private bool ContainsRepeatedSequence(long id)
    // {
    //     // convert into string to make it easier to iterate and compare numbers
    //     string s = id.ToString();
    //     // Store number of digits in a string i.e 55 is n = 2
    //     int n = s.Length;
    //
    //     // valid lengths of X are any divisor of n where X is repeated exactly twice
    //     if (n % 2 != 0)
    //         // because s must be exactly X + X, if a number is repeated the count is an even number
    //         return false;
    //
    //     // X must be exactly half of the length for pattern X+X
    //     int k = n / 2;
    //
    //     // left half is from index 0 to k, which is exactly half
    //     string left = s.Substring(0, k);
    //     string right = s.Substring(k, k);
    //
    //     return left == right;
    // }
    
    
    // part two
    // Now, an ID is invalid if it is made only of some sequence of digits repeated at least twice. So, 12341234 (1234 two times), 123123123 (123 three times), 1212121212 (12 five times), and 1111111 (1 seven times) are all invalid IDs.
    public bool ContainsRepeatedSequence(long id)
    {
        string s = id.ToString();
        // stores the number of digits in the id
        int n = s.Length;

        // Loops through every possible length of a repeating substring
        // len represents the size of the candidate block and only checks up to n/2 as a repeating block must be smaller
        // than the whole string
        // Example: For "123123" (length 6), candidate chunk sizes are: 1, 2, 3
        for (int len = 1; len <= n / 2; len++)
        {
            // The total length must be a multiple of the candidate block size
            // The full length must divide evenly by the block length
            if (n % len != 0)
                continue;

            // extract the first len digits as the repeating block
            string block = s.Substring(0, len);

            // Build a repeated version of the block
            // Determines how many times the block must repeat to match the full length
            // Example: n = 6, len = 3 → repeatCount = 2
            int repeatCount = n / len;
            // Rebuilds a string by repeating the block the necessary number of times.
            // Example: block = "123", repeatCount = 2 → "123123"
            string repeated = string.Concat(Enumerable.Repeat(block, repeatCount));
            
            // Checks if the rebuilt "XXX" string matches the original.
            // If yes → the ID is made of repeated blocks → invalid.
            if (repeated == s)
                return true;
        }

        return false; // valid: no repeated sequence found
        
    }

}
