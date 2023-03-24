using System;

public class OKInString
{
    public static void Main()
    {
       string str =  Console.ReadLine();
        Console.WriteLine(RemoveOk(str));
        
    }

    public static string RemoveOk(string str)
    {
        str = str.ToLower();
        int index;
        while ((index = str.IndexOf("ok")) != -1)
        {
            string firstPart = str.Substring(0, index);
            string secondPart = str.Substring(index + 2);
            str = firstPart + secondPart;
        }
        return str;
    }
}
