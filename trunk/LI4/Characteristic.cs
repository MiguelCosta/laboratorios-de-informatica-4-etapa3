using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public abstract class Characteristic
    {
        protected int _id;
        protected string _name;

        /**
         * Constructor default
         * */
        public Characteristic()
        {
            _id = 0;
            _name = "";
        }

        /**
         * Constructor with parameters
         * */
        public Characteristic(int id, string name)
        {
            _id = id;
            _name = name;
        }

        /**
         * Constructor with Characteristic
         * */
        public Characteristic(Characteristic c)
        {
            _id = c.Id;
            _name = c.Name;
        }


        public int Id
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
