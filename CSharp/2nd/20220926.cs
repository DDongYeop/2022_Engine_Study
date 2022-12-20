using System;

namespace _20220926
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 날짜 
            DateTime dt;
            string iCanNot = "날짜형으로 변환할 수 없다";

            if (DateTime.TryParse(DateTime.Now.ToString("MM/dd/yyyy"), out dt))
                Console.WriteLine(dt.ToString());
            else
                Console.WriteLine(iCanNot);

            if (DateTime.TryParse(DateTime.Now.ToString("MM/dd/yyyy"), out DateTime mydate))
                Console.WriteLine(mydate.ToString());
            #endregion

            #region 구조체 문제
            Struct s;
            s.id = 10102;
            s.name = "경동엽";
            s.Bday = new DateTime(2007,01,29);

            Console.WriteLine($"학번은 {s.id} 이름은 {s.name} 생일은 {s.Bday}입니다");
            #endregion
        }

        struct Struct
        {
            public int id;
            public string name;
            public DateTime Bday;
        }
    }
}
