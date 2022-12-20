using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _20220915
{
    internal class NickName
    {
        private Hashtable names = new Hashtable();

        public string this[string index]
        {
            get => names[index].ToString();
            set => names[index] = value;
        }
    }
}
