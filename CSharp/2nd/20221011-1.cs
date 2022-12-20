using System;
using System.Collections.Generic;

namespace _20221011
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 생성자의 매개변수에 인터페이스 사용하기
            Good good = new Good();
            Bad bad = new Bad();

            Car car1 = new Car(good);
            Car car2 = new Car(bad);

            car1.Run();
            car2.Run();
            #endregion


            #region 인터페이스를 사용한 다중 상속 구현하기
            Dog dog = new Dog();

            dog.Eat();
            dog.Yelp();
            #endregion


            #region IComparable 인터페이스사용하기
            List<Product> products = new List<Product>();
            products.Add(new Product() { Price = 1500, Name = "고구마" });
            products.Add(new Product() { Price = 2400, Name = "사과" });
            products.Add(new Product() { Price = 1000, Name = "바나나" });
            products.Add(new Product() { Price = 3000, Name = "배" });

            products.Sort();

            foreach(var item in products)
                Console.WriteLine(item);
            #endregion
        }
    }

    #region 생성자의 매개변수에 인터페이스 사용하기
    class Good : Ibattery
    {
        public string GetName()
        {
            return "Good";
        }
    }

    class Bad : Ibattery
    {
        public string GetName()
        {
            return "Bad";
        }
    }

    internal class Car
    {
        Ibattery _iBattery;

        public Car(Ibattery battery)
        {
            _iBattery = battery;
        }

        public void Run()
        {
            Console.WriteLine(_iBattery.GetName());
        }
    }
    #endregion


    #region 인터페이스를 사용한 다중 상속 구현하기
    class Dog : IAnimal, IDog
    {
        public void Eat()
        {
            Console.WriteLine("먹다");
        }

        public void Yelp()
        {
            Console.WriteLine("짖다");
        }
    }
    #endregion


    #region IComparable 인터페이스사용하기
    class Product : IComparable
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Name} : {Price}원";
        }

        public int CompareTo(object obj)
        {
            return this.Price.CompareTo((obj as Product).Price);
        }
    }
    #endregion
}
