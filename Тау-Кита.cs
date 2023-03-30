using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input_s1_08.txt");
            string s1 = sr.ReadToEnd();
            string[] s = s1.Split(' ');
            int centre = s.Length/2;
            string[] sk = new string[s.Length];
            //Перестановка слов
            //Данный фор ставит на свои места слова, лежащие слева от первого
            for(var i=0; i<s.Length/2; i++)
            {
                sk[2*i+1] = s[centre - i-1];
            }

            //Данный иф с фором ставит на место первое слово и слова, лежащие справа от него, если слов чётное кол-во
            if (s.Length % 2 == 0)
            {
                for (var i = 0; i < s.Length / 2; i++)
                {
                    sk[2 * i] = s[centre + i];
                }
            }
            //Данный элз с фором ставит на место первое слово и слова, лежащие справа от него, если слов нечётное кол-во
            else
            {
                for (var i = 0; i <= s.Length / 2; i++)
                {
                    sk[2 * i] = s[centre + i];
                }
            }
            //Перестановка букв
            string s2 = "";
            int centres = 0;
            for (var j = 0; j < sk.Length; j++)
            {
                s2 = sk[j];
                char[] s3 = new char[s2.Length];
                centres = s2.Length/2;
                //Данный фор ставит на свои места буквы, лежащие слева от первой
                for (var i = 0; i < s2.Length / 2; i++)
                {
                    s3[2*i + 1] = s2[centres - i - 1];
                }

                //Данный иф с фором ставит на место первую букву и буквы, лежащие справа от неё, если букв в слове чётное кол-во
                if (s2.Length % 2 == 0)
                {
                    for (var i = 0; i < s2.Length / 2; i++)
                    {
                        s3[2 * i] = s2[centres + i];
                    }
                }
                //Данный элз с фором ставит на место первую букву и буквы, лежащие справа от неё, если букв в слове нечётное кол-во
                else
                {
                    for (var i = 0; i <= s2.Length / 2; i++)
                    {
                        s3[2 * i] = s2[centres + i];
                    }
                }
                sk[j] = null;
                for(var i=0; i<s3.Length; i++)
                {
                    sk[j] = sk[j]+s3[i];
                }
            }
            //Вывод результата на экран
            for (var i = 0; i < sk.Length; i++)
                Console.Write(sk[i] + " ");
            Console.WriteLine("");
            //Перевод стрингового массива в сторку для дальнейшего сравнения нашего ответа с правильным ответом
            string otvet = "";
            for (var i=0; i < sk.Length; i++)
            {
                otvet = otvet + sk[i] + " "; 
            }
            otvet = otvet.Remove(otvet.Length-1);
            //Сравнение полученного нами результата и правильного ответа
            StreamReader sr1 = new StreamReader("output_s1_08.txt");
            string prav_otvet = sr1.ReadToEnd();
            if (prav_otvet == otvet) Console.WriteLine("Всё работает!");
            else Console.WriteLine("Всё не работает!");
            Console.ReadLine();
        }
    }
}
