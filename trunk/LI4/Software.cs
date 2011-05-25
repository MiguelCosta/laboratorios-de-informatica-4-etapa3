using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class Software
    {
        private string _id;
        private string _name;
        private string _link;
        private Dictionary<String, Characteristic> _charac;

        /**
         * Constructor default
         * */
        public Software()
        {
            _id = "";
            _name = "";
            _link = "";
            _charac = null;
        }

        /**
         * Constructor with parameters
         * */
        public Software(string id, string name, string link, Dictionary<String,Characteristic> charac)
        {
            _id = id;
            _name = name;
            _link = link;
            _charac = charac;
        }

        /**
         * Constructor with Software
         * */
        public Software(Software s)
        {
            _id = s.Id;
            _name = s.Name;
            _link = s.Link;
            _charac = s.Charac;
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

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public Dictionary<String,Characteristic> Charac
        {
            get { return _charac; }
            set { _charac = value; }
        }

        /**
        * Method clone
        * */

        public Software clone()
        {
            return new Software(this);
        }

        public bool equals(Object o)
        {
            if (this == o) return true;
            if (o == null || o.GetType() != this.GetType()) return false;

            Software s = (Software)o;
            if (_id.Equals(s.Id) && _name.Equals(s.Name) && _link.Equals(s.Link) && _charac.Equals(s.Charac)) return true;

            return false;
        }

        public string toString()
        {
            StringBuilder s = new StringBuilder("Software\n");
            s.Append(_name);
            s.Append("\n");
            s.Append(_id);
            s.Append("\n");
            s.Append(_link);
            return s.ToString();
        }
    }
}
