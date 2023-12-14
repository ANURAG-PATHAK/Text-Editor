using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotePadLibrary
{
    public interface ISearchMananger
    {
        string TargetText { get; set; }
        List<string> SearchText { get; set; }
        KeyValuePair<int, int> CurrentLocation { get; set; }
        KeyValuePair<int, int> Find(string targetText);
        KeyValuePair<int, int> FindNext(string targetText);
        List<string> Replace(string targetText, string newText);
        List<string> ReplaceAll(string targetText, string newText);
    }
}