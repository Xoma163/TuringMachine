using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace MT
{
    class DGV
    {
        //При старте
        public static DataGridView StatesStart(DataGridView dgv, string alphabet, int a)
        {

            dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(dgv, true, null);
            dgv.Rows.Clear();
            //Разрешаем добавлять строки 
            dgv.AllowUserToAddRows = true;
            //Количество строк = 4(3+1 для определения алфавита)
            dgv.ColumnCount = a;
            dgv.Rows.Clear();
            //Задаю количество строк = длине алфавита+1, т.к. нулевая ячейка
            dgv.Rows.Add(alphabet.Length + 1);
            //Заполняю столбец алфавитом
            for (int i = 0; i < alphabet.Length; i++)
                dgv.Rows[i + 1].Cells[0].Value = alphabet[i];

            //Рисую состояния
            for (int i = 1; i < dgv.ColumnCount; i++)
                dgv.Rows[0].Cells[i].Value = "q" + (i - 1);

            //Инициализация каждой ячейки
            for (int i = 1; i < dgv.Rows.Count; i++)
                for (int j = 1; j < dgv.Columns.Count; j++)
                    dgv.Rows[i].Cells[j].Value = "";

            //Запрещаем добавлять строки
            dgv.AllowUserToAddRows = false;

            return dgv;
        }
        public static DataGridView RibbonStart(DataGridView dgv, string alphabet, int a, int b)
        {
            dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(dgv, true, null);

            dgv.AllowUserToAddRows = true;

            dgv.ColumnCount += 1;
            dgv.Rows.Add(b);

            for (int i = 0; i < a - 1; i++)
            {
                dgv.ColumnCount += 1;
                dgv.Rows[1].Cells[i].Value = alphabet[0];
                dgv.Rows[1].Cells[i].ReadOnly = true;
                dgv.Columns[i].FillWeight = 1;
            }
            // dgvRibbon.Rows.Add(b);
            dgv.AllowUserToAddRows = false;

            return dgv;
        }
        //0 строка и 0 столбец - ReadOnly, обрабока 0;0, определяем FillWeight и ширину ячеек ну и всякую фигню.
        public static DataGridView StatesFormat(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].FillWeight = 1;
                dgv.Columns[i].Width = 50;
            }
            dgv.Columns[0].Width = 20;
            dgv.Rows[0].Cells[0].Style.BackColor = System.Drawing.Color.DarkGray;
            dgv.Rows[0].Cells[0].Value = " ";

            return dgv;
        }
        public static DataGridView RibbonFormat(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Rows[0].Cells[i].Value = i;
                dgv.Rows[0].Cells[i].ReadOnly = true;
                dgv.Rows[0].Cells[i].Style.BackColor = Color.Gray;
                dgv.Rows[0].Cells[i].Style.SelectionBackColor = Color.Gray;
                dgv.Rows[0].Cells[i].Style.SelectionForeColor = Color.Black;

                dgv.Rows[1].Cells[i].ReadOnly = true;

                dgv.Columns[i].FillWeight = 1;
                if (dgv.ColumnCount <= 100)
                    dgv.Columns[i].Width = 20;
                else
                    dgv.Columns[i].Width = 26;

            }
            return dgv;
        }

        public static DataGridView toWhite(DataGridView dgv, int index)
        {
            for (int i = index; i < dgv.Rows.Count; i++)
                for (int j = 0; j < dgv.Columns.Count; j++)
                    dgv.Rows[i].Cells[j].Style.BackColor = Color.White;

            return dgv;
        }
        public static DataGridView RibbonClear(DataGridView dgv,string alphabet)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Rows[1].Cells[i].Value = alphabet[0];
            return dgv;
        }
        public static DataGridView RibbonReadOnly(DataGridView dgv, bool value)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Rows[1].Cells[i].ReadOnly = value;
            return dgv;
        }
    }
}