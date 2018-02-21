using System;
using NUnit.Framework;

namespace CodingDojo.WordWrap.Test
{
    [TestFixture]
    public class WrapTestFixture
    {
        [Test]
        public void Wrap_WhenCalledWithNullInput_MustReturnArgException()
        {
            const string input = null;
            const int columns = 0;
            IWrapper wrapper = new WordWrapper();

            Assert.Throws<ArgumentNullException>(() => wrapper.Wrap(input, columns));
        }

        [Test]
        public void Wrap_WhenCalledWithEmptyInput_MustReturnArgException()
        {
            const string input = "";
            const int columns = 0;
            IWrapper wrapper = new WordWrapper();

            Assert.Throws<ArgumentNullException>(() => wrapper.Wrap(input, columns));
        }

        [Test]
        public void Wrap_WhenCalledWithNegativeColumns_MustReturnArgException()
        {
            const string input = "valid";
            const int columns = -1;
            IWrapper wrapper = new WordWrapper();

            Assert.Throws<ArgumentNullException>(() => wrapper.Wrap(input, columns));
        }
    }
}