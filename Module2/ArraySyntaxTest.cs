using System;
using Xunit;

namespace Module2
{
    public class UnitTest1
    {
        [Fact]
        public void FillAndPrintReadings()
        {
            var readings = ArraySyntax.FillReading(10);
            ArraySyntax.Print(readings);
        }
    }
}