using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyPractise.Oops
{
    public class ChildClass : BaseClass
    {
        public ChildClass(string name) : base(name)
        {

        }

        private static object _lock = new object();
        public void MyFun()
        {
            lock(_lock )
            {
                //Logic
            }

            Func<int, int, int> cc = delegate (int x, int y)
            {
                return x + y;
            };


            cc(5, 8);
        }
    }
}
