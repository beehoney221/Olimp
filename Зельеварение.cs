using System;
using System.IO;
class HelloWorld
{
  static void Main() 
  {
    StreamReader sr1 = new StreamReader("input10.txt");
    string s;
    int n = 0;
    while( (s = sr1.ReadLine())!=null)
    {
        n++;
    }
    sr1.Close();
    StreamReader sr = new StreamReader("input10.txt");
    s = "";
    string[] smesh = new string[n];
    for(var i=0; i<n; i++)
    {
        string stroka = sr.ReadLine();
        string[] s1 = stroka.Split(" ");
        if(s1[0] == "MIX")
        {
            s = "MX";
        }
        else if (s1[0] == "WATER")
        {
            s = "WT";
        }
        else if(s1[0] == "DUST")
        {
            s = "DT";
        }
        else if (s1[0] == "FIRE")
        {
            s = "FR";
        }
        smesh[i] = s;
        for(var j = 1; j<s1.Length; j++)
        {
            int m =0;
            if (Int32.TryParse(s1[j], out m))
            {
                m = Convert.ToInt32(s1[j]);
                smesh[i] = smesh[i] + smesh[m-1];
            }
            else
            {
                smesh[i] = smesh[i] + s1[j];
            }
        }
        smesh[i] = smesh[i] + s[1] + s[0];
    }
    StreamReader sr2 = new StreamReader("output10.txt");
    string otvet = sr2.ReadLine();
    if(otvet == smesh[n-1])
    {
        Console.WriteLine("Совпало с ответом");
    }
    else
    {
        Console.WriteLine("Не совпало с ответом");
    }
}
}
