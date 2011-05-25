using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class Value
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
        
    }
}
