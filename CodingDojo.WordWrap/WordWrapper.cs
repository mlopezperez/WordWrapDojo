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

            var result = string.Empty;
            var words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length > 1)
            {
                var builder = new StringBuilder();
                foreach (var word in words)
                {
                    if (word.Length > columns)
                    {
                        var splittedWord = SplitWordByFixedColumnSize(word, columns);
                        builder.Append(splittedWord);
                    }
                    else
                    {
                        builder.Append(word);    
                    }
                    builder.AppendLine();
                }

                var outputWithEndingLineTerminator = builder.ToString();
                result = outputWithEndingLineTerminator.Substring(0, outputWithEndingLineTerminator.Length - 1);
            }
            else
            {
                var firstWord = words[0];
                if (firstWord.Length > columns)
                {
                    result = SplitWordByFixedColumnSize(firstWord, columns);
                }
                else 
                {
                    result = firstWord;
                }
            }

            return result;
        }

        private string SplitWordByFixedColumnSize(string word, int columns)
        {
            if (word.Length <= columns)
            {
                return word;
            }

            var builder = new StringBuilder();
            for (var i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];
                builder.Append(currentChar);
                if ((i+1) % columns == 0)
                {
                    builder.AppendLine();
                }
            }
            return builder.ToString();
        }
    }
}
