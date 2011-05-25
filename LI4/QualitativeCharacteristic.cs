using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class Qualitative_Characteristic : Characteristic
    {
        private Dictionary<string, Value> _values;

        /**
         * Constructor default
         * */
        public Qualitative_Characteristic():
            base("","") {
                _values = new Dictionary<string,Value>();
        }

        /**
         * Constructor with parameters
         * */
        public Qualitative_Characteristic(string id, string name, Dictionary<string, Value> values):
            base(id, name) {
                _values = values;
        }

        /**
         * Constructor with Qualitative_Characteristic
         * */

        public Qualitative_Characteristic(Qualitative_Characteristic nc) :
            base(nc.Id, nc.Name) {
            _values = nc.Values;
        }

        public Dictionary<string, Value> Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public void addValue(Value v)
        {
            _values.Add(v.Name, v);
        }

        /**
         * Method clone
         * */
        public Qualitative_Characteristic clone()
        {
            return new Qualitative_Characteristic(this);
        }

        public bool equals(Object o)
        {
            if (this == o) return true;
            if (o == null || o.GetType() != this.GetType()) return false;

            Qualitative_Characteristic n = (Qualitative_Characteristic)o;

            if (_id.Equals(n.Id) && _name.Equals(n.Name) && _values.Equals(n.Values)) return true;

            return false;
        }

        public string toString()
        {
            StringBuilder s = new StringBuilder("Characteristic\n");
            s.Append(_name);
            s.Append("\n");
            s.Append(_id);
            s.Append("\n");
            return s.ToString();
        }
    }
}
