using System;

namespace ConsoleApp1
{
    internal class Program
    {
        class Archer
        {
            public string name;
            public int arrow;
            public int bow;
            public float experience;

            public void walk(string walk)
            {
                if (walk == "walk")
                {
                    Console.WriteLine("걸어서 이동 중 입니다");
                }
            }

            public void run(string run)
            {
                if (run == "run")
                {
                    Console.WriteLine("뛰어가는 중입니다");
                }
                walk(run);
            }

            public void go(string go)
            {
                if (go == "go")
                {
                    Console.WriteLine("활 쏘는 중입니다");
                }
            }

            public string fire(string fire)
            {
                if (fire == "fire")
                {
                    Console.WriteLine("필살기!!");
                }
                return fire;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Arrow
            {
                get { return arrow; }
                set { arrow = value; }
            }

            public int Bow
            {
                get { return bow; }
                set { bow = value; }
            }

            public float Experience
            {
                get { return experience; }
                set { experience = value; }
            }
        }


        static void Main(string[] args)
        {
            /*Archer archer = new Archer();

            archer.Name = "강민성";
            archer.Arrow = 100;
            archer.Bow = 100;
            archer.experience = 78.91f;

            string input = Console.ReadLine();

            switch (input)
            {
                case "walk":
                    archer.walk(input);
                    break;
                case "run":
                    archer.run(input);
                    break;
                case "go":
                    archer.go(input);
                    break;
                case "fire":
                    archer.fire(input);
                    break;
                default:
                    Console.WriteLine("바보 ㅎㅎ");
                    break;
            }*/

            int aa = int.Parse(Console.ReadLine());
            double bb = double.Parse(Console.ReadLine());
            Four_A(aa, bb);

        }


        static void Four_A(int a, double b)
        {
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(b - a);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
            Console.WriteLine(b / a);
        }
    }
}
