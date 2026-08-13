using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLevel
{
    [AccessLevelAttribute(AccessLevelAttribute.AccessLevel.FullAccess, Description = "полный доступ")]
    public class Director : Employee
    {
        public Director(string name) : base(name, "Директор") { }

        public override void Work()
        {
            Console.WriteLine($"{Name} управляет компанией");
        }
    }
}
