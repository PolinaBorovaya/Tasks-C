using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLevel
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple =
        false)]
    public class AccessLevelAttribute : Attribute
    {
        public enum AccessLevel
        {
            None = 0,
            ReadOnly = 1,
            ReadWrite = 2,
            FullAccess = 3
        }

        public AccessLevel Level { get; }
        public string Description { get; set; }

        public AccessLevelAttribute(AccessLevel level)
        {
            Level = level;
        }
    }
}
