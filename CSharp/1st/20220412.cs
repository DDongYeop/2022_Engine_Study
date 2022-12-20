using System;

namespace _2022._04._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            for(int i = 0; i < a; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            int num = int.Parse(Console.ReadLine());
            for (int q = 0; q < num; q++)
            {
                for (int w = 0; w < (num - q - 1); w++)
                {
                    Console.Write(" ");
                }
                for (int e = 0; e <= q; e++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            while (true)
            {
                Console.Write("문자열을 입력해주세용 : ");
                string input = Console.ReadLine();
                if (input == "Exit")
                {
                    break;
                }
            }

            int ahffn = int.Parse(Console.ReadLine());
            for (int i =0; i<ahffn; i++)
            {
                if (i % 2 == 1)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
        }
    }
}
