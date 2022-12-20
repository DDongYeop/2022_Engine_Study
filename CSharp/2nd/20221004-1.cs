using System;

namespace _20221004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 내장형 구조체 사용
            Guid guid = Guid.NewGuid();
            string unique;

            unique = guid.ToString();
            Console.WriteLine(unique);
            #endregion

            #region 인터페이스 상소과 메서드 구현
            IPerson.Developer d = new IPerson.Developer();
            IPerson.Art a = new IPerson.Art();
            IPerson.ProjectManager p = new IPerson.ProjectManager();

            d.Work();
            a.Work();
            p.Work();
            #endregion
        }
    }
}
