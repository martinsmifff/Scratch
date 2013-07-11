using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestForAndy
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("C:\\Andy.xml");
            XmlNode n = xml.SelectSingleNode("//OtherInfo");

            string t = n.InnerText;
            Console.WriteLine(t);

            t = t.Replace("<br />", "~").Replace("<br/>", "~");

            string[] pairs = t.Split('~');

            foreach (string p in pairs)
            {
                string[] s = p.Split('|');

                Console.WriteLine("{0} - {1}", s[0], s[1]);
            }



            Console.ReadLine();

        }
    }
}
