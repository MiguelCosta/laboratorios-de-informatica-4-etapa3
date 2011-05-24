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
        
        private Dictionary<String, Dictionary<String, float>> _tableResult;

        public DecisionSuport() 
        {
            _tableCH = new Dictionary<string, int>();
            _tableSW = new Dictionary<string, Dictionary<string,int>>();
            _tableX = new Dictionary<string,Dictionary<string,int>>();
            _tableClass = new Dictionary<string, Dictionary<string, int>>();
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
            Dictionary<String, int> tableAux = new Dictionary<string, int>();
            int valor;
            Dictionary<String, int> ch; // se dps nao der declarar espaco
            foreach(String idSof in _tableSW.Keys)
            {
                _tableSW.TryGetValue(idSof, out ch);
                foreach(String idCh in ch.Keys)
                {
                    if (idCh.Equals(idChar)){
                        ch.TryGetValue(idCh, out valor);
                        tableAux.Add(idSof,valor);
                    }
                }
            }
            _tableX.Add(idChar,tableAux);
            return _tableX;
        }

        public int calMin(String idChar) 
        {
            int min=0;
            int flag = 1;
            Dictionary<String, int> list;
            foreach (String id in _tableX.Keys)
            {
                if (id.Equals(idChar))
                {
                    _tableX.TryGetValue(id, out list);
                    foreach (int valor in list.Values)
                    {
                        if (flag == 1)
                        {
                            min = valor;
                            flag = 0;
                        }
                        else
                        {
                            if (min > valor)
                            {
                                min = valor;
                            }
                        }
                    }
                }
            }
            return min;
        }

        public int calMax(String idChar)
        {
            int max = 0;
            int flag = 1;
            Dictionary<String, int> list;
            foreach (String id in _tableX.Keys)
            {
                if (id.Equals(idChar))
                {
                    _tableX.TryGetValue(id, out list);
                    foreach (int valor in list.Values)
                    {
                        if (flag == 1)
                        {
                            max = valor;
                            flag = 0;
                        }
                        else
                        {
                            if (max < valor)
                            {
                                max = valor;
                            }
                        }
                    }
                }
            }
            return max;
        }

        public float formulaMax(int min, int max, int x) 
        {
            return (x - min) / (max - min);
        }

        public float formulaMin(int min, int max, int x)
        {
            return (max - x) / (max - min);
        }

        public Dictionary<String, float> calValueMax(int min,int max)
        {
            Dictionary<String, float> _tablePrior=new Dictionary<string, float>();
            float resultado;
            int valor;

            foreach (Dictionary<String, int> listClass in _tableX.Values) {
                foreach (String idSoft in listClass.Keys) {
                    listClass.TryGetValue(idSoft, out valor);
                    resultado = formulaMax(min, max, valor);
                    _tablePrior.Add(idSoft,resultado);
                }
            }
            return _tablePrior;
        }

        public Dictionary<String, float> calValueMin(int min, int max)
        {
            Dictionary<String, float> _tablePrior = new Dictionary<string, float>();
            float resultado;
            int valor;

            foreach (Dictionary<String, int> listClass in _tableX.Values)
            {
                foreach (String idSoft in listClass.Keys)
                {
                    listClass.TryGetValue(idSoft, out valor);
                    resultado = formulaMin(min, max, valor);
                    _tablePrior.Add(idSoft, resultado);
                }
            }
            return _tablePrior;
        }

        private Dictionary<String, Dictionary<String, float>> registerPriority(String idChar) 
        {
            




            return _tableResult;
        }





        public void limparTabelas() {
            // quando fechar o programa deve limpar todas as tabelas
            _tableCH.Clear();
            _tableSW.Clear();
            _tableX.Clear();
            _tableClass.Clear();
            _tablePrior.Clear();
            _tableResult.Clear();
        
        }









    }
}
