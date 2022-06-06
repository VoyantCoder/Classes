
// Author: Dashie


using System.Linq;
using System;


namespace SumGenerator
{
    public partial class SolidCore
    {
        public void Separate(string line = "-", int count = 30) => Print(new string('~', count).Replace("~", line));

        public void Print(object line, string endl = "\n") => Console.Write($"{line?.ToString()}{endl}");
        public void Print(object line) => Print(line, "\n");

        public void Error(object line, string endl = "\n") => Print("(!)" + line, endl);
        public void Error(object line) => Print("(!) " + line);
    }

    public partial class SolidCore
    {
        private void MathGame(char choice, int level, int difficulty)
        {


            switch (choice)
            {
                case '-':
                    break;
                case '+':
                    break;
                case '/':
                    break;
                case '%':
                    break;
                case '*':
                    break;
            }
        }

        private int ToInt(string line)
        {
            int Error() 
            {
                this.Error("Not an integer. Using the default value (1) ...");
                return 1;
            }
            return int.TryParse(line, out int result) ? result : Error();
        }
        private int ToInt(char character) => ToInt(character.ToString());

        public void Menu()
        {
            char choice = '+';
            int level = 1;
            int difficulty = 2;

            Print("Setting[1/1]");
            Separate();
            Print("-     ---     Subtraction");
            Print("+     ---     Addition");
            Print("/     ---     Division");
            Print("%     ---     Remainder");
            Print("*     ---     Multiplication");
            Separate();
            Print("Choose one of the above options.");
            Print("Just enter the corresponding character.");
            Separate();
            Print("Choice: ", "");

            choice = Console.ReadKey().KeyChar;

            Separate();
            Print("Do you want to configure optional details?");
            Print("Things such as the max amount of score");
            Separate();
            Print("(Y/n): ", "");

            if (Console.ReadLine().ToLower() == "y")
            {
                Print("Setting [2/3]:");
                Separate();
                Print("Enter the level of nested sums.");
                Print("Make sure it is realistic.");
                Separate();
                Print("Level: ", "");

                level = ToInt(Console.ReadLine());

                Print("Setting [3/3]:");
                Separate();
                Print("1     ---     Easy   [0 - +100]");
                Print("2     ---     Medium [0 - +1000]");
                Print("3     ---     Hard [0 - +10000]");
                Print("4     ---     On Level [-1000 - +10000");
                Print("5     ---     Training [-1000000 - +1000000");
                Print("6     ---     Master Wizard [-1000000000 - +1000000000");
                Separate();
                Print("Difficulty: ", "");

                difficulty = ToInt(Console.ReadKey().KeyChar);
            }

            MathGame(choice, level, difficulty);
        }

        public void Redirect() => Menu();
    }

    public class Program
    {
        private readonly static SolidCore solidCore = new();
        public static void Main(string[] args) => solidCore.Redirect();
    }
}
