using System;

namespace _20221017
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 추상클래스
            var square = new Square(12);
            Console.WriteLine(square.GetArea());
            #endregion

            #region 추상클래스와 프로퍼티
            var myProduct = new MyProduct(DateTime.Now);
            Console.WriteLine(myProduct.ProductDate());
            #endregion

            #region 인터페이스와 프로퍼티
            NamedValue name = new NamedValue()
            { Name = "경동엽", Value = "ㅁㅁㅁㅁ" };

            Console.WriteLine("{0} : {1}", name.Name, name.Value);
            #endregion
        }
    }

    #region 추상클래스 
    abstract class Shape
    {
        public abstract float GetArea();
    }

    class Square : Shape
    {
        float size;
        public Square(int n) => size = n;
        public override float GetArea() => size * size;
    }
    #endregion


    #region 추상클래스와 프로퍼티
    abstract class Product
    {
        public static int serial;
        public string SerialID;

        abstract public DateTime ProductDate();
    }

    class MyProduct : Product
    {
        DateTime productDate;
        public MyProduct(DateTime DT) => productDate = DT;
        public override DateTime ProductDate() => DateTime.Now;
    }
    #endregion


    #region 인터페이스와 프로퍼티
    interface INamedValue
    {
        String Name { get; }
        String Value { get; }
    }

    class NamedValue : INamedValue
    {
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }
    #endregion
}
