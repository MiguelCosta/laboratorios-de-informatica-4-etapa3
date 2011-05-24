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

    }
}
