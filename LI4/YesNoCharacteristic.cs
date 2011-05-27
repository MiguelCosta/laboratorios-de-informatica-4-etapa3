﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class YesNoCharacteristic : Characteristic
    {
        private bool _state;

        /**
         * Constructor default
         * */
        public YesNoCharacteristic():
            base(0,"") {
                _state = false;
        }

        /**
         * Constructor with parameters
         * */
        public YesNoCharacteristic(int id, string name, bool state):
            base(id, name) {
                _state = state;
        }

        /**
         * Constructor with Numeric_Characteristic
         * */

        public YesNoCharacteristic(YesNoCharacteristic nc) :
            base(nc.Id, nc.Name) {
            _state = nc.State;
        }

        public bool State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void setState()
        {
            if (_state) _state = false;
            else _state = true;
        }

        /**
         * Method clone
         * */

        public YesNoCharacteristic clone()
        {
            return new YesNoCharacteristic(this);
        }

        public override string toString()
        {
            StringBuilder s = new StringBuilder("Characteristic\n");
            s.Append(_name);
            s.Append("\n");
            s.Append(_id);
            s.Append("\n");
            s.Append(_state);
            s.Append("\n");
            return s.ToString();
        }



    }
}
