using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class Numeric_Characteristic : Characteristic
    {
        private int _value;

        public Numeric_Characteristic():
            base("","") {
                _value = 0;
        }

    }
}
