using System;

public class Program
{
    public static void Main()
    {
        string inputString = "hello world";
        string outputString = ExchangeFirstAndLastCharacters(inputString);
        Console.WriteLine("Input string: " + inputString);
        Console.WriteLine("Output string: " + outputString);
    }

    public static string ExchangeFirstAndLastCharacters(string input)
    {
        if (input.Length <= 1)
        {
            return input;
        }
        else
        {
            char firstChar = input[0];
            char lastChar = input[input.Length - 1];
            string middleChars = input.Substring(1, input.Length - 2);
            return lastChar + middleChars + firstChar;
        }
    }
}
