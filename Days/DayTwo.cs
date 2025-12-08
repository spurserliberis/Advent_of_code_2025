namespace DefaultNamespace;

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
            var raw = File.ReadAllText("../Inputs/PuzzleInput.txt");
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

    public int SolveDayTwoPuzzle()
    {
        // csv, separate each pair to those within commas
        
        // find all the ids within the pairs, including the first and last ids
        // if any of the ids contain a sequence of digits repeated twice add to invalidIds
        // return the sum of the invalidIds
    }

}