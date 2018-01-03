using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflexs
{
    class Class1
    {
         string name;
         int number;
         string stock;
         public string filed="mm";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int Number
        {
            get { return number; }
            set { number = value; }
        }


        public string Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public Class1()
        {
            Console.WriteLine("bb");
        }
        public Class1(string name1)
        {
            Console.WriteLine(name1);
        }
        public Class1(string name2, int name3)
        {
            Console.WriteLine("success");
        }
        public void SS()
        {
            Console.WriteLine("dd");
        }
    }
}
