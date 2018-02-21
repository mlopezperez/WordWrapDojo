using System;
namespace CodingDojo.WordWrap
{
    public class WordWrapper: IWrapper
    {
        public string Wrap(string input, int columns)
        {
            if (String.IsNullOrEmpty(input)) 
            {
                throw new ArgumentNullException();
            }
            return input;
        }
    }
}
