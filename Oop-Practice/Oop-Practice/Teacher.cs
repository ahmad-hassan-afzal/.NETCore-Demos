using System;
using System.Collections.Generic;
using System.Text;

namespace Oop_Practice
{
    class Teacher
    {
        public string Name { get; set; }
        public Teacher(string name, Department department)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return string.Format("{0}\n{1}", this.Name);
        }
    }
}
