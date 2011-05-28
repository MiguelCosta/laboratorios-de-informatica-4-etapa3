using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Business
{
    [Serializable()]
    public class DataBaseUser : ISerializable
    {
        private User _user;
        private Dictionary<int, Software> _software_list;
        private Dictionary<int, Characteristic> _charac;

        /**
         * Constructor default
         * */
        public DataBaseUser()
        {
            _user = new User();
            _software_list = new Dictionary<int, Software>();
            _charac = new Dictionary<int, Characteristic>();
        }

        /**
         * Constructor with parameters
         * */
        public DataBaseUser(User user, Dictionary<int, Software> software_list, Dictionary<int, Characteristic> charac)
        {
            _user = user;
            _software_list = software_list;
            _charac = charac;
        }

        /**
         * Constructor with Value
         * */
        public DataBaseUser(DataBaseUser db)
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

        public Dictionary<int, Software> Software_list
        {
            get { return _software_list; }
            set { _software_list = value; }
        }

        public Dictionary<int, Characteristic> Charac
        {
            get { return _charac; }
            set { _charac = value; }
        }

        public void AddSoftware(Software s)
        {
            _software_list.Add(s.Id, s);
        }

        public void RemoveSoftware(int id)
        {
            _software_list.Remove(id);
        }

        public Software ViewSoftware(Software s)
        {
            return s;
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void RemoveChar(int id)
        {
            _charac.Remove(id);
        }

        public void filterDB()
        {
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void saveInObject(String filename)
        {
            Stream stream = File.Open(filename, FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();

            bformatter.Serialize(stream, this);
            stream.Close();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("User", _user);
            info.AddValue("Charac", _charac);
            info.AddValue("Software_List", _software_list);
        }
        

        public string toString()
        {
            StringBuilder s = new StringBuilder("DATA BASE\n");
            s.Append(User.toString());
            s.Append("\n\nSOFTWARES:\n");
            foreach (Software soft in _software_list.Values)
            {
                s.Append(soft.toString());
            }
            s.Append("\n\nCHARACTERISTICS:\n");
            foreach (Characteristic c in _charac.Values)
            {
                s.Append(c.toString());
            }
            return s.ToString();
        }
    }

}
