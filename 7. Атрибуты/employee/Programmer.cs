using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLevel
{
    [AccessLevelAttribute(AccessLevelAttribute.AccessLevel.ReadWrite, Description ="доступ на чтение и запись")]
    public class Programmer : Employee
    {
        public Programmer(string name) : base(name, "Программист") { }

        public override void Work()
        {
            Console.WriteLine($"💻 {Name} пишет код");
        }
    }
}
