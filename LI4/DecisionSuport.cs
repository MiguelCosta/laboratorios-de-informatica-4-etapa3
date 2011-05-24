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

        public Dictionary<String, Dictionary<String, int>> TableClass
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

        public Dictionary<string, int> registerClass(String idChar, int points) 
        {
            _tableCH.Add(idChar, points);
            return _tableCH;
        }

        public Dictionary<String, Dictionary<String, int>> filter(String idChar) 
        {

            _tableX.Clear(); // ver depois se isto está bem
            Dictionary<String, int> tableAux = new Dictionary<string, int>();
            int valor;
            foreach(String idSof in _tableSW.Keys){
                foreach(Dictionary<String, int> ch in _tableSW.Values){
                    foreach(String idCh in ch.Keys){
                        if (idCh == idChar){
                            ch.TryGetValue(idCh, out valor);
                            tableAux.Add(idSof,valor);
                        }
                    }
                }
            }
            _tableX.Add(idChar,tableAux);
            return _tableX;
        }

        public int calMin() 
        {

            // caso nao se possa na filter fazer clear na tabelaX deve-se meter a calMin a receber como parametro o id da caracteristica
            int min=0;
            int flag = 1;
            foreach (Dictionary<String, int> list in _tableX.Values) 
            {
                foreach (int valor in list.Values) 
                {
                    if (flag == 1)
                    {
                        min = valor;
                        flag = 0;
                    }
                    else 
                    { 
                        if(min>valor)
                        {
                            min = valor;
                        }       
                    }  
                }
            }
            return min;
        }























    }
}
