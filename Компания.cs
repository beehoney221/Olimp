using System;
using System.Collections.Generic;
using System.IO;

namespace Комания_олимпиадки_
{
    class Program
    {
        public static void Proverka(ref List<string> number, ref List<string> name, string[] s)
        {
            if ((s.Length == 1) || ((s.Length == 2) && (s[1] == "")))
            {
                number.Add(s[0]);
                name.Add("Unknown Name");
            }
            else if (s.Length == 2)
            {
                number.Add(s[0]);
                name.Add(s[1]);
            }
            else if (s.Length == 3)
            {
                number.Add(s[0]);
                name.Add(s[1] + " " + s[2]);
            }
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input_s1_01.txt");
            string s = sr.ReadLine();
            List<string> numbern = new List<string>();
            List<string> namen = new List<string>();
            List<string> numberp = new List<string>();
            List<string> namep = new List<string>();
            while (s != "END")
            {
                string[] s1 = s.Split(' ');
                s = sr.ReadLine();
                string[] s2 = s.Split(' ');
                Proverka(ref numbern, ref namen, s1);
                Proverka(ref numberp, ref namep, s2);
                s = sr.ReadLine();
            }
            for(var i =0; i<numbern.Count; i++)
            {
                for(var j=0; j<numberp.Count; j++)
                {
                    if ((numbern[i] == numberp[j]) && (namep[j] != "Unknown Name"))
                    {
                        namen[i] = namep[j];
                    }
                    if ((numbern[i] == numberp[j]) && (namen[i] != "Unknown Name"))
                    {
                        namep[j] = namen[i];
                    }
                }
            }
            s = sr.ReadLine();
            List<string> otvetn = new List<string>();
            List<string> un = new List<string>();
            for (var i = 0; i < numbern.Count; i++)
            {
                if (un.Contains(numbern[i]) == false)
                {
                    un.Add(numbern[i]);
                }
            }
            for (var i=0; i<numbern.Count; i++)
            {
                if ((s == namen[i]) || (s == numbern[i]))
                {
                    string number = numberp[i];
                    string name = namep[i];
                    if(otvetn.Contains(numberp[i]) == false)
                        otvetn.Add(number);
                }
            }
            int x = un.Count;
            for(var i=0; i<un.Count; i++)
            {
                for (var k = 0; k < otvetn.Count; k++)
                {
                    if (un.IndexOf(otvetn[k]) >= 0)
                    {
                        for (var j = 0; j < numbern.Count; j++)
                        {
                            if ((otvetn[k] == numbern[j]) && (otvetn.Contains(numberp[j]) == false))
                            {
                                otvetn.Add(numberp[j]);
                            }
                        }
                    }
                    un.Remove(otvetn[k]);
                }
            }
            List<string> otvetname = new List<string>();
            otvetn.Sort();
            for(var i=0; i<otvetn.Count; i++)
            {
                int k = numberp.IndexOf(otvetn[i]);
                otvetname.Add(namep[k]);
            }
            for(var i=0; i<otvetn.Count; i++)
            {
                Console.WriteLine(otvetn[i] + " " + otvetname[i]);
            }
            Console.WriteLine("Общее число подчинённых: " + otvetn.Count);
        }
    }
}
