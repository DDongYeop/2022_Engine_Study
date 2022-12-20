using System;
using System.Collections.Generic;

namespace _20221220
{
    internal class Program
    {
        #region 1. 식 형식의 람다식

        delegate int Area(int x, int y);
        delegate void Line();
        delegate double ClacMethod(double x, double y);

        #endregion

        #region 2. 문 형식의 람다식

        delegate string Concatenate(string[] str);

        #endregion

        #region 3. 식과 문 형식의 람다식

        public delegate bool IsTeenAger(Student student);
        public delegate bool IsAdult(Student student);

        #endregion

        static void Main(string[] args)
        {
            #region 1. 식 형식의 람다식

            Area square = (x, y) => x * y;
            Console.WriteLine(square(3, 4));

            Line line = () => Console.WriteLine();
            line();

            ClacMethod add = (x, y) => x + y;
            ClacMethod sub = (x, y) => x - y;
            Console.WriteLine(add(25, 10));
            Console.WriteLine(sub(25, 10));

            #endregion

            line();

            #region 2. 문 형식의 람다식

            Concatenate concat = (arr) =>
            {
                string result= "";
                foreach (string str in arr)
                    result += str;
                return result;
            };
            string[] arr = { "one", "two", "three" };
            Console.WriteLine(concat(arr));

            #endregion

            line();

            #region 3. 식과 문 형식의 람다식

            IsTeenAger isTeen = (student) => student.Age > 12 && student.Age < 20;

            Student S1 = new Student();
            S1.Name = "경동엽";
            S1.Age = 17;
            if (isTeen(S1))
                Console.WriteLine(S1.Name + "은 청소년입니다.");
            else
                Console.WriteLine(S1.Name + "은 청소년이 아닙니다.");

            IsAdult isAdult = (student) =>
            {
                if (student.Age >= 20)
                    return true;
                return false;
            };

            Student S2 = new Student();
            S2.Name = "ㅁㅁㅁ";
            S2.Age = 22;
            if (isAdult(S2))
                Console.WriteLine(S2.Name + "은 성인입니다.");
            else
                Console.WriteLine(S2.Name + "은 성인이 아닙니다.");

            #endregion

            line();

            #region 4. Func 대리자

            int[] arrr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Func<int, bool> f = (int i) =>
            {
                return i % 2 == 0;
            };
            Func<int, bool> o = (int i) =>
            {
                return i % 2 != 0;
            };
            int n = Count(arrr, o);
            n = Count(arrr, f);
            Console.WriteLine($"짝수 갯수 : {n}개");
            Console.WriteLine($"홀수 갯수 : {n}개");

            #endregion
        }

        #region 4. Func 대리자

        static int Count(int[] ints, Func<int, bool> func)
        {
            int cnt = 0;
            for (int i = 0; i < ints.Length; i++)
            {
                if (func(i))
                {
                    cnt++;
                }
            }
            return cnt;
        }

        #endregion
    }

    #region 3. 식과 문 형식의 람다식

    class Student
    {
        public string Name { get; set; }
        public int Age{ get; set; }
    }

    #endregion
}


// Action 대리자 : 반환값이 없는 메서드를 대신 호출
// Func 대리자 : 매개변수와 반환값이 있는 메서드를 대신 호출
// Predicate 대리자 : T 매개변수에 대한 bool 값을 반환하는 메서드를 대신 호출
