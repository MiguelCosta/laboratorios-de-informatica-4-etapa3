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
        Dictionary<String, Dictionary<String, float>> _tableAHP;
        private Dictionary<String, Dictionary<String, float>> _tableResult;

        public DecisionSuport() 
        {
            _tableCH = new Dictionary<string, int>();
            _tableSW = new Dictionary<string, Dictionary<string,int>>();
            _tableX = new Dictionary<string,Dictionary<string,int>>();
            _tableClass = new Dictionary<string, Dictionary<string, int>>();
            _tableResult = new Dictionary<string, Dictionary<string, float>>();
            _tableAHP = new Dictionary<string, Dictionary<string, float>>();
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


        /*Métodos de Cálculo*/
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
            Dictionary<String, float> tablePrior=new Dictionary<string, float>();
            Dictionary<String, float> tableAux = new Dictionary<string, float>();
            float resultado;
            int valor;
            int numSoft=0;
            float resTotal = 0;
            float valueX;
            float valorNorm;
            
            //Calculos das prioridades
            foreach (Dictionary<String, int> listClass in _tableX.Values) 
            {
                foreach (String idSoft in listClass.Keys) 
                {
                    numSoft++;
                    listClass.TryGetValue(idSoft, out valor);
                    resultado = formulaMax(min, max, valor);
                    resTotal += resultado;
                    tableAux.Add(idSoft, resultado);
                }
            }
            //Calculos das prioridades normalizadas

            foreach (String id in tableAux.Keys) 
            {
                tableAux.TryGetValue(id, out valueX);
                valorNorm = valueX / resTotal;
                tablePrior.Add(id, valorNorm);
            }

            return tablePrior;
        }

        public Dictionary<String, float> calValueMin(int min, int max)
        {
            Dictionary<String, float> tablePrior = new Dictionary<string, float>();
            Dictionary<String, float> tableAux = new Dictionary<string, float>();
            float resultado;
            int valor;
            int numSoft = 0;
            float resTotal = 0;
            float valueX;
            float valorNorm;

            //Calculos das prioridades
            foreach (Dictionary<String, int> listClass in _tableX.Values)
            {
                foreach (String idSoft in listClass.Keys)
                {
                    numSoft++;
                    listClass.TryGetValue(idSoft, out valor);
                    resultado = formulaMin(min, max, valor);
                    resTotal += resultado;
                    tableAux.Add(idSoft, resultado);
                }
            }
            //Calculos das prioridades normalizadas

            foreach (String id in tableAux.Keys)
            {
                tableAux.TryGetValue(id, out valueX);
                valorNorm = valueX / resTotal;
                tablePrior.Add(id, valorNorm);
            }

            return tablePrior;
        }

        private Dictionary<String, Dictionary<String, float>> registerPriority(String idChar, Dictionary<String, float> tablePrior) 
        {
            _tableResult.Add(idChar, tablePrior);
            return _tableResult;
        }

        public void limparTabelas() {
            // quando fechar o programa deve limpar todas as tabelas
            _tableCH.Clear();
            _tableSW.Clear();
            _tableX.Clear();
            _tableClass.Clear();
            _tableResult.Clear();


        
        }

        // regista os resultados
        public Dictionary<String, Dictionary<String,float>> registerClassAHP(String idCharA, String idCharB, float points)
        {
            Dictionary<String, float> tableAux = new Dictionary<string, float>();
            tableAux.Add(idCharB, points);
            _tableAHP.Add(idCharA, tableAux);
            return _tableAHP;
        }

        // Chama a tabela resultante do register class AHP. Devolve uma "Matriz" com os valores normalizados
        public Dictionary<String, Dictionary<String, float>> normalizeAHP(Dictionary<String, Dictionary<String, float>> table)
        { 
            Dictionary<String, Dictionary<String,float>> tableAux = new Dictionary<string,Dictionary<string,float>>();
            Dictionary<String, float> table1 = new Dictionary<string, float>();
            Dictionary<String, float> table2 = new Dictionary<string, float>();
            Dictionary<String, float> table3 = new Dictionary<string, float>();

            float valor;
            float valor1 = 0;
            float resultado;

            foreach(String idCharA in table.Keys)
            {
                table.TryGetValue(idCharA, out table1);
                float totalValor = 0;
                foreach(String idCharB in table1.Keys)
                {
                    table1.TryGetValue(idCharB, out valor);
                    totalValor += valor;
                }
                table2.Add(idCharA, totalValor);
            }

            foreach (String idCharA in table.Keys)
            {
                table.TryGetValue(idCharA, out table1);
                foreach (String idCharB in table1.Keys)
                {
                    table1.TryGetValue(idCharB, out valor);
                    foreach (String id in table2.Keys)
                    {   
                        if(id.Equals(idCharB))
                        {
                        table2.TryGetValue(id, out valor1);
                        }
                    }
                    resultado = valor / valor1;
                    table3.Add(idCharB, resultado);
                }
                tableAux.Add(idCharA, table3);
            }
            return tableAux;
        }

        //Rece a matriz normalizada. Calcular Médias da matriz normalizada
        public Dictionary<String, float> pesosFinais(Dictionary<String, Dictionary<String, float>> tableNorma)
        {
            Dictionary<String, float> tablePesosFinais = new Dictionary<string, float>();
            Dictionary<String, Dictionary<String, float>> tableNormalInverted = new Dictionary<string, Dictionary<string, float>>();
            Dictionary<String, float> table1 = new Dictionary<string,float>();
            Dictionary<String, float> table2 = new Dictionary<string, float>();
            Dictionary<String, float> table3;
            float valor;
            String idAux;

            //inverter a tabela normalizada ou seja trocar as caracteristicas de <idCharA,<idcharB,valor>> para <idCharB,<idcharA,valor>>
            foreach (String idCharA in tableNorma.Keys) 
            {
                idAux = "";
                tableNorma.TryGetValue(idCharA, out table1);
                foreach (String idCharB in table1.Keys) 
                { 
                    table1.TryGetValue(idCharB, out valor);
                    if (!tableNormalInverted.ContainsKey(idCharB))
                    {
                        table2.Add(idCharA,valor);
                        tableNormalInverted.Add(idCharB, table2);
                    }
                    else 
                    {
                        tableNormalInverted.TryGetValue(idCharB, out table3);
                        table3.Add(idCharA, valor);                   
                    }
                }
            }

            //FALTA ACABAR 



            return tablePesosFinais;
        }


        /* Métodos a Criar*/

        // testa consistencia
        // 
        //
        //






    }
}
