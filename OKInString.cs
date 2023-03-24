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
        int index = str.IndexOf("ok");

        if (index != -1)
        {
            string firstPart = str.Substring(0, index);
            string secondPart = str.Substring(index + 2);
            return firstPart + secondPart;
        }
        else
        {
            return str;
        }
    }
}
