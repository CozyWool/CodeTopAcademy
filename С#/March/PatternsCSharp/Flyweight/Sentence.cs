using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Flyweight
{
    internal class Sentence
    {
        private readonly List<string> _words;
        private Dictionary<int, WordToken> _tokens = new();
        public Sentence(string plainText) 
        { 
            _words = plainText.Split(' ').ToList();
            for (int i = 0; i < _words.Count; i++)
            {
                _tokens[i] = new WordToken();
            }
        }

        public WordToken this[int index] => _tokens[index];

        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _tokens.Count; i++)
            {
                var w = _words[i];
                if (_tokens[i].Capitalize)
                {
                    sb.Append($"{w.ToUpper()} ");
                }
                else
                {
                    sb.Append($"{w} ");
                }
            }

            return sb.ToString();
        }
        public class WordToken
        {
            public bool Capitalize { get; set; }
        }
    }

    
}
