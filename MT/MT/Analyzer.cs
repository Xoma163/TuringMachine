using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT
{
    class Analyzer
    {
        private static void error(DataGridView dgv, int a, int b, char error, char where)
        {
            //с какой dgv работаем
            //позиции a,b
            //e=0 вернуть обратно цвет ячейки, e=1 - синтаксическая ошибка, e=2 - семантическая, e=3 - синтаксическая на ленте
            //where = ' ' - пустой параметр, where='0,1,2' - позиция ошибки(либо её характер)

            dgv.Rows[a].Cells[b].Style.BackColor = System.Drawing.Color.OrangeRed;
            //СНАЧАЛА СВИТЧИМ ERROR, ПОТОМ WHERE
            switch (error)
            {
                case ('1'):
                    {
                        switch (where)
                        {
                            case ('0'):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке правил перехода " + a + ";" + b + "\nПроверьте название состояния");
                                    return;
                                }
                            case ('1'):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке правил перехода " + a + ";" + b + "\nСимвол не соответствует алфавиту");
                                    return;
                                }
                            case ('2'):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке правил перехода " + a + ";" + b + "\nНеверная команда перемещения");
                                    return;
                                }
                            case ('3'):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке правил перехода " + a + ";" + b + "\nНеверное число параметров в ячейке");
                                    return;
                                }
                            case ('4'):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке правил перехода " + a + ";" + b + "\nСостояние не может быть пустым");
                                    return;
                                }
                            case (' '):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке правил перехода " + a + ";" + b + "\nНепредвиденная ошибка");
                                    return;
                                }
                        }
                        break;
                    }
                case ('2'):
                    {
                        switch (where)
                        {
                            case ('0'):
                                {
                                    MessageBox.Show("Семантаческая ошибка в ячейке правил перехода " + a + ";" + b + "\nПроверьте верность состояния");
                                    break;
                                }
                            case ('1'):
                                {
                                    MessageBox.Show("Семантаческая ошибка в ячейке правил перехода " + a + ";" + b + "\nНе существует такого состояния в списке состояний");
                                    break;
                                }
                            case ('2'):
                                {
                                    MessageBox.Show("Семантаческая ошибка в ячейке правил перехода " + a + ";" + b + "\nНет обработки начального состояния");
                                    break;
                                }
                        }
                        break;
                    }
                case ('3'):
                    {
                        switch (where)
                        {
                            case ('0'):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке ленты " + b + "\nЯчейка ленты должна содержать 1 символ или не содержать его вовсе");
                                    return;
                                }
                            case ('1'):
                                {
                                    MessageBox.Show("Синтаксическая ошибка в ячейке ленты " + b + "\nЯчейка ленты должна содержать символы алфавита");
                                    return;
                                }
                        }
                        break;
                    }
                case ('4'):
                    {
                        switch (where)
                        {
                            case ('0'):
                                {
                                    MessageBox.Show("Ошибка алфавита в ячейке правил перехода " + a + ";" + b + "\nВ ячейке должен содержаться 1 символ алфавита");
                                    return;
                                }
                            case ('1'):
                                {
                                    MessageBox.Show("Ошибка алфавита в ячейке правил перехода " + a + ";" + b + "\nВ алфавите не могут содержаться одинаковые символы");
                                    return;
                                }
                            case ('2'):
                                {
                                    MessageBox.Show("Ошибка алфавита в ячейке правил перехода " + a + ";" + b + "\nВ алфавите не может содержаться пробел");
                                    return;
                                }
                        }
                        break;
                    }
            }
        }
        public static bool syntacticAnalysis(DataGridView dgv, string alphabet, string[] states)
        {
            //Для состояний
            states = new string[dgv.ColumnCount];
            //Определяем
            for (int k = 1; k < states.Length; k++)
                try{ states[k] = dgv.Rows[0].Cells[k].Value.ToString(); }
                catch {dgv.Rows[0].Cells[k].Value = ""; }

            for (int i = 1; i < dgv.RowCount; i++)
            {
                //Проверка на пустое состояние
                for (int k = 1; k < states.Length; k++)
                    if (dgv.Rows[0].Cells[k].Value.ToString() == "")
                    {
                        error(dgv, 0, k, '1', '4');
                        return false;
                    }
                for (int j = 1; j < dgv.ColumnCount; j++)
                    //Если строка не пустая
                    try
                    {
                        if (dgv.Rows[i].Cells[j].Value.ToString().Length != 0)
                            try
                            {
                                string[] words = dgv.Rows[i].Cells[j].Value.ToString().Split(' ');

                                //Если три слова
                                if (words.Length != 3)
                                {
                                    error(dgv, i, j, '1', '3');
                                    return false;
                                }

                                //Если только одна буква во втором слове и она содержится в алфавите
                                if (words[1].Length != 1 || !alphabet.Contains(words[1]))
                                {
                                    error(dgv, i, j, '1', '1');
                                    return false;
                                }
                                //Если только одна буква в последнем слове и если эта буква R,L,S
                                if (words[2].Length != 1 || !"RLS".Contains(words[2]))
                                {
                                    error(dgv, i, j, '1', '1');
                                    return false;
                                }
                            }
                            catch
                            {
                                error(dgv, i, j, '1', ' ');
                                return false;
                            }
                    }


                    catch
                    {
                        //При написании чего-ибо в ячейку, а потом удаление онного, в ячейке не "", а null. Исправляем.
                        dgv.Rows[i].Cells[j].Value = "";
                    }
            }
            return true;
        }
        public static bool semanticAnalysis(DataGridView dgvStates, DataGridView dgvRibbon, string alphabet, string[] states)
        {
            //Для состояний
            states = new string[dgvStates.ColumnCount];
            //Определяем
            for (int k = 1; k < states.Length; k++)
                states[k] = dgvStates.Rows[0].Cells[k].Value.ToString();


            for (int i = 1; i < dgvStates.RowCount; i++)
                for (int j = 1; j < dgvStates.ColumnCount; j++)
                    //Если строка не пустая
                    try
                    {
                        if (dgvStates.Rows[i].Cells[j].Value.ToString().Length != 0)
                            try
                            {
                                if (Array.IndexOf(states, dgvStates.Rows[i].Cells[j].Value.ToString().Substring(0, dgvStates.Rows[i].Cells[j].Value.ToString().IndexOf(' '))) == -1)
                                {
                                    error(dgvStates, i, j, '2', '1');
                                    return false;
                                }
                            }
                            catch
                            {
                                error(dgvStates, i, j, '2', '0');
                                return false;
                            }
                    }
                    catch
                    {
                        //При написании чего-ибо в ячейку, а потом удаление онного, в ячейке не "", а null. Исправляем.
                        dgvStates.Rows[i].Cells[j].Value = "";
                    }
            if (dgvStates.Rows[alphabet.IndexOf(dgvRibbon.Rows[1].Cells[0].Value.ToString()) + 1].Cells[1].Value.ToString() == "")
            {
                error(dgvStates, alphabet.IndexOf(dgvRibbon.Rows[1].Cells[0].Value.ToString()) + 1, 1, '2', '2');
                return false;
            }
            return true;
        }
        public static bool ribbonAnalysis(DataGridView dgv, string alphabet)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                try
                {
                    if (dgv.Rows[1].Cells[i].Value.ToString().Length > 1)
                    {
                        error(dgv, 1, i, '3', '0');
                        return false;
                    }
                    if (!alphabet.Contains(dgv.Rows[1].Cells[i].Value.ToString()))
                    {
                        error(dgv, 1, i, '3', '1');
                        return false;
                    }
                }
                catch
                {
                    //При написании чего-ибо в ячейку, а потом удаление онного, в ячейке не "", а null. Исправляем.
                    dgv.Rows[1].Cells[i].Value = alphabet[0];
                }
            }
            return true;
        }
        public static bool alphabetAnalysis(DataGridView dgv, string alphabet)
        {
            string S = "";
            for (int i = 1; i < dgv.RowCount; i++)
            {
                S += dgv.Rows[i].Cells[0].Value;
                if (dgv.Rows[i].Cells[0].Value.ToString().Length != 1)
                {
                    error(dgv, i, 0, '4', '0');
                    return false;
                }
            }

            for (int i = 0; i < alphabet.Length; i++)
                for (int j = 0; j < alphabet.Length - i; j++)
                    if (i != j)
                        if (alphabet[i] == alphabet[j])
                        {
                            error(dgv, j, i, '4', '1');
                            return false;
                        }

            for (int i = 0; i < alphabet.Length; i++)
                if (alphabet[i] == ' ')
                {
                    error(dgv, i + 1, 0, '4', '2');
                    return false;
                }

            return true;
        }
    }
}
