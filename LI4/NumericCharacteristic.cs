using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class Numeric_Characteristic : Characteristic
    {
        private int _value;

        /**
         * Constructor default
         * */
        public Numeric_Characteristic():
            base("","") {
                _value = 0;
        }

        /**
         * Constructor with parameters
         * */
        public Numeric_Characteristic(string id, string name, int value):
            base(id, name) {
                _value = value;
        }

        /**
         * Constructor with Numeric_Characteristic
         * */

        public Numeric_Characteristic(Numeric_Characteristic nc) :
            base(nc.Id, nc.Name) {
            _value = nc.Value;
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        /**
         * Method clone
         * */

        public Numeric_Characteristic clone()
        {
            return new Numeric_Characteristic(this);
        }

        public bool equals(Object o)
        {
            if (this == o) return true;
            if (o == null || o.GetType() != this.GetType()) return false;

            Numeric_Characteristic n = (Numeric_Characteristic)o;

            if (_id.Equals(n.Id) && _name.Equals(n.Name) && _value == n.Value) return true;

            return false;
        }

        public string toString()
        {
            StringBuilder s = new StringBuilder("Characteristic\n");
            s.Append(_name);
            s.Append("\n");
            s.Append(_id);
            s.Append("\n");
            s.Append(_value);
            return s.ToString();
        }
    }
}
