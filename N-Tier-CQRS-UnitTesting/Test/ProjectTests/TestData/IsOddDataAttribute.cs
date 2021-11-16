using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Test.ProjectTests.TestData
{
    class IsOddDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            //yield return new Object[] { 1, true };
            //yield return new Object[] { 15, true };
            //yield return new Object[] { 22, false };
            //yield return new Object[] { 1234, false };

            // -- We can also get values from External Source (i.e. txt, csv, database etc)
            var allLines = System.IO.File.ReadAllLines("IsOddTestData.txt");
            return allLines.Select(x =>
            {
                var lineSplit = x.Split(",");
                return new object[] { int.Parse(lineSplit[0]), bool.Parse(lineSplit[1]) };
            });
        }
    }
}
