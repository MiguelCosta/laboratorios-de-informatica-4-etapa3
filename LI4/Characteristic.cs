using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    abstract class Characteristic
    {
        private string _id;
        private string _name;

        /**
         * Constructor default
         * */
        public Characteristic()
        {
            _id = "";
            _name = "";
        }

        /**
         * Constructor with parameters
         * */
        public Characteristic(string id, string name)
        {
            _id = id;
            _name = name;
        }

        /**
         * Constructor with Software
         * */
        public Characteristic(Characteristic c)
        {
            _id = c.Id;
            _name = c.Name;
        }


        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
