using System;

namespace _20221031
{
    internal class Program
    {
        #region 대리 호출의 다양한 방법
        delegate void SayDelegate();
        #endregion

        #region 대리자 선언 및 사용
        delegate int Mydelegate(int x, int y);
        #endregion

        static void Main(string[] args)
        {
            #region 대리 호출의 다양한 방법
            SayDelegate say = Hi;
            say?.Invoke();

            SayDelegate hi = new SayDelegate( Hi );
            hi?.Invoke();
            #endregion


            #region 대리자 선언 및 사용
            Calculator Calc = new Calculator();
            Mydelegate Callback;

            Callback = new Mydelegate(Calc.Plus);
            Console.WriteLine(Callback(3, 4));

            Callback = new Mydelegate(Calculator.Minus);
            Console.WriteLine(Callback(7, 5));
            #endregion

        }

        #region 대리 호출의 다양한 방법
        public static void Hi()
        {
            Console.WriteLine("안녕하세요 반갑읍니다 C#의 세계로 오신걸 환영해요.\n젯브레인 라이더 설치하시면 되겠습니다\n");
        }
        #endregion

    }

    #region 대리자 선언 및 사용
    class Calculator
    {
        public int Plus(int x, int y)
        {
            return x + y;
        }

        public static int Minus(int x, int y)
        {
            return x - y;
        }
    }
    #endregion
}
