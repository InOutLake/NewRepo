using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab2
{
    internal class WordHolder
    {
        private string word;
        private bool right;

        public WordHolder(string _word, bool _right)
        {
            word = _word;
            right = _right;
        }
        public string Word
        {
            get { return word; }
        }
        public bool Right
        {
            get { return right; }
        }
    }
}
