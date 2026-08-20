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

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            var contacts = xmlDoc.GetElementsByTagName("Contact");

            foreach(var contact in contacts)
            {
                var node = (XmlNode) contact;
                var phone = node.Attributes["TelephoneNumber"].Value;
                Console.WriteLine(phone);
            }
        }
    }
}
