﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    class DecisionSuport
    {
        private Dictionary<String, int> _tableCH;
        private Dictionary<String, Dictionary<String, int>> _tableSW;
        private Dictionary<String, Dictionary<String, int>> _tableX;
        private Dictionary<String, Dictionary<String, int>> _tableClass;
        private Dictionary<String, Dictionary<String, float>> _tableAHP;
        private Dictionary<String, Dictionary<String, float>> _tableResult;
        private Dictionary<String, Dictionary<String, Dictionary<String, float>>> _tablePriorAHP;

        public DecisionSuport()
        {
            _tableCH = new Dictionary<string, int>();
            _tableSW = new Dictionary<string, Dictionary<string, int>>();
            _tableX = new Dictionary<string, Dictionary<string, int>>();
            _tableClass = new Dictionary<string, Dictionary<string, int>>();
            _tableAHP = new Dictionary<string, Dictionary<string, float>>();
            _tableResult = new Dictionary<string, Dictionary<string, float>>();
            _tablePriorAHP = new Dictionary<string, Dictionary<string, Dictionary<string, float>>>();

        }

        /* Métodos get e set */
        public Dictionary<String, int> TableCH
        {
            get { return _tableCH; }
            set { _tableCH = value; }
        }

        public Dictionary<String, Dictionary<String, int>> TableSW
        {
            get { return _tableSW; }
            set { _tableSW = value; }
        }

        public Dictionary<String, Dictionary<String, float>> TableAHP
        {
            get { return _tableAHP; }
            set { _tableAHP = value; }
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

        public Dictionary<string, Dictionary<string, Dictionary<string, float>>> TablePriorAHP
        {
            get { return _tablePriorAHP; }
            set { _tablePriorAHP = value; }
        }


        /*Métodos de Cálculo de Classificações*/
        public Dictionary<string, int> registerClass(String idChar, int points)
        {
            if (!_tableCH.ContainsKey(idChar))
            {
                _tableCH.Add(idChar, points);
            }
            else
            {
                _tableCH.Remove(idChar);
                _tableCH.Add(idChar, points);
            }
            return _tableCH;
        }

        // regista os resultados
        public Dictionary<String, Dictionary<String, float>> registerClassAHP(String idCharA, String idCharB, float points)
        {
            Dictionary<String, float> tableAux = new Dictionary<string, float>();
            Dictionary<String, float> tableA;
            if (!_tableAHP.ContainsKey(idCharA))
            {
                tableAux.Add(idCharB, points);
                _tableAHP.Add(idCharA, tableAux);
            }
            else
            {
                _tableAHP.TryGetValue(idCharA, out tableA);
                if (!tableA.ContainsKey(idCharB))
                {
                    tableA.Add(idCharB, points);
                }
                else
                {
                    tableA.Remove(idCharB);
                    tableA.Add(idCharB, points);
                }
            }

            return _tableAHP;
        }

        /* Chama a tabela resultante do register class AHP. Devolve uma "Matriz" com os valores normalizados
        SÓ NORMALIZA SE A SOMA DOS VALORES FOR DIFERENTE DE 1*/

        public Dictionary<String, Dictionary<String, float>> normalizeAHP(Dictionary<String, Dictionary<String, float>> table)
        {
            Dictionary<String, float> table1 = new Dictionary<string, float>();
            Dictionary<String, float> tableSomas = new Dictionary<string, float>();
            Dictionary<String, Dictionary<String, float>> tableAux = new Dictionary<string, Dictionary<string, float>>();

            float valor;
            float resultado;

            foreach (String idCharA in table.Keys)
            {
                table.TryGetValue(idCharA, out table1);
                float totalValor = 0;
                foreach (String idCharB in table1.Keys)
                {
                    table1.TryGetValue(idCharB, out valor);
                    totalValor += valor;
                }
                tableSomas.Add(idCharA, totalValor);

            }

            Dictionary<String, float> tableCorrespondencia;
            Dictionary<String, float> tableAuxiliar = new Dictionary<string, float>();
            Dictionary<String, float> tableAuxiliar1 = new Dictionary<string, float>();
            float valor1 = 0;

            foreach (String idCharA in table.Keys)
            {
                table.TryGetValue(idCharA, out tableAuxiliar);
                tableCorrespondencia = new Dictionary<string, float>();
                foreach (String idCharB in table1.Keys)
                {
                    tableAuxiliar.TryGetValue(idCharB, out valor);
                    tableSomas.TryGetValue(idCharA, out valor1);
                    resultado = valor / valor1;

                    if (!tableAux.ContainsKey(idCharA))
                    {
                        tableCorrespondencia.Add(idCharB, resultado);
                        tableAux.Add(idCharA, tableCorrespondencia);
                    }
                    else
                    {
                        tableAux.TryGetValue(idCharA, out tableAuxiliar1);
                        tableAux.Remove(idCharA);
                        tableAuxiliar1.Add(idCharB, resultado);
                        tableAux.Add(idCharA, tableAuxiliar1);

                    }
                }

            }

            return tableAux;
        }

        //Recebe a matriz normalizada. Calcular Médias da matriz normalizada
        public Dictionary<String, float> pesosFinais(Dictionary<String, Dictionary<String, float>> tableNorma)
        {
            Dictionary<String, float> tableCorrespondencia;
            Dictionary<String, float> tableAuxiliar = new Dictionary<string, float>();
            Dictionary<String, float> tableAuxiliar1;
            Dictionary<String, float> tablePesosFinais = new Dictionary<string, float>();
            Dictionary<String, Dictionary<String, float>> tableNormalInverted = new Dictionary<string, Dictionary<string, float>>();

            float valor;
            int numCar = 0;

            //inverter a tabela normalizada ou seja trocar as caracteristicas de <idCharA,<idcharB,valor>> para <idCharB,<idcharA,valor>>
            foreach (String idCharA in tableNorma.Keys)
            {
                tableNorma.TryGetValue(idCharA, out tableAuxiliar);
                tableAuxiliar1 = new Dictionary<string, float>();
                foreach (String idCharB in tableAuxiliar.Keys)
                {
                    tableCorrespondencia = new Dictionary<string, float>();
                    tableAuxiliar.TryGetValue(idCharB, out valor);
                    if (!tableNormalInverted.ContainsKey(idCharB))
                    {
                        tableCorrespondencia.Add(idCharA, valor);
                        tableNormalInverted.Add(idCharB, tableCorrespondencia);
                    }
                    else
                    {
                        tableNormalInverted.TryGetValue(idCharB, out tableAuxiliar1);
                        tableNormalInverted.Remove(idCharB);
                        tableAuxiliar1.Add(idCharA, valor);
                        tableNormalInverted.Add(idCharB, tableAuxiliar1);
                    }
                }
            }

            tableAuxiliar.Clear();
            tableAuxiliar1 = new Dictionary<string, float>();
            foreach (String idCharA in tableNormalInverted.Keys)
            {
                float valorTotal = 0;
                tableNormalInverted.TryGetValue(idCharA, out tableAuxiliar);

                foreach (String idCharB in tableAuxiliar.Keys)
                {
                    tableAuxiliar.TryGetValue(idCharB, out valor);
                    valorTotal += valor;
                }

                tableAuxiliar1.Add(idCharA, valorTotal);
            }

            foreach (String id in tableAuxiliar.Keys)
            {
                numCar++;
            }

            foreach (String id in tableAuxiliar1.Keys)
            {

                tableAuxiliar1.TryGetValue(id, out valor);

                tablePesosFinais.Add(id, (valor / numCar));
            }

            return tablePesosFinais;
        }

        // Testar Consistência para classificações




        /*Métodos dé Cálculo de Prioridades*/
        public Dictionary<String, Dictionary<String, int>> filter(String idChar)
        {
            Dictionary<String, int> tableAux = new Dictionary<string, int>();
            int valor;
            Dictionary<String, int> ch; // se dps nao der declarar espaco
            foreach (String idSof in _tableSW.Keys)
            {
                _tableSW.TryGetValue(idSof, out ch);
                foreach (String idCh in ch.Keys)
                {
                    if (idCh.Equals(idChar))
                    {
                        ch.TryGetValue(idCh, out valor);
                        tableAux.Add(idSof, valor);
                    }
                }
            }
            _tableX.Add(idChar, tableAux);
            return _tableX;
        }

        public int calMin(String idChar)
        {
            int min = 0;
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

        /*Auxiliar da calcValueMax*/
        public float formulaMax(int min, int max, int x)
        {
            int a = x - min;
            int b = max - min;
            return (float)a / (float)b;
        }

        /*Auxiliar da calcValueMin*/
        public float formulaMin(int min, int max, int x)
        {
            int a = max - x;
            int b = max - min;
            return (float)a / (float)b;
        }

        public Dictionary<String, float> calValueMax(int min, int max)
        {
            Dictionary<String, float> tablePrior = new Dictionary<string, float>();
            Dictionary<String, float> tableAux = new Dictionary<string, float>();
            Dictionary<String, int> listClass;
            float resultado;
            int valor;

            float valueX;
            float valorNorm;
            float resTotal = 0;
            //Calculos das prioridades
            foreach (String idA in _tableX.Keys)
            {
                _tableX.TryGetValue(idA, out listClass);

                foreach (String idSoft in listClass.Keys)
                {
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

        public Dictionary<String, Dictionary<String, float>> registerPriority(String idChar, Dictionary<String, float> tablePrior)
        {
            if (!_tableResult.ContainsKey(idChar))
            {
                _tableResult.Add(idChar, tablePrior);
            }
            else
            {
                _tableResult.Remove(idChar);
                _tableResult.Add(idChar, tablePrior);
            }
            return _tableResult;
        }

        //A diferença entre estes métodos e os métodos da classificação é que têm que andar com o id da caracteristica porque cada uma pode ter o seu método
        // regista os resultados
        public Dictionary<String, Dictionary<String, Dictionary<String, float>>> registerPriorAHP(String idChar, String idSofA, String idSofB, float points)
        {
            Dictionary<String, Dictionary<String, float>> tablePrior = new Dictionary<string, Dictionary<string, float>>();
            Dictionary<String, Dictionary<String, float>> tablePriorAux = new Dictionary<string, Dictionary<string, float>>();
            Dictionary<String, float> tableAux = new Dictionary<string, float>();
            if (!_tablePriorAHP.ContainsKey(idChar))
            {
                tableAux.Add(idSofB, points);
                tablePrior.Add(idSofA, tableAux);
                _tablePriorAHP.Add(idChar, tablePrior);
            }
            else
            {
                _tablePriorAHP.TryGetValue(idChar, out tablePriorAux);
                if (!tablePriorAux.ContainsKey(idSofA))
                {
                    tableAux.Add(idSofB, points);
                    tablePriorAux.Add(idSofA, tableAux);
                }
                else
                {
                    tablePriorAux.TryGetValue(idSofA, out tableAux);
                    if (!tableAux.ContainsKey(idSofB))
                    {
                        tableAux.Add(idSofB, points);
                    }
                    else
                    {
                        tableAux.Remove(idSofB);
                        tableAux.Add(idSofB, points);
                    }
                }
            }
            return _tablePriorAHP;
        }

        /* Chama a tabela resultante do register class AHP. Devolve uma "Matriz" com os valores normalizados
           SÓ NORMALIZA SE A SOMA DOS VALORES FOR DIFERENTE DE 1*/
        public Dictionary<String, Dictionary<String, Dictionary<String, float>>> normalizePriorityAHP(Dictionary<String, Dictionary<String, Dictionary<String, float>>> table)
        {
            float valor;
            float resultado;
            float total;
            Dictionary<String, Dictionary<String, float>> tableAux2;
            Dictionary<String, float> table1 = new Dictionary<string, float>();
            Dictionary<String, float> table3 = new Dictionary<string, float>();
            Dictionary<String, float> tableSomas = new Dictionary<string, float>();
            Dictionary<String, Dictionary<String, float>> tableAux = new Dictionary<string, Dictionary<string, float>>();
            Dictionary<String, Dictionary<String, Dictionary<String, float>>> tableNorm = new Dictionary<string, Dictionary<string, Dictionary<string, float>>>();


            foreach (String idChar in table.Keys)
            {
                table.TryGetValue(idChar, out tableAux2);
                foreach (String idSofA in tableAux2.Keys)
                {
                    tableAux2.TryGetValue(idSofA, out table1);
                    float totalValor = 0;
                    foreach (String idSofB in table1.Keys)
                    {
                        table1.TryGetValue(idSofB, out valor);
                        totalValor += valor;
                    }
                    tableSomas.Add(idSofA, totalValor);

                }
            }

            // Correcto ATÉ Aqui

            Dictionary<String, float> tableCorrespondencia;
            Dictionary<String, float> tableAuxiliar = new Dictionary<string, float>();
            Dictionary<String, float> tableAuxiliar1 = new Dictionary<string, float>();
            Dictionary<String, Dictionary<String, float>> tableAuxiliar2;

            foreach (String idCh in table.Keys)
            {
                table.TryGetValue(idCh, out tableAux2);
                tableAuxiliar2 = new Dictionary<String, Dictionary<string, float>>();
                foreach (String idSofA in tableAux2.Keys)
                {
                    tableAux2.TryGetValue(idSofA, out tableAuxiliar);
                    tableCorrespondencia = new Dictionary<string, float>();
                    foreach (String idSofB in tableAuxiliar.Keys)
                    {
                        tableAuxiliar.TryGetValue(idSofB, out valor);
                        tableSomas.TryGetValue(idSofA, out total);
                        resultado = valor / total;
                        if (!tableAuxiliar2.ContainsKey(idSofA))
                        {
                            tableCorrespondencia.Add(idSofB, resultado);
                            tableAuxiliar2.Add(idSofA, tableCorrespondencia);
                        }

                        else
                        {
                            tableAuxiliar2.TryGetValue(idSofA, out tableAuxiliar1);
                            tableAuxiliar2.Remove(idSofA);
                            tableAuxiliar1.Add(idSofB, resultado);
                            tableAuxiliar2.Add(idSofA, tableAuxiliar1);
                        }
                    }
                }
                tableNorm.Add(idCh, tableAuxiliar2);
            }
            return tableNorm;
        }

        //Recebe a matriz normalizada. Calcular Médias da matriz normalizada
        public Dictionary<String, Dictionary<String, float>> pesosPriorFinais(Dictionary<String, Dictionary<String, Dictionary<String, float>>> tableNorma)
        {
            Dictionary<String, float> tableCorrespondencia;
            Dictionary<String, float> tableAuxiliar = new Dictionary<string, float>();
            Dictionary<String, float> tableAuxiliar1;
            Dictionary<String, float> tableAuxiliar2 = new Dictionary<string, float>();
            Dictionary<String, Dictionary<String, float>> tablePesosFinais = new Dictionary<String, Dictionary<string, float>>();
            Dictionary<String, Dictionary<String, float>> tableNormalInvertedAux = new Dictionary<string, Dictionary<string, float>>();
            Dictionary<String, Dictionary<String, float>> tableNormalized = new Dictionary<string, Dictionary<string, float>>();
            Dictionary<String, Dictionary<String, Dictionary<String, float>>> tableNormalInverted = new Dictionary<string, Dictionary<string, Dictionary<string, float>>>();
            float valor;
            int numCar = 0;

            //inverter a tabela normalizada ou seja trocar as caracteristicas de <idCharA,<idcharB,valor>> para <idCharB,<idcharA,valor>>
            foreach (String idChar in tableNorma.Keys)
            {
                tableNorma.TryGetValue(idChar, out tableNormalized);

                foreach (String idSofA in tableNormalized.Keys)
                {
                    tableNormalized.TryGetValue(idSofA, out tableAuxiliar);
                    foreach (String idSofB in tableAuxiliar.Keys)
                    {
                        tableCorrespondencia = new Dictionary<string, float>();
                        tableAuxiliar.TryGetValue(idSofB, out valor);
                        if (!tableNormalInvertedAux.ContainsKey(idSofB))
                        {
                            tableCorrespondencia.Add(idSofA, valor);
                            tableNormalInvertedAux.Add(idSofB, tableCorrespondencia);
                        }
                        else
                        {
                            tableNormalInvertedAux.TryGetValue(idSofB, out tableAuxiliar1);
                            tableNormalInvertedAux.Remove(idSofB);
                            if (!tableAuxiliar1.ContainsKey(idSofA))
                            {
                                tableAuxiliar1.Add(idSofA, valor);
                            }
                            else
                            {
                                tableAuxiliar1.Remove(idSofA);
                                tableAuxiliar1.Add(idSofA, valor);
                            }

                            tableNormalInvertedAux.Add(idSofB, tableAuxiliar1);
                        }
                    }
                }

                tableNormalInverted.Add(idChar, tableNormalInvertedAux);
            }


            Dictionary<String, Dictionary<String, float>> tableA;
            Dictionary<String, float> tableB;
            float x;
            Console.WriteLine("\n************ Inverted Normalized *************");
            foreach (String idChar in tableNormalInverted.Keys)
            {
                tableNormalInverted.TryGetValue(idChar, out tableA);
                Console.WriteLine("Id Char: " + idChar);
                foreach (String idSofA in tableA.Keys)
                {
                    tableA.TryGetValue(idSofA, out tableB);
                    Console.WriteLine("\tID Sof: " + idSofA);
                    foreach (String idSofB in tableB.Keys)
                    {
                        tableB.TryGetValue(idSofB, out x);
                        Console.WriteLine("\t\tId Sof: " + idSofB);
                        Console.WriteLine("\t\tValor: " + x);
                    }

                }
            }


            tableAuxiliar.Clear();
            tableAuxiliar1 = new Dictionary<string, float>();

            foreach (String idCh in tableNormalInverted.Keys)
            {
                foreach (String idSofA in tableNormalInvertedAux.Keys)
                {
                    float valorTotal = 0;
                    tableNormalInvertedAux.TryGetValue(idSofA, out tableAuxiliar);

                    foreach (String idSofB in tableAuxiliar.Keys)
                    {
                        tableAuxiliar.TryGetValue(idSofB, out valor);
                        valorTotal += valor;
                    }

                    tableAuxiliar1.Add(idSofA, valorTotal);
                }

                foreach (String id in tableAuxiliar.Keys)
                {
                    numCar++;

                }

                foreach (String id in tableAuxiliar1.Keys)
                {
                    tableAuxiliar1.TryGetValue(id, out valor);
                    float result = (valor / numCar);
                    tableAuxiliar2.Add(id, result);
                }

                tablePesosFinais.Add(idCh, tableAuxiliar2);
            }

            return tablePesosFinais;
        }

        // Testar Consistência para Prioridades











        //analisa a prioridade se o user utilizou o smart e 
        //public Dictionary<int, Dictionary<String, float>> analiseFinal() { }

        /* Métodos a Criar*/

        // testa consistencia
        //análises finais
        //






    }
}
