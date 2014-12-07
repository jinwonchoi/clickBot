using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickBot.ValueObject
{
    class ComboPair
    {
        public ComboPair(string _key, string _val)
        {
            key = _key;
            val = _val;
        }

        string key;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        string val;
        public string Val
        {
            get { return val; }
            set { val = value; }
        }

        public override string ToString()
        {
            return string.Format("{1}({0})",key, val);
        }
    }
}
