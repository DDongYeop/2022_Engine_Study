using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221004
{
    internal interface IPerson
    {
        class Developer : IPerson
        {
            public void Work()
            {
                Console.WriteLine("개미는 뚠뚠 오늘도 뚠뚠 열심히 일을 하네 뚠뚠");
            }
        }

        class Art : IPerson
        {
            public void Work()
            {
                Console.WriteLine("민성이는 뚠뚠 어제도 뚠뚠 에셋을 만드네 뚠뚠");
            }
        }

        class ProjectManager : IPerson
        {
            public void Work()
            {
                Console.WriteLine("현웅이는 뚠뚠 어제도 뚠뚠 프로젝트를 기획하네 뚠뚠");
            }
        }
    }
}
