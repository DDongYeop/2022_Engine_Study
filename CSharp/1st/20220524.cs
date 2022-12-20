using System;

namespace _2022._05._24
{
    internal class Program
    {
        class Archer
        {
            public string name;
            public int arrow;
            public int bow;
            public float experience;

            private void walk(string walk)
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

            private void go(string go)
            {
                if (go == "go")
                {
                    Console.WriteLine("활 쏘는 중입니다");
                }
            }

            public void fire(string fire)
            {
                if (fire == "fire")
                {
                    Console.WriteLine("특급브브브브ㅡ븝피리리리ㅣㄹ실라라ㅏ라라라ㅏㄹ기.!!");
                }
                go(fire);
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
            Archer archer = new Archer();
            archer.run("run");
            archer.run("walk");
            archer.fire("go");
            archer.fire("fire");

            archer.name = "경동엽";
            archer.arrow = 100;
            archer.bow = 100;
            archer.experience = 78.91f;

            archer.run("run");
            archer.run("walk");
            archer.fire("fire");
            archer.fire("go");
        }



    }
        
 
}
