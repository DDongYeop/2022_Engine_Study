using System;
using System.Threading;

namespace _20220512
{
    internal class Program
    {
        class Archer
        {
            string name;
            int arrow;
            int bow;
            float experience;
            public static int count;
            int id;

            

            public Archer(string name, int arrow, int bow, float experience)
            {
                if(name == null)
                    Console.WriteLine("잘못된 값입니다");
                else
                    this.name = name;

                if(arrow <= 0)
                    Console.WriteLine("잘못 다시");
                else
                    this.arrow = arrow;

                if (bow <= 0)
                    Console.WriteLine("잘못 다시");
                else
                    this.bow = bow;

                if (experience <= 0)
                    Console.WriteLine("잘못 다시");
                else
                    this.experience = experience;
            }

            ~Archer()
            {
                Console.WriteLine(DateTime.Now + "에서 소멸자 호출됨");
            }
        }

        class Marathon
        {
            public const double distance = 42.195;
        }

        static void Main(string[] args)
        {

            Test();
            GC.Collect();
            Thread.Sleep(1000);

            Console.WriteLine(Marathon.distance);
        }

        static void Test()
        {
            Archer archer1 = new Archer("강민성" , 9457487 , 4587427 , 49.49873f);
        }
    }
}
