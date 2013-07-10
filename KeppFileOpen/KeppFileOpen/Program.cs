using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeppFileOpen
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("C:\\MFDJIn\\Test.xml"))
            {
                using (StreamReader sr = new StreamReader("C:\\MFDJIn\\Save\\MFDJSample.xml")) 
                {
                    sw.Write(sr.ReadToEnd());
                }
                Console.ReadLine();
            }
        }
    }
}
