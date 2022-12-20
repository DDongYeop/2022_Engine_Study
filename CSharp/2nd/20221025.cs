using System;

namespace _20221025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 예외처리
            
            int[] array = { 1, 2, 3 };

            try
            {
                Console.WriteLine(array[100]);
            }
            catch
            {
                Console.WriteLine("Compile Error");
            }

            #endregion

            Console.WriteLine();

            #region Exception 클래스를 이용한 예외처리

            try
            {
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());

                x = x / y;

                Console.WriteLine(x);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message + "이거 이상함");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} \n이상ㅎ마 뭔가 많이 고치삼 빠라라빠ㅏㄹ빠라라빠발바라ㅏㅣ라바랍ㄹ");
            }

            #endregion

            Console.WriteLine();

            #region 예외 던지기

            try
            {
                DoSomething(123);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nㅁㅁㅁㅁㅁㅁ");
            }

            #endregion

            Console.WriteLine();

            #region try ~ catch ~ finally

            try
            {
                int divisor = int.Parse(Console.ReadLine());
                int dividend = int.Parse(Console.ReadLine());
                Divide(divisor, dividend);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("과제 끝 \n난 자유다");
            }
            #endregion
        }

        #region 예외 던지기

        public static void DoSomething(int innnt)
        {
            if (innnt < 10)
                Console.WriteLine(innnt);
            else
                throw new Exception("10보다 큼.");
        }

        #endregion


        #region try ~ catch ~ finally

        public static int Divide(int divisor, int dividend)
        {
            try
            {
                return divisor / dividend;
            }
            catch (DivideByZeroException DBZE)
            {
                Console.WriteLine(DBZE.Message + "\n예외 발생. 큰일 ");
                throw new Exception("예외");
            }
            finally
            {
                Console.WriteLine("Divide() 끝");
            }
        }

        #endregion
    }
}
