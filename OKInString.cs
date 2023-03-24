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
        if (str.Contains("ok"))
        {
            return str.Replace("ok", "");
        }
        else
        {
            return str;
        }
    }
}
