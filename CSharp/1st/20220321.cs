using System;

namespace _2022._02._21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.Hour < 2 || 9 < DateTime.Now.Hour);
            Console.WriteLine(14 < DateTime.Now.Hour && DateTime.Now.Hour < 16);


            int age = 17;
            int people = 19;

            Console.WriteLine(age + people);
            Console.WriteLine(age - people);
            Console.WriteLine(age * people);
            Console.WriteLine(age / people);
            Console.WriteLine(age % people);

            char lastname = '경';
            Console.WriteLine(lastname);

            char a = 'a';
            char b = 'b';

            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(a % b);
        }
    }
}




