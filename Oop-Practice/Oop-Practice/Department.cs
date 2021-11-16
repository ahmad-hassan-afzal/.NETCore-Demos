using System;
using System.Collections.Generic;
using System.Text;

namespace Oop_Practice
{
    class Department
    {
        public string Name { get; set; }
        public Department(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return string.Format("Department: {0}", this.Name);
        }
    }
}
