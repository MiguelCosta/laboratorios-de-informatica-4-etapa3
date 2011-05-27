using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class NumericCharacteristic : Characteristic
    {
        private int _value;

        /**
         * Constructor default
         * */
        public NumericCharacteristic():
            base(0,"") {
                _value = 0;
        }

        /**
         * Constructor with parameters
         * */
        public NumericCharacteristic(int id, string name, int value):
            base(id, name) {
                _value = value;
        }

        /**
         * Constructor with Numeric_Characteristic
         * */

        public NumericCharacteristic(NumericCharacteristic nc) :
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

        public NumericCharacteristic clone()
        {
            return new NumericCharacteristic(this);
        }

        public bool equals(Object o)
        {
            if (this == o) return true;
            if (o == null || o.GetType() != this.GetType()) return false;

            NumericCharacteristic n = (NumericCharacteristic)o;

            if (_id == n.Id && _name.Equals(n.Name) && _value == n.Value) return true;

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
