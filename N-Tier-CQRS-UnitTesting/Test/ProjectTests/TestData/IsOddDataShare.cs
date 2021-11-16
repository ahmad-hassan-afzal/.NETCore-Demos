using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.ProjectTests.TestData
{
    public static class IsOddDataShare
    {
        public static IEnumerable<object[]>  IsEvenOddData 
        { 
            get 
            {
                yield return new Object[] { 1, true };
                yield return new Object[] { 15, true };
                yield return new Object[] { 22, false };
                yield return new Object[] { 1234, false };

            }
        }
        
        // -- We can also get values from External Source (i.e. txt, csv, database etc)
        public static IEnumerable<object[]> IsEvenOddExternalData
        {
            get
            {
                var allLines = System.IO.File.ReadAllLines("IsOddTestData.txt");
                return allLines.Select(x =>
                {
                    var lineSplit = x.Split(",");
                    return new object[] { int.Parse(lineSplit[0]), bool.Parse(lineSplit[1]) };
                });

            }
        }
    }
}
