using System;
using Xunit;

namespace Srx.UtilTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal<int>(1 + 2, 3);
        }
    }
}
