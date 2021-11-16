using System;
using System.Collections.Generic;
using System.Text;

namespace Oop_Practice
{
    static class ExtensionToSomeClass
    {
        //        This class is Extension to SomeClass
        //        Add (this ClassName objectName) to the method needed to extend
        public static void method4(this SomeClass s) 
        { 
            Console.WriteLine("Whatever 4"); 
        }
        public static void method5(this SomeClass s) 
        { 
            Console.WriteLine("Whatever 5"); 
        }
    }
}
