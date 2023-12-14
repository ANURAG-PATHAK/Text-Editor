using System.Text;
using System;
using NotePadLibrary.Properties;

namespace NotePadLibrary
{
    public class SearchManager : ISearchMananger
    {
        public bool IsCaseMatched { get; set; }
        public int Find(string sourceText, string targetText)
        {
            for (int sourceTextIndex = 0; sourceTextIndex < sourceText.Length; sourceTextIndex++)
            {
                if (string.Compare(targetText, sourceText.Substring(sourceTextIndex, targetText.Length), !IsCaseMatched) == 0)
                {
                    return sourceTextIndex;
                }

            }
            return -1;
        }
        public int FindNext(string sourceText, string targetText, int startIndex)
        {
            for (int sourceTextIndex = startIndex + targetText.Length; sourceTextIndex < sourceText.Length; sourceTextIndex++)
            {
                if (string.Compare(targetText, sourceText.Substring(sourceTextIndex, targetText.Length), !IsCaseMatched) == 0)
                {
                    return sourceTextIndex;
                }
            }
            return -1;
        }
        public string Replace(string sourceText, string targetText, string newText, int startIndex)
        {
            int targetTextStart;
            if (string.Compare(targetText, sourceText.Substring(startIndex, targetText.Length), !IsCaseMatched) == 0)
            {
                targetTextStart = startIndex;
            }
            else
            {
                targetTextStart = FindNext(sourceText, targetText, startIndex);
            }
            if (targetTextStart >= 0)
            {
                StringBuilder text = new StringBuilder();
                text.Append(sourceText.Substring(0, targetTextStart));
                text.Append(newText);
                text.Append(sourceText.Substring(targetTextStart + targetText.Length));
                return text.ToString();
            }
            else
            {
                throw new Exception(Resources.ReplaceException);
            }

        }
        public string ReplaceAll(string sourceText, string targetText, string newText)
        {
            if (sourceText.Contains(targetText))
            {
                int lastLocation = -1;
                int loopTime = sourceText.Length;
                while (lastLocation < loopTime)
                {
                    lastLocation = FindNext(sourceText, targetText, lastLocation);
                    if (lastLocation >= 0)
                    {
                        StringBuilder text = new StringBuilder();
                        text.Append(sourceText.Substring(0, lastLocation));
                        text.Append(newText);
                        text.Append(sourceText.Substring(lastLocation + targetText.Length));
                        sourceText = text.ToString();
                        lastLocation += newText.Length;
                        loopTime = sourceText.Length;
                    }
                    else
                    {
                        break;
                    }

                }
                return sourceText;
            }
            else
            {
                throw new Exception(Resources.ReplaceException);
            }
        }
    }
}