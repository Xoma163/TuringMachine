using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace MT
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            //Инициализируем переходы и ленту
            dgvStates = DGV.StatesStart(dgvStates, alphabet, 4);
            dgvStates = DGV.StatesFormat(dgvStates);
            dgvRibbon = DGV.RibbonStart(dgvRibbon, alphabet, 500, 2);
            dgvRibbon = DGV.RibbonFormat(dgvRibbon);
        }

        //Текущее состояние алфавита
        private string alphabet = "E*10=";
        private string defaultAlphabet = "E*10=";

        #region Жмяки по кнопкам
        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //очищаем dgv
            dgvStates.Rows.Clear();
            //Алфавит берём дефолтный
            alphabet = defaultAlphabet;

            //Запускаем нашу dgv
            dgvStates = DGV.StatesStart(dgvStates, alphabet, 4);
            dgvStates = DGV.StatesFormat(dgvStates);

        }
        private void загрузитьАлгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvStates = File.open(dgvStates, defaultAlphabet);
        }
        private void сохранитьАлгоритмКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.save(dgvStates);
        }
        private void сложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvStates = File.openDefault(dgvStates,"default/sum.tma",defaultAlphabet);
        }
        private void нОДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvStates = File.openDefault(dgvStates, "default/multiplication.tma", defaultAlphabet);
        }
        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.StartupPath + @"\guide.chm");
            }
            catch
            {
                MessageBox.Show("Файл справки не найден");
            }
        }
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.StartPosition = FormStartPosition.CenterParent;
            about.ShowDialog();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Режим работы
        //Режим работы. 1-Пошаговый, 2-Автоматический, 3-Мгновенный
        private int operatingMode = 2;
        //Узнаём режим работы
        private void radioButtonStep_CheckedChanged(object sender, EventArgs e)
        {
            operatingMode = 1;
            trackBarSpeed.Visible = false;
            labelSpeed.Visible = false;

            checkBoxMove.Checked = true;
            checkBoxMove.Visible = true;
        }
        private void radioButtonAuto_CheckedChanged(object sender, EventArgs e)
        {
            operatingMode = 2;
            trackBarSpeed.Visible = true;
            labelSpeed.Visible = true;

            checkBoxMove.Checked = true;
            checkBoxMove.Visible = true;
        }
        private void radioButtonNow_CheckedChanged(object sender, EventArgs e)
        {
            operatingMode = 3;
            trackBarSpeed.Visible = false;
            labelSpeed.Visible = false;

            checkBoxMove.Checked = false;
            checkBoxMove.Visible = false;
        }

        //Скорость при 2-Автоматическом режиме работы
        private int speed = 100;
        //Узнаём скорость
        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            switch (trackBarSpeed.Value)
            {
                case 1:
                    speed = 15;
                    return;
                case 2:
                    speed = 50;
                    return;
                case 3:
                    speed = 100;
                    return;
                case 4:
                    speed = 250;
                    return;
                case 5:
                    speed = 500;
                    return;
            }
        }
        #endregion

        #region Операнды
        //Режим задания операндов true-На форме, false-На ленте
        private bool operandsModeForm = true;

        //Узнаем режим задания операндов
        private void radioButtonForm_CheckedChanged(object sender, EventArgs e)
        {
            operandsModeForm = true;

            numericUpDownA.Visible = true;
            numericUpDownB.Visible = true;
            labelA.Visible = true;
            labelB.Visible = true;

            dgvRibbon = DGV.RibbonClear(dgvRibbon, alphabet);
            dgvRibbon = DGV.RibbonReadOnly(dgvRibbon, true);

        }
        private void radioButtonRibbon_CheckedChanged(object sender, EventArgs e)
        {
            operandsModeForm = false;
            numericUpDownA.Visible = false;
            numericUpDownB.Visible = false;
            labelA.Visible = false;
            labelB.Visible = false;

            dgvRibbon = DGV.RibbonClear(dgvRibbon, alphabet);
            dgvRibbon = DGV.RibbonReadOnly(dgvRibbon, false);
        }

        //Операнды A,B
        private int operandA = 1;
        private int operandB = 1;

        //Узнаём операнды
        private void numericUpDownA_ValueChanged(object sender, EventArgs e)
        {
            operandA = Convert.ToInt32(numericUpDownA.Value);
        }
        private void numericUpDownB_ValueChanged(object sender, EventArgs e)
        {
            operandB = Convert.ToInt32(numericUpDownB.Value);
        }
        private void buttonClearRibbon_Click(object sender, EventArgs e)
        {

            string oldAlphabet = alphabet;
            alphabet = "";
            for (int i = 1; i < dgvStates.Rows.Count; i++)
                alphabet += dgvStates.Rows[i].Cells[0].Value.ToString();
            if (Analyzer.alphabetAnalysis(dgvStates, alphabet))
            {

                dgvRibbon = DGV.RibbonClear(dgvRibbon, alphabet);

                dgvStates = DGV.toWhite(dgvStates, 0);
                dgvStates.Rows[0].Cells[0].Style.BackColor = Color.Gray;
                dgvRibbon = DGV.toWhite(dgvRibbon, 1);
            }
            else
            alphabet = oldAlphabet;
        }

        #endregion

        #region Трасса
        //Сохранение трассы
        private bool saveTrack = true;
        //Трасса
        private List<string> fullTrack = new List<string>();

        //Узнаём, сохранять ли трассу
        private void checkBoxSaveTrack_CheckedChanged(object sender, EventArgs e)
        {
            saveTrack = checkBoxSaveTrack.Checked;
        }
        //Открыть трассу
        private void buttonOpenTrack_Click(object sender, EventArgs e)
        {
            ViewTrack viewTrack = new ViewTrack();
            viewTrack.StartPosition = FormStartPosition.CenterParent;
            viewTrack.delTrack();
            viewTrack.addTrack(fullTrack);
            viewTrack.ShowDialog();
        }
        //Сохранение трассы
        private void buttonSaveTrack_Click(object sender, EventArgs e)
        {
            File.saveTrack(fullTrack);
        }
        #endregion

        #region dgv
        //Для определения в какую ячейку ткнули
        private int currentMouseOverRow;
        private int currentMouseOverColumn;
        //Для контекстного меню и обработки нажатий по красным клеткам с ошибками
        private void dgvStates_MouseClick(object sender, MouseEventArgs e)
        {
            currentMouseOverRow = dgvStates.HitTest(e.X, e.Y).RowIndex;
            currentMouseOverColumn = dgvStates.HitTest(e.X, e.Y).ColumnIndex;
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                if ((currentMouseOverRow == 0) && (currentMouseOverColumn == 0))
                {
                    MenuItem addTo = new MenuItem("Добавить состояние");
                    MenuItem addAlp = new MenuItem("Добавить строку");
                    MenuItem formatStates = new MenuItem("Форматировать состояния");
                    MenuItem formatAlph = new MenuItem("Восстановить алфавит");

                    addTo.MenuItems.Add(new MenuItem("1"));
                    addTo.MenuItems.Add(new MenuItem("5"));
                    addTo.MenuItems.Add(new MenuItem("10"));

                    m.MenuItems.AddRange(new MenuItem[] { addTo, addAlp, formatStates, formatAlph });

                    m.MenuItems[0].MenuItems[0].Click += new System.EventHandler(this.add1);
                    m.MenuItems[0].MenuItems[1].Click += new System.EventHandler(this.add5);
                    m.MenuItems[0].MenuItems[2].Click += new System.EventHandler(this.add10);
                    m.MenuItems[1].Click += new System.EventHandler(this.m_addAlph);
                    m.MenuItems[2].Click += new System.EventHandler(this.m_formatStates);
                    m.MenuItems[3].Click += new System.EventHandler(this.m_formatAlph);

                }
                else
                if (currentMouseOverColumn == 0)
                {
                    MenuItem addAlp = new MenuItem("Добавить строку");
                    MenuItem delAlp = new MenuItem("Удалить строку");
                    MenuItem formatAlph = new MenuItem("Восстановить алфавит");

                    m.MenuItems.AddRange(new MenuItem[] { addAlp, delAlp, formatAlph });

                    m.MenuItems[0].Click += new System.EventHandler(this.m_addAlph);
                    m.MenuItems[1].Click += new System.EventHandler(this.m_deleteAlph);
                    m.MenuItems[2].Click += new System.EventHandler(this.m_formatAlph);
                }
                else
                if (currentMouseOverRow == 0)

                {
                    MenuItem addTo = new MenuItem("Добавить состояние");
                    addTo.MenuItems.Add(new MenuItem("1"));
                    addTo.MenuItems.Add(new MenuItem("5"));
                    addTo.MenuItems.Add(new MenuItem("10"));
                    MenuItem delCur = new MenuItem("Удалить состояние");
                    MenuItem format = new MenuItem("Форматировать состояния");

                    m.MenuItems.AddRange(new MenuItem[] { addTo, delCur, format });

                    m.MenuItems[0].MenuItems[0].Click += new System.EventHandler(this.add1);
                    m.MenuItems[0].MenuItems[1].Click += new System.EventHandler(this.add5);
                    m.MenuItems[0].MenuItems[2].Click += new System.EventHandler(this.add10);
                    m.MenuItems[1].Click += new System.EventHandler(this.m_deleteState);
                    m.MenuItems[2].Click += new System.EventHandler(this.m_formatStates);

                }
                if (currentMouseOverRow == 0 || currentMouseOverColumn == 0)
                    m.Show(dgvStates, new Point(e.X, e.Y));
            }
            //При любом нажатии на мышку осветляем эту ячейку, но не трогаем 0ые
            if (!(currentMouseOverRow == 0 && currentMouseOverColumn == 0) && (currentMouseOverRow >= 0 && currentMouseOverColumn >= 0))
                if (dgvStates.Rows[currentMouseOverRow].Cells[currentMouseOverColumn].Style.BackColor != Color.Yellow)
                    dgvStates.Rows[currentMouseOverRow].Cells[currentMouseOverColumn].Style.BackColor = Color.White;
        }
        //Очищение цвета ячейки Ribbon
        private void dgvRibbon_MouseClick(object sender, MouseEventArgs e)
        {
            currentMouseOverRow = dgvRibbon.HitTest(e.X, e.Y).RowIndex;
            currentMouseOverColumn = dgvRibbon.HitTest(e.X, e.Y).ColumnIndex;

            if (currentMouseOverRow > 0)
                if (dgvRibbon.Rows[currentMouseOverRow].Cells[currentMouseOverColumn].Style.BackColor != Color.Yellow)
                    dgvRibbon.Rows[currentMouseOverRow].Cells[currentMouseOverColumn].Style.BackColor = Color.White;
        }

        //Обработка нажатия удаления и добавления
        private int addCount;
        private void add1(object sender, System.EventArgs e)
        {
            addCount = 1;
            m_addStates(sender, e);
        }
        private void add5(object sender, System.EventArgs e)
        {
            addCount = 5;
            m_addStates(sender, e);
        }
        private void add10(object sender, System.EventArgs e)
        {
            addCount = 10;
            m_addStates(sender, e);
        }
        private void m_addStates(object sender, System.EventArgs e)
        {
            if (addCount + dgvStates.ColumnCount + 1 >= 100)
                if (MessageBox.Show("Количество состояний не может быть более 100\nЖелаете добавить до 100?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    addCount = 100 - dgvStates.ColumnCount + 1;
                else
                    addCount = 0;

            for (int i = 0; i < addCount; i++)
            {
                dgvStates.ColumnCount += 1;
                dgvStates.Rows[0].Cells[dgvStates.Columns.Count - 1].Value = "";
                dgvStates.Columns[dgvStates.Columns.Count - 1].Width = 50;
            }
        }
        private void m_deleteState(object sender, System.EventArgs e)
        {
            if (dgvStates.ColumnCount <3)
            {
                MessageBox.Show("Количество столбцов не может быть менее 1");
            }
            else
            {
                dgvStates.Columns.RemoveAt(currentMouseOverColumn);
            }
        }
        private void m_deleteAlph(object sender, System.EventArgs e)
        {
            if (dgvStates.RowCount > 3)
                dgvStates.Rows.RemoveAt(currentMouseOverRow);
            else
                MessageBox.Show("Количество строк не может быть менее 2 ");
        }
        private void m_addAlph(object sender, System.EventArgs e)
        {
            if (dgvStates.RowCount > 100)
            {
                MessageBox.Show("Количество строк не может быть более 100");
            }
            else
            {
                dgvStates.RowCount++;
                dgvStates.Rows[dgvStates.Rows.Count - 1].Cells[0].Value = "";
            }
        }
        private void m_formatStates(object sender, System.EventArgs e)
        {
            for (int i = 1; i < dgvStates.ColumnCount; i++)
                dgvStates.Rows[0].Cells[i].Value = "q" + (i - 1);
        }
        private void m_formatAlph(object sender, System.EventArgs e)
        {
            for (int i = 1; i < dgvStates.RowCount; i++)
                if (i <= 5)
                    dgvStates.Rows[i].Cells[0].Value = defaultAlphabet[i - 1];
        }
        #endregion

        #region Работа МТ
        //Метод, в котором блокируются кнопки и всё-всё-всё, которые не следует нажимать пользователю во время работы
        private void blockOnStart()
        {
            groupBoxOperands.Enabled = false;
            groupBoxTrack.Enabled = false;
            //  groupBoxWork.Enabled = false;
            radioButtonAuto.Enabled = false;
            radioButtonNow.Enabled = false;
            radioButtonStep.Enabled = false;
            trackBarSpeed.Enabled = false;
            алгоритмToolStripMenuItem.Enabled = false;
            buttonStep.Enabled = false;

            for (int i = 0; i < dgvRibbon.ColumnCount; i++)
                dgvRibbon.Rows[1].Cells[i].ReadOnly = true;

            for (int i = 0; i < dgvStates.ColumnCount; i++)
                for (int j = 0; j < dgvStates.RowCount; j++)
                    dgvStates.Rows[j].Cells[i].ReadOnly = true;

        }
        //Угадайте
        private void unblockOnFinish()
        {
            groupBoxOperands.Enabled = true;
            groupBoxTrack.Enabled = true;
            // groupBoxWork.Enabled = true;
            radioButtonAuto.Enabled = true;
            radioButtonNow.Enabled = true;
            radioButtonStep.Enabled = true;
            trackBarSpeed.Enabled = true;
            алгоритмToolStripMenuItem.Enabled = true;
            buttonStep.Enabled = false;
            buttonStart.Text = "Старт";
            buttonStep.Text = "Шаг";

            buttonStart.Enabled = true;

            if (saveTrack)
            {
                buttonOpenTrack.Enabled = true;
                buttonSaveTrack.Enabled = true;
            }

            for (int i = 0; i < dgvRibbon.ColumnCount; i++)
                dgvRibbon.Rows[1].Cells[i].ReadOnly = radioButtonForm.Checked;

            for (int i = 0; i < dgvStates.ColumnCount; i++)
                for (int j = 0; j < dgvStates.RowCount; j++)
                    dgvStates.Rows[j].Cells[i].ReadOnly = false;
        }

        //Список всех состояний
        private string[] states;
        //Индекс символа на ленте
        private int currentRibonIndex;
        //Сам символ на ленте
        private string currentRibonSymbol;
        //Индекс текущего состояния в правилах
        private int currentStateIndex;
        //Само текущее состояние 
        private string currentState;
        //Индс текущего символа в правилах
        private int currentAlphabetIndex;
        //Для окрашивания 
        private int colorIndexRibon;
        private int colorIndexStates1;
        private int colorIndexStates2;

        //Сдвиг
        private int shift;
        //Кнопка старта
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (buttonStart.Text == "Старт")
            {
                //Шаманство с алфавитом
                string oldAlphabet = alphabet;
                alphabet = "";
                for (int i = 1; i < dgvStates.Rows.Count; i++)
                    try {alphabet += dgvStates.Rows[i].Cells[0].Value.ToString();}
                    catch { dgvStates.Rows[i].Cells[0].Value = ""; }

                //Белим

                dgvStates = DGV.toWhite(dgvStates, 0);
                dgvStates.Rows[0].Cells[0].Style.BackColor = Color.Gray;
                dgvRibbon = DGV.toWhite(dgvRibbon, 1);

                dgvStates.ClearSelection();

                shift = 1;
                if (operandsModeForm)
                {
                    if (operandA + operandB + 1 + shift > dgvRibbon.ColumnCount)
                        dgvRibbon.ColumnCount += (operandA + operandB + 1 + 1) - dgvRibbon.ColumnCount;
                    for (int i=0; i<shift;i++)
                        dgvRibbon.Rows[1].Cells[i].Value = alphabet[0];
                    for (int i = shift; i < operandA + shift; i++)
                        dgvRibbon.Rows[1].Cells[i].Value = alphabet[2];
                    dgvRibbon.Rows[1].Cells[operandA + shift].Value = alphabet[1];
                    for (int i = operandA + 1 + shift; i < operandA + operandB + 1 + shift; i++)
                        dgvRibbon.Rows[1].Cells[i].Value = alphabet[2];
                    for (int i = operandA + operandB + 1 + shift; i < dgvRibbon.ColumnCount; i++)
                        dgvRibbon.Rows[1].Cells[i].Value = alphabet[0];

                    //dgvRibbonFormat();
                    dgvRibbon = DGV.RibbonFormat(dgvRibbon);

                }

                if (Analyzer.alphabetAnalysis(dgvStates,alphabet) && Analyzer.syntacticAnalysis(dgvStates,alphabet,states) && Analyzer.semanticAnalysis(dgvStates,dgvRibbon,alphabet,states) && Analyzer.ribbonAnalysis(dgvRibbon,alphabet))
                {
                    blockOnStart();

                    colorIndexRibon = 0;
                    colorIndexStates1 = 0;
                    colorIndexStates2 = 0;

                    start();
                }
                else
                    alphabet = oldAlphabet;
            }
            else
            if (buttonStart.Text == "Пауза")
            {
                trackBarSpeed.Enabled = true;
                timerAuto.Enabled = false;
                buttonStart.Text = "Продолжить";
            }
            else
                if (buttonStart.Text == "Продолжить")
            {
                trackBarSpeed.Enabled = false;
                timerAuto.Interval = speed;
                timerAuto.Enabled = true;
                buttonStart.Text = "Пауза";
            }
            else
                if (buttonStart.Text == "Стоп")
                step(true);
        }
        //Метод старта, в котором обработки нажатий кнопок и режимы работы
        private void start()
        {
            dgvRibbon.FirstDisplayedScrollingColumnIndex = 0;
            states = new string[dgvStates.ColumnCount];
            //Определяем
            for (int i = 1; i < states.Length; i++)
                states[i] = dgvStates.Rows[0].Cells[i].Value.ToString();
            currentRibonIndex = shift - 1;
            currentRibonSymbol = dgvRibbon.Rows[1].Cells[currentRibonIndex].Value.ToString();
            currentState = states[1];
            currentStateIndex = Array.IndexOf(states, currentState);
            currentAlphabetIndex = alphabet.IndexOf(currentRibonSymbol) + 1;

            fullTrack.Clear();

            switch (operatingMode)
            {
                case (1):
                    {
                        buttonStart.Text = "Стоп";
                        buttonStep.Enabled = true;
                        return;
                    }
                case (2):
                    {
                        buttonStep.Enabled = true;
                        buttonStep.Text = "Стоп";
                        timerAuto.Interval = speed;
                        timerAuto.Enabled = true;
                        buttonStart.Text = "Пауза";
                        return;
                    }
                case (3):
                    {
                        buttonStart.Enabled = false;
                        while (!step(false)) ;
                        return;
                    }
            }
        }
        //Пошаговая/стоп
        private void buttonStep_Click(object sender, EventArgs e)
        {
            if (buttonStep.Text == "Шаг")
                step(false);
            else
                if (buttonStep.Text == "Стоп")
            {
                buttonStep.Text = "Шаг";
                timerAuto.Enabled = false;
                step(true);
            }


        }
        private bool step(bool stop)
        {
            bool last = false;
            string[] words = {};

            try
            {
                if (saveTrack)
                {
                    string track = "";

                    for (int i = 0; i < dgvRibbon.ColumnCount; i++)
                        track += dgvRibbon.Rows[1].Cells[i].Value.ToString();

                    track = track.Replace(alphabet[0], '_');
                    fullTrack.Add(track);
                }
                words = dgvStates.Rows[currentAlphabetIndex].Cells[currentStateIndex].Value.ToString().Split(' ');

                currentState = words[0];
                currentStateIndex = Array.IndexOf(states, currentState);

                dgvRibbon.Rows[1].Cells[currentRibonIndex].Value = words[1];
                if (words[2] == "R")
                {
                    currentRibonIndex++;
                    currentRibonSymbol = dgvRibbon.Rows[1].Cells[currentRibonIndex].Value.ToString();
                    currentAlphabetIndex = alphabet.IndexOf(currentRibonSymbol) + 1;
                }
                if (words[2] == "L")
                {
                    currentRibonIndex--;
                    currentRibonSymbol = dgvRibbon.Rows[1].Cells[currentRibonIndex].Value.ToString();
                    currentAlphabetIndex = alphabet.IndexOf(currentRibonSymbol) + 1;
                }
                if (words[2] == "S")
                {
                    last = true;
                }

                currentAlphabetIndex = alphabet.IndexOf(currentRibonSymbol) + 1;

                dgvRibbon.Rows[1].Cells[colorIndexRibon].Style.BackColor = Color.White;
                dgvStates.Rows[colorIndexStates1].Cells[colorIndexStates2].Style.BackColor = Color.White;

                colorIndexRibon = currentRibonIndex;
                colorIndexStates1 = currentAlphabetIndex;
                colorIndexStates2 = currentStateIndex;

                if (checkBoxMove.Checked)
                {
                    if (colorIndexRibon - 11 + 1 > 0)
                        dgvRibbon.FirstDisplayedScrollingColumnIndex = colorIndexRibon - 11 + 1;
                    else
                        dgvRibbon.FirstDisplayedScrollingColumnIndex = 0;
                }


                dgvRibbon.Rows[1].Cells[colorIndexRibon].Style.BackColor = Color.Yellow;
                dgvStates.Rows[colorIndexStates1].Cells[colorIndexStates2].Style.BackColor = Color.Yellow;

                if (last || stop)
                {
                    timerAuto.Enabled = false;
                    unblockOnFinish();
                    dgvRibbon.Rows[1].Cells[colorIndexRibon].Style.BackColor = Color.White;
                    dgvStates.Rows[colorIndexStates1].Cells[colorIndexStates2].Style.BackColor = Color.White;
                }
                if (last)
                    MessageBox.Show("Конец выполнения");
                if (stop)
                    MessageBox.Show("Принудительное завершение");
            }
            catch
            {
                stop = true;
                last = true;
                timerAuto.Enabled = false;

                Color error = Color.OrangeRed;

                if (words.Length < 3)
                    MessageBox.Show("Ошибка при попытке визуализации\nОтсутствует соответствующий переход");
                else
                    if (currentRibonIndex >= dgvRibbon.ColumnCount)
                    MessageBox.Show("Ошибка при попытке визуализации\nАлгоритм уходит за правый край ленты");
                else
                    if (currentRibonIndex < 0)
                {
                    MessageBox.Show("Ошибка при попытке визуализации\nАлгоритм уходит за левый край ленты");
                    error = Color.Gray;
                }
                else
                    MessageBox.Show("Ошибка при попытке визуализации\nНепредвиденная ошибка");

                unblockOnFinish();
                dgvRibbon.Rows[1].Cells[colorIndexRibon].Style.BackColor = Color.Red;
                dgvStates.Rows[colorIndexStates1].Cells[colorIndexStates2].Style.BackColor = error;
            }
            return last || stop;
        }

        //Таймер
        private void timerAuto_Tick(object sender, EventArgs e)
        {
            step(false);
        }
        #endregion
    }
}