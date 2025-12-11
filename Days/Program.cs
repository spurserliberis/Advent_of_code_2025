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
            RunDayThree();
        }

        static void RunDayOne()
        {
            var solver = new DayOne();  // reads ../Inputs/PuzzleInput.txt
            int result = solver.SolvePuzzle();
            Console.WriteLine($"Day 1 Result: {result}");
        }
        
        static void RunDayTwo()
        {
            var solver = new DayTwo();
            long result = solver.SolveDayTwoPuzzle();
            Console.WriteLine($"Day 2 Result: {result}");
        }
        
        static void RunDayThree()
        {
            var solver = new DayThree();
            var result = solver.SolveDayThreePuzzle();
            Console.WriteLine($"Day 3 Result: {result}");
        }
    }
}