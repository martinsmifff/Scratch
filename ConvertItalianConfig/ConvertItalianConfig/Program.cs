using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConvertItalianConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\DJConfigs\\DJItalian.xml");

            XmlNode requiredNode = xmlDoc.SelectSingleNode("//array[@name='replaceCodeStrings']");


            using (StreamWriter sw = new StreamWriter("C:\\ItalianConfig.txt"))
            {
                foreach (XmlNode codeNode in requiredNode.ChildNodes)
                {
                    sw.WriteLine("<Setting setting=\"{0}\"  string=\"{1}\" />", codeNode.Attributes["name"].Value.Replace("{", "").Replace("}", "").Trim(),
                                                                                codeNode.InnerText.Replace("{", "").Replace("}", "").Trim());
                }
            }
            Console.ReadLine();

        }
    }
}