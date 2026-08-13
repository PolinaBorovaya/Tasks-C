using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLevel
{
    [AccessLevelAttribute(AccessLevelAttribute.AccessLevel.FullAccess, Description ="полный доступ для менеджера")]
    public class Manager : Employee
    {
        public Manager(string name) : base(name, "Менеджер") { }

        public override void Work()
        {
            Console.WriteLine($"{Name} управляет командой");
        }
    }
}
