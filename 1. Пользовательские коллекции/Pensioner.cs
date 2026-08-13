using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Pensioner : Citizen
    {
        public int PensionAmount { get; set; }

        public Pensioner(string name, string passportNumber, int age, int pensionAmount) : base(name, passportNumber, age)
        {
            PensionAmount = pensionAmount;
        }
    }
}
