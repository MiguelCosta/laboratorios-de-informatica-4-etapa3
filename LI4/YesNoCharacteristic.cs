﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class YesNo_Characteristic : Characteristic
    {
        private Boolean _state;

        /**
         * Constructor default
         * */
        public YesNo_Characteristic():
            base("","") {
                _state = false;
        }

        /**
         * Constructor with parameters
         * */
        public YesNo_Characteristic(string id, string name, boolean state):
            base(id, name) {
                _state = state;
        }

        /**
         * Constructor with Numeric_Characteristic
         * */

        public YesNo_Characteristic(YesNo_Characteristic nc) :
            base(nc.Id, nc.Name) {
            _state = nc.State;
        }

        public Boolean State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void setState()
        {
            if (_state) _state = false;
            else _state = true;
        }


    }
}
