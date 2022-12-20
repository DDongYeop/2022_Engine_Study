using System;

namespace _2022._04._21
{
    /*class calculator
    {
        public static int Multiply(int a, int b)
        {
            return a * b;
        }

        internal class Program
        {
            static void Main()
            {
                int result = calculator.Multiply(459, 16); //ㅜㅅㅜ#7344
                Console.WriteLine(result);
            }
        }
    }*/

    class MaonApp
    {
        public static int Square(int a)
        {
            int b = a;
            return a * b;
        }

        static void Main(string[] args)
        {
            Console.Write("수를 입력하세요 : ");
            string input = Console.ReadLine();
            int arg = int.Parse(input);

            Console.WriteLine("결과 :  " + Square(arg));
        }
    }


}
