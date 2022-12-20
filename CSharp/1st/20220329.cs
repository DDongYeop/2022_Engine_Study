using System;

namespace _2022._03._29
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int time = DateTime.Now.Hour;

            if (time <= 11)
            {
                Console.WriteLine("오전입니다");
            }
            if(time >= 12)
            {
                Console.WriteLine("오후입니다.");
            }


            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (a > b)
            {
                Console.WriteLine(">");
            }

            else if (a > b)
            {
                Console.WriteLine("<");
            }

            else
            {
                Console.WriteLine("==");
            }



            int c = int.Parse(Console.ReadLine());

            if (c >=90)
            {
                Console.WriteLine("A");
            }
            else if (c >= 80)
            {
                Console.WriteLine("B");
            }
            else if (c >= 70)
            {
                Console.WriteLine("C");
            }
            else if (c >= 60)
            {
                Console.WriteLine("D");
            }
            else
            {
                Console.WriteLine("F");
            }

            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            if (d > 0 && e > 0)
            {
                Console.WriteLine("제 1사분면");
            }
            else if (d < 0 && e > 0)
            {
                Console.WriteLine("제 2사분면");
            }
            else if (d < 0 && e < 0)
            {
                Console.WriteLine("제 3사분면");
            }
            else if (d > 0 && e < 0)
            {
                Console.WriteLine("제 4사분면");
            }
            else
            {
                Console.WriteLine("몰?루");
            }


        }
    }
}