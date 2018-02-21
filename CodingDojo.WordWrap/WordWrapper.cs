using System;
using System.Text;

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

            var builder = new StringBuilder();
            var words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in words)
            {
                builder.Append(word);
                builder.AppendLine();
            }


            var outputWithEndingLineTerminator = builder.ToString();
            return outputWithEndingLineTerminator.Substring(0, outputWithEndingLineTerminator.Length - 1);
        }
    }
}
