using System;
using NUnit.Framework;

namespace Module2
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void FillAndPrintReadings()
        {
            var readings = ArraySyntax.FillReading(10);
            ArraySyntax.Print(readings);
        }
    }
}