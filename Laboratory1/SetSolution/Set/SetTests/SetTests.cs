using System.Collections.Generic;
using Xunit;

namespace SetTests
{
    public class SetTests
    {
        [Fact]
        public void CheckIfEmpty_AddElement_ReturnsFalse()
        {
            var sut = new Set.Set();
            sut.InsertElement(1);
            Assert.False(sut.IsEmpty());
        }

        [Fact]
        public void CheckIfEmpty_EmptySet_ReturnsTrue()
        {
            var sut = new Set.Set();
            Assert.True(sut.IsEmpty());
        }

        [Fact]
        public void GetRandomElement_EmptySet_ReturnMinusOne()
        {
            var sut = new Set.Set();
            Assert.Equal(-1, sut.ReturnRandomElement());
        }

        [Fact]
        public void GetRandomElement_NonEmptySet_ReturnRandom()
        {
            var sut = new Set.Set();
            sut.InsertElement(1);
            Assert.NotEqual(-1, sut.ReturnRandomElement());
        }

        [Fact]
        public void ContainsElement_DoesNotContain_ReturnsFalse()
        {
            var sut = new Set.Set();
            sut.InsertElement(1);
            Assert.False(sut.ContainsElement(2));
        }

        [Fact]
        public void ContainsElement_ContainsElement_ReturnsTrue()
        {
            var sut = new Set.Set();
            var element = 1;
            sut.InsertElement(element);
            Assert.True(sut.ContainsElement(element));
        }

        [Fact]
        public void CountEvenElement_EmptySet_ReturnsZero()
        {
            var sut = new Set.Set();
            Assert.Equal(0, sut.GetEvenElementsCount());
        }

        [Fact]
        public void CountEvenElement_NoEvenNumbers_ReturnsZero()
        {
            var sut = new Set.Set();
            sut.InsertElement(3);
            sut.InsertElement(5);
            sut.InsertElement(7);
            Assert.Equal(0, sut.GetEvenElementsCount());
        }

        [Fact]
        public void CountEvenElement_ContainsEvenNumbers_ReturnsCount()
        {
            var sut = new Set.Set();
            sut.InsertElement(2);
            sut.InsertElement(4);
            sut.InsertElement(6);
            Assert.Equal(3, sut.GetEvenElementsCount());
        }

        [Fact]
        public void InsertElement_SingleElementToEmptySet_OneElementInSet()
        {
            var sut = new SetT();
            sut.InsertElement(2);
            Assert.Equal(new List<int> {2}, sut.ReturnValues());
        }

        [Fact]
        public void InsertElement_SameElementsToEmptySet_OneElementInSet()
        {
            var sut = new SetT();
            sut.InsertElement(2);
            sut.InsertElement(2);
            sut.InsertElement(2);
            Assert.Equal(new List<int> {2}, sut.ReturnValues());
        }

        [Fact]
        public void InsertElement_MultipleElementsToEmptySet_SeveralElementsInSet()
        {
            var sut = new SetT();
            sut.InsertElement(2);
            sut.InsertElement(3);
            sut.InsertElement(4);
            Assert.Equal(new List<int> {2, 3, 4}, sut.ReturnValues());
        }

        [Fact]
        public void RemoveElement_NonExistentElement_DoNothing()
        {
            var sut = new SetT();
            sut.InsertElement(2);
            sut.InsertElement(3);
            sut.InsertElement(4);
            sut.RemoveElement(5);
            Assert.Equal(new List<int> {2, 3, 4}, sut.ReturnValues());
        }

        [Fact]
        public void RemoveElement_ElementExistsInSet_RemovedFromSet()
        {
            var sut = new SetT();
            sut.InsertElement(2);
            sut.InsertElement(3);
            sut.InsertElement(4);
            sut.RemoveElement(4);
            Assert.Equal(new List<int> {2, 3}, sut.ReturnValues());
        }

        [Fact]
        public void StressTest()
        {
            var sut = new SetT();
            for (var i = 0; i < 10000; i++)
            {
                sut.InsertElement(i);
            }

            Assert.Equal(10000, sut.ReturnValues().Count);
        }

        private class SetT : Set.Set
        {
            public List<int> ReturnValues()
            {
                return values;
            }
        }
    }
}