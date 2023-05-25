using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input_s1_13.txt");
            StreamReader sr2 = new StreamReader("output_s1_13.txt");
            int realans = Convert.ToInt32(sr2.ReadLine());
            //Считывание всех слов
            int n = Convert.ToInt32(sr.ReadLine());
            string[] words = new string[n];
            int[] wordsint = new int[n];
            for (var i = 0; i < n; i++)
            {
                words[i] = sr.ReadLine();
            }
            //Считывание возможных начальных букв
            int f = Convert.ToInt32(sr.ReadLine());
            char[] unfirstletters = new char[f];
            int[] unnumberfirst = new int[f];
            char[] firstletters = new char[f];
            int[] numberfirst = new int[f];
            for (var i = 0; i < f; i++)
            {
                string line = sr.ReadLine();
                string[] s1 = line.Split(' ');
                unfirstletters[i] = Convert.ToChar(s1[0]);
                unnumberfirst[i] = Convert.ToInt32(s1[1]);
            }
            //Сортировка возможных начальных букв по возрастанию
            for (var i = 0; i < f; i++)
            {
                int min = 999999;
                int index = 0;
                for (var j = 0; j < f; j++)
                {
                    if (unnumberfirst[j] < min)
                    {
                        min = unnumberfirst[j];
                        index = j;
                    }
                }
                unnumberfirst[index] = 999999;
                firstletters[i] = unfirstletters[index];
                numberfirst[i] = min;
            }
            //Считывания возможных последних букв
            int l = Convert.ToInt32(sr.ReadLine());
            char[] unlastletters = new char[l];
            int[] unnumberlast = new int[l];
            char[] lastletters = new char[l];
            int[] numberlast = new int[l];
            for (var i = 0; i < l; i++)
            {
                string line = sr.ReadLine();
                string[] s1 = line.Split(' ');
                unlastletters[i] = Convert.ToChar(s1[0]);
                unnumberlast[i] = Convert.ToInt32(s1[1]);
            }
            //Сортировка возможных последних букв по убыванию
            for (var i = 0; i < l; i++)
            {
                int max = 0;
                int index = 0;
                for (var j = 0; j < l; j++)
                {
                    if (unnumberlast[j] > max)
                    {
                        max = unnumberlast[j];
                        index = j;
                    }
                }
                unnumberlast[index] = 0;
                lastletters[i] = unlastletters[index];
                numberlast[i] = max;
            }
            int ans = 0;
            //Поиск числа желаний
            for (var i = 0; i < f; i++)
            {
                for (var j = 0; j < l; j++)
                {
                    for (var k = 0; k < n; k++)
                    {
                        if ((words[k][0] == firstletters[i]) && (words[k][words[k].Length - 1] == lastletters[j]) && (numberfirst[i] > 0) && (numberlast[j] > 0) && (wordsint[k]!=1))
                        {
                            wordsint[k] = 1;
                            numberfirst[i] -= 1;
                            numberlast[j] -= 1;
                            ans++;
                        }
                    }
                }
            }
            if (ans == realans)
            {
                Console.WriteLine("Тест пройден");
            }
            Console.WriteLine("Мой ответ: "+ans + "\n" + "Правильный ответ: " + realans);
            Console.ReadLine();
        }
    }
}
