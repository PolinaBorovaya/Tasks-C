using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "TelephoneBook.xml";

            if(!File.Exists(path))
            {
                Console.WriteLine("Такого файла не существует");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNodeList contscts = xmlDoc.GetElementsByTagName("Contact");

            foreach(XmlNode contact in contscts)
            {
                string phone = contact.Attributes["TelephoneNumber"].Value;
                Console.WriteLine(phone);
            }
        }
    }
}
