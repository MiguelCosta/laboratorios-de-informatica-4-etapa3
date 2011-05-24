using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LI4
{
    class DecisionSuport
    {
        private Dictionary<String, int> _tableCH;
        private Dictionary<String, Dictionary<String, int>> _tableSW;
        private Dictionary<String, Dictionary<String, int>> _tableX;
        private Dictionary<String, Dictionary<String, int>> _tableClass;
        private Dictionary<String, float> _tablePrior;
        private Dictionary<String, Dictionary<String, float>> _tableResult;

        public DecisionSuport() 
        {
            _tableCH = new Dictionary<string, int>();
            _tableSW = new Dictionary<string, Dictionary<string,int>>();
            _tableX = new Dictionary<string,Dictionary<string,int>>();
            _tableClass = new Dictionary<string, Dictionary<string, int>>();
            _tablePrior = new Dictionary<string, float>();
            _tableResult = new Dictionary<string, Dictionary<string, float>>();
        }


        /* Métodos get e set */
        public Dictionary<String, int> TableCH 
        {
            get { return _tableCH; }
            set { _tableCH = value; } 
        }

        public Dictionary<String, Dictionary<String, int>> TableSW 
        {
            get { return _tableSW;}
            set { _tableSW = value;}
        }

        public Dictionary<String, Dictionary<String, int>> TableX
        {
            get { return _tableX; }
            set { _tableX = value; }
        }

        public Dictionary<String, Dictionary<String, int>> TableClas
        {
            get { return _tableClass; }
            set { _tableClass = value; }
        }

        public Dictionary<String, float> TablePrior
        {
            get { return _tablePrior; }
            set { _tablePrior = value; }
        }

        public Dictionary<string, Dictionary<string, float>> TableResult 
        {
            get { return _tableResult; }
            set { _tableResult = value; }
        }
    
    
    
    }
}
