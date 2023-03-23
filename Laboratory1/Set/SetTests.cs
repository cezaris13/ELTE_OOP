using System;
using Xunit;
using Set;

namespace DiagTest
{
    public class SetTests
    {
        [Fact]
        public void Insert_AddOneElementToEmptySet_ShouldBeOneElement()
        {
            var sut = new Set();
            sut.Insert(12);

            Assert.Equals(sut.Print(),"{12}");
        }
    }
}
