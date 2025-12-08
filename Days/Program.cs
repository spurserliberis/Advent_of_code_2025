using System;
using Days;

namespace DaysApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // For running manually
            RunDayOne();
            RunDayTwo();
        }

        static void RunDayOne()
        {
            var solver = new DayOne();  // reads ../Inputs/PuzzleInput.txt
            int result = solver.SolvePuzzle();
            Console.WriteLine($"Day 1 Result: {result}");
        }
        
        static void RunDayTwo()
        {
            var solver = new DayTwo();  // reads ../Inputs/PuzzleInput.txt
            var result = solver.SolveDayTwoPuzzle();
            Console.WriteLine($"Day 2 Result: {result}");
        }
    }
}