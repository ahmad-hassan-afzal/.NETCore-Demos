using System;
using System.Collections.Generic;
using System.Text;

namespace Oop_Practice
{
    public partial class PartialClass
    {
        private int FirstValue;
        private int SecondValue;

        public int FirstValue1 { get => FirstValue; set => FirstValue = value; }
        public int SecondValue1 { get => SecondValue; set => SecondValue = value; }
    }
}
