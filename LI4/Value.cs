using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Value
    {
        private string _name;
        private int _classification;


        /**
         * Constructor default
         * */
        public Value()
        {
            _name = "";
            _classification = 0;
        }

        /**
         * Constructor with parameters
         * */
        public Value(string name, int classification)
        {
            _name = name;
            _classification = classification;
        }

        /**
         * Constructor with Value
         * */
        public Value(Value v)
        {
            _name = v.Name;
            _classification = v.Classification;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Classification
        {
            get { return _classification; }
            set { _classification = value; }
        }

        /**
         * Method clone
         * */
        public Value clone()
        {
            return new Value(this);
        }

        public bool equals(Object o)
        {
            if (this == o) return true;
            if (o == null || o.GetType() != this.GetType()) return false;

            Value n = (Value)o;

            if (_name.Equals(n.Name) && _classification == n.Classification) return true;

            return false;
        }

        public string toString()
        {
            StringBuilder s = new StringBuilder("Value\n");
            s.Append(_name);
            s.Append("\n");
            s.Append(_classification);
            return s.ToString();
        }

    }
}
