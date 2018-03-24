using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT
{
    class File
    {
        //Для сохранения трассы подбиваем до нужного количества символов
        private static string toN(int i, int N)
        {
            string s = Convert.ToString(i);
            while (s.Length != N) s = "0" + s;
            return s;
        }

        public static DataGridView openDefault(DataGridView dgv1, string path, string defaultAlphabet)
        {
            try
            {
                StreamReader sr = new StreamReader(@path);
                try
                {
                    //длина и ширина
                    int a = 0;
                    int b = 0;
                    //Считываем длину и ширину
                    a = Convert.ToInt32(sr.ReadLine());
                    b = Convert.ToInt32(sr.ReadLine());
                    //Cоздаём новые размеры
                    dgv1.Rows.Clear();
                    dgv1.Rows.Add(a);
                    dgv1.ColumnCount = b;

                    string newAlphabet = "";
                    for (int i = 0; i < a; i++)
                    {
                        string[] mas = sr.ReadLine().Split(';');
                        for (int j = 0; j < b; j++)
                        {
                            //переписываем в dgv
                            dgv1.Rows[i].Cells[j].Value = mas[j];
                            //Если не нулевая ячейка, то считываем алфавит
                            if (j == 0 && i != 0)
                                newAlphabet += mas[j];
                        }
                    }
                    dgv1 = DGV.StatesFormat(dgv1);

                    return dgv1;
                }
                catch
                {
                    MessageBox.Show("Проблемы считывания стандартного алгоритма");
                    dgv1 = DGV.StatesStart(dgv1, defaultAlphabet, 4);
                    return dgv1;
                }
                finally
                {
                    sr.Close();
                }
            }
            catch
            {
                MessageBox.Show("Стандартный алгоритм не найден");
                dgv1 = DGV.StatesStart(dgv1, defaultAlphabet, 4);
                return dgv1;
            }
        }
        public static DataGridView open(DataGridView dgv1, string defaultAlphabet)
        {
            //Файловый диалог
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Algorithm of Turing machines|*.tma";
            ofd.Title = "Открыть алгоритм";

            //Открываем и ждём нажатия кнопки
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Открываем поток с нашим файлом
                StreamReader sr = new StreamReader(ofd.FileName);
                //ошибка считывания либо синтаксиса
                bool ex = false;
                //длина и ширина
                int a = 0;
                int b = 0;
                try
                {
                    //Считываем длину и ширину(пытаемся)
                    a = Convert.ToInt32(sr.ReadLine());
                    b = Convert.ToInt32(sr.ReadLine());
                    //Создаём новые размеры
                    dgv1.Rows.Clear();
                    dgv1.Rows.Add(a);
                    dgv1.ColumnCount = b;
                    //заводим переменную для нового алфавита, который будет считан
                    string newAlphabet = "";

                    for (int i = 0; i < a; i++)
                    {
                        //Считываем в массив строк
                        string[] mas = sr.ReadLine().Split(';');
                        //Если количество ; и столбцов не совпало хотя бы раз, то ex и уходим
                        if (mas.Length != b + 1)
                        {
                            ex = true;
                            MessageBox.Show("Неверный формат файла");
                            break;
                        }

                        for (int j = 0; j < b; j++)
                        {
                            //переписываем в dgv
                            dgv1.Rows[i].Cells[j].Value = mas[j];
                            //Если не нулевая ячейка, то считываем алфавит
                            if (j == 0 && i != 0)
                                newAlphabet += mas[j];

                            if (ex) break;
                        }
                        if (ex) break;
                    }

                    if(ex)
                    {
                        dgv1 = DGV.StatesStart(dgv1, defaultAlphabet, 4);
                        dgv1 = DGV.StatesFormat(dgv1);
                    }
                    else
                    {
                        dgv1 = DGV.StatesFormat(dgv1);
                        return dgv1;
                    }
                }
                //Если вылетели по ошибке, то загружаем новый алгоритм
                catch
                {
                    MessageBox.Show("Неверный формат файла");
                    ex = true;
                    dgv1 = DGV.StatesStart(dgv1, defaultAlphabet, 4);
                    dgv1 = DGV.StatesFormat(dgv1);
                    return dgv1;
                }
                //В любом случае нужно закрыть поток
                finally
                { sr.Close(); }
            }
            return dgv1;
        }
        public static void save(DataGridView dgv1)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Turing machine algorithm|*.tma";
            sfd.Title = "Сохранить алгоритм как";
            //Ждём кнопку ОК
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.WriteLine(dgv1.RowCount);
                sw.WriteLine(dgv1.ColumnCount);
                for (int i = 0; i < dgv1.RowCount; i++)
                {
                    for (int j = 0; j < dgv1.ColumnCount; j++)
                        sw.Write(dgv1.Rows[i].Cells[j].Value + ";");
                    if (i != dgv1.RowCount - 1)
                        sw.WriteLine("");
                }
                sw.Close();
            }
        }
        public static void saveTrack(List<string> fullTrack)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Turing machine track|*.tmt";
            sfd.Title = "Сохранить трассу как";
            //Ждём кнопку ОК
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                for (int i = 0; i < fullTrack.Count; i++)
                    sw.WriteLine(toN(i + 1, Convert.ToString(fullTrack.Count).Length) + ". " + fullTrack[i]);
                sw.Close();
            }
        }
    }
}