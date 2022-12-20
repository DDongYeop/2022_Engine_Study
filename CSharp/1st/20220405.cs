using System;

namespace _2022._04._05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = char.Parse(Console.ReadLine());


            switch(a)
            {
                case 'A' : 
                    Console.WriteLine("best!!!");
                    break;
                case 'B':
                    Console.WriteLine("good!!");
                    break;
                case 'C':
                    Console.WriteLine("run!");
                    break;
                case 'D':
                    Console.WriteLine("slowly~");
                    break;
                default:
                    Console.WriteLine("what?");
                    break;
            }





            int b = char.Parse(Console.ReadLine());

            switch(b) 
            {
                case '1':
                    Console.WriteLine("dog");
                    break;
                case '2':
                    Console.WriteLine("cat");
                    break;
                case '3':
                    Console.WriteLine("chick");
                    break;
                default :
                    Console.WriteLine("번호가 잘못되었습니다.");
                    break;
            }

            int c = DateTime.Now.Hour;
            Console.WriteLine(c < 12 ? "오전입니다" : "오후입니다");
            
        }
    }
}
