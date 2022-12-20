using System;

namespace _2022._04._08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 9; i++)
            {
                Console.WriteLine(n * i);
            }


            int N = int.Parse(Console.ReadLine());
            for(int O = 0;  N > O; N--)
            {
                Console.WriteLine(N);
            }
        }
    }
}