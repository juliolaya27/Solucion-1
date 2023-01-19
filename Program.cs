using RefactorizacionEjercicio1;
using System;
using System.Text;

namespace RefactorizacionEjercicio1
{


   
    public static class LineAdjuster
    {
        public static string AdjustLines(string input, int lineLength)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            var words = input.Split(' ');
            var output = new StringBuilder();
            var currentLineLength = 0;

            foreach (var word in words)
            {
                if (word.Length > lineLength)
                {
                    // if word is longer than lineLength, insert newlines in the middle of the word
                    var parts = SplitWord(word, lineLength);
                    foreach (var part in parts)
                    {
                        output.Append(part);
                        output.Append(Environment.NewLine);
                        currentLineLength = 0;
                    }
                }
                else
                {
                    var spaceNeeded = lineLength - currentLineLength;
                    if (word.Length + 1 <= spaceNeeded)
                    {
                        //if word length and a space can fit on current line
                        output.Append(word);
                        output.Append(" ");
                        currentLineLength += word.Length + 1;
                    }
                    else
                    {
                        // if word can't fit on current line with a space
                        output.Append(Environment.NewLine);
                        output.Append(word);
                        output.Append(" ");
                        currentLineLength = word.Length + 1;
                    }
                }
            }
            return output.ToString();
        }

        private static IEnumerable<string> SplitWord(string word, int lineLength)
        {
            for (var i = 0; i < word.Length; i += lineLength)
            {
                yield return word.Substring(i, Math.Min(lineLength, word.Length - i));
            }
        }


        static void Main(string[] args)
        {
            string input = "hola mundo j¿hola mundo";
            int lineLength = 8;

            Console.WriteLine(LineAdjuster.AdjustLines(input, lineLength));
            Console.ReadLine();
        }
    }


    
}



