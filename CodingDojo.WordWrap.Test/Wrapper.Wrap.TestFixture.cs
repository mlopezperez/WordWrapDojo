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

            Assert.Throws<ArgumentException>(() => wrapper.Wrap(input, columns));
        }

        [Test]
        public void Wrap_WhenCalledWithEmptyInput_MustReturnArgException()
        {
            const string input = "";
            const int columns = 0;
            IWrapper wrapper = new WordWrapper();

            Assert.Throws<ArgumentException>(() => wrapper.Wrap(input, columns));
        }

        [Test]
        public void Wrap_WhenCalledWithNegativeColumns_MustReturnArgException()
        {
            const string input = "valid";
            const int columns = -1;
            IWrapper wrapper = new WordWrapper();

            Assert.Throws<ArgumentException>(() => wrapper.Wrap(input, columns));
        }

        [Test]
        public void Wrap_WhenCalledWithZeroColumns_MustReturnArgException()
        {
            const string input = "valid";
            const int columns = 0;
            IWrapper wrapper = new WordWrapper();

            Assert.Throws<ArgumentException>(() => wrapper.Wrap(input, columns));
        }

        [Test]
        public void Wrap_WhenCalledWithAWordSmallerThanColumns_MustReturnTheWord()
        {
            const string input = "Better";
            const int columns = 7;
            IWrapper wrapper = new WordWrapper();

            var result = wrapper.Wrap(input, columns);

            Assert.AreEqual("Better", result);
        }

        [Test]
        public void Wrap_WhenCalledWithAWordWithSameLengthThanColumns_MustReturnTheWord()
        {
            const string input = "Better";
            const int columns = 6;
            IWrapper wrapper = new WordWrapper();

            var result = wrapper.Wrap(input, columns);

            Assert.AreEqual("Better", result);
        }

        [Test]
        public void Wrap_WhenCalledWithAWordBiggerThanColumns_MustReturnProperResult()
        {
            const string input = "Better";
            const int columns = 5;
            IWrapper wrapper = new WordWrapper();

            var result = wrapper.Wrap(input, columns);

            Assert.AreEqual("Bette\nr", result);
        }

        [Test]
        public void Wrap_WhenCalledWithMultipleWordsSmallerThanColumns_MustReturnProperResult()
        {
            const string input = "Better three hours too soon";
            const int columns = 7;
            IWrapper wrapper = new WordWrapper();

            var result = wrapper.Wrap(input, columns);

            Assert.AreEqual("Better\nthree\nhours\ntoo\nsoon", result);
        }

        [Test]
        public void Wrap_WhenCalledWithMultipleWordsWithSameLengthThanColumns_MustReturnProperResult()
        {
            // The longest word has the same length than the column size
            const string input = "Better three hours too soon";
            const int columns = 6;
            IWrapper wrapper = new WordWrapper();

            var result = wrapper.Wrap(input, columns);

            Assert.AreEqual("Better\nthree\nhours\ntoo\nsoon", result);
        }

        [Test]
        public void Wrap_WhenCalledWithMultipleWordsBiggerThanColumns_MustReturnProperResult()
        {
            const string input = "Better three hours too soon than a minute too late.";
            const int columns = 5;
            IWrapper wrapper = new WordWrapper();

            var result = wrapper.Wrap(input, columns);

            Assert.AreEqual("Bette\nr\nthree\nhours\ntoo\nsoon\nthan\na\nminut\ne\ntoo\nlate.", result);
        }
    }
}