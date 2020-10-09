using System;

namespace MoodAnalyser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Program!");
            MoodAnalyserFactory.Initialize("MoodAnalyser",55);
        }
    }
}
