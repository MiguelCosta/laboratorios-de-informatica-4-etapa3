using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class DataBaseManagement
    {
        private DataBase _db;
        private Dictionary<string, Dictionary<string, int>> _tableSW;

        /**
         * Constructor default
         * */
        public DataBaseManagement()
        {
            _db = new DataBase();
            _tableSW = new Dictionary<string,Dictionary<string,int>>();
        }

        /**
         * Constructor with parameters
         * */
        public DataBaseManagement(DataBase db, Dictionary<string, Dictionary<string, int>> tableSW)
        {
            _db = db;
            _tableSW = tableSW;
        }

        /**
         * Constructor with Value
         * */
        public DataBaseManagement(DataBaseManagement dbm)
        {
            _db = dbm.DataBase;
            _tableSW = dbm.TableSW;
        }


        public DataBase DataBase
        {
            get { return _db; }
            set { _db = value; }
        }

        public Dictionary<string, Dictionary<string, int>> TableSW
        {
            get { return _tableSW; }
            set { _tableSW = value; }
        }

        public DataBase GetChangableDB()
        {
            return _db;
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void showChangableDB()
        {
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void ValidateChanges()
        {
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void ReadChar()
        {
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void ValidateChar(Characteristic charac)
        {
             //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public void SaveDB()
        {
            //ESTE MÉTODO AINDA NÃO ESTÁ IMPLEMENTADO
        }

        public DataBase NewDataBase(DataBase db)
        {
            //?????
            return new DataBase(db);
        }

        public Dictionary<string, Dictionary<string, int>> filterDB(Dictionary<string, Software> tableSW)
        {
            //ESTE MÉTODO AINDA NÃO FAZ COISAS
            return _tableSW;
        }
        
    }
}
