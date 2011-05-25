using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class DataBase
    {
        private User _user;
        private Dictionary<string, Software> _software_list;
        private Dictionary<string, Characteristic> _charac;

        /**
         * Constructor default
         * */
        public DataBase()
        {
            _user = new User();
            _software_list = new Dictionary<string,Software>();
            _charac = new Dictionary<string,Characteristic>();
        }

        /**
         * Constructor with parameters
         * */
        public DataBase(User user, Dictionary<string,Software> software_list, Dictionary<string,Characteristic> charac)
        {
            _user = user;
            _software_list = software_list;
            _charac = charac;
        }

        /**
         * Constructor with Value
         * */
        public DataBase(DataBase db)
        {
            _user = db.User;
            _software_list = db.Software_list;
            _charac = db.Charac;
        }

        public User User
        {
            get { return _user; }
            set { _user = value; }
        }

        public Dictionary<string,Software> Software_list
        {
            get { return _software_list; }
            set { _software_list = value; }
        }

        public Dictionary<string, Characteristic> Charac
        {
            get { return _charac; }
            set { _charac = value; }
        }

        public void AddSoftware(Software s)
        {
            _software_list.Add(s.Id, s);
        }

        public void RemoveSoftware(string id)
        {
            _software_list.Remove(id);
        }

        public Software ViewSoftware(Software s)
        {
            return s;
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void RemoveChar(string id)
        {
            _charac.Remove(id);
        }

        public void filterDB()
        {
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }
    }

}
