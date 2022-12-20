using System;

namespace _2022._04._07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] a = { "강민성", "고다민" };
            for(int i = 0;  i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }


            int b = int.Parse(Console.ReadLine());
            while(b != 0)
            {
                Console.WriteLine(b);
                b = int.Parse(Console.ReadLine());
            }


            int c = int.Parse(Console.ReadLine());
            while(100 <= c || c >= 1)
            {
                Console.WriteLine(c);
                c--;
            }

            string input;
            do
            {
                input = Console.ReadLine();
            } while (input != "q");





        }
    }
}
