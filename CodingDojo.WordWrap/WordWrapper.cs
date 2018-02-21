using System;
namespace CodingDojo.WordWrap
{
    public class WordWrapper: IWrapper
    {
        public string Wrap(string input, int columns)
        {
            if (String.IsNullOrEmpty(input) || columns <= 0) 
            {
                throw new ArgumentNullException();
            }

            return input;
        }
    }
}
