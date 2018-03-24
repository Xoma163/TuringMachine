namespace MT
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBoxWork = new System.Windows.Forms.GroupBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.radioButtonNow = new System.Windows.Forms.RadioButton();
            this.radioButtonAuto = new System.Windows.Forms.RadioButton();
            this.radioButtonStep = new System.Windows.Forms.RadioButton();
            this.groupBoxOperands = new System.Windows.Forms.GroupBox();
            this.buttonClearRibbon = new System.Windows.Forms.Button();
            this.labelB = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.numericUpDownB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.radioButtonRibbon = new System.Windows.Forms.RadioButton();
            this.radioButtonForm = new System.Windows.Forms.RadioButton();
            this.groupBoxTrack = new System.Windows.Forms.GroupBox();
            this.buttonSaveTrack = new System.Windows.Forms.Button();
            this.buttonOpenTrack = new System.Windows.Forms.Button();
            this.checkBoxSaveTrack = new System.Windows.Forms.CheckBox();
            this.dgvStates = new System.Windows.Forms.DataGridView();
            this.dgvRibbon = new System.Windows.Forms.DataGridView();
            this.buttonStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.алгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стандартныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сложениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нОДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.руководствоПользователяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStep = new System.Windows.Forms.Button();
            this.timerAuto = new System.Windows.Forms.Timer(this.components);
            this.checkBoxMove = new System.Windows.Forms.CheckBox();
            this.groupBoxWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBoxOperands.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            this.groupBoxTrack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRibbon)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxWork
            // 
            this.groupBoxWork.Controls.Add(this.labelSpeed);
            this.groupBoxWork.Controls.Add(this.trackBarSpeed);
            this.groupBoxWork.Controls.Add(this.radioButtonNow);
            this.groupBoxWork.Controls.Add(this.radioButtonAuto);
            this.groupBoxWork.Controls.Add(this.radioButtonStep);
            this.groupBoxWork.Location = new System.Drawing.Point(14, 258);
            this.groupBoxWork.Name = "groupBoxWork";
            this.groupBoxWork.Size = new System.Drawing.Size(245, 100);
            this.groupBoxWork.TabIndex = 0;
            this.groupBoxWork.TabStop = false;
            this.groupBoxWork.Text = "Режим работы";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSpeed.Location = new System.Drawing.Point(126, 68);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(115, 13);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "15    50  100  250  500";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.LargeChange = 1;
            this.trackBarSpeed.Location = new System.Drawing.Point(122, 40);
            this.trackBarSpeed.Maximum = 5;
            this.trackBarSpeed.Minimum = 1;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(117, 45);
            this.trackBarSpeed.TabIndex = 3;
            this.trackBarSpeed.Value = 3;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // radioButtonNow
            // 
            this.radioButtonNow.AutoSize = true;
            this.radioButtonNow.Location = new System.Drawing.Point(7, 66);
            this.radioButtonNow.Name = "radioButtonNow";
            this.radioButtonNow.Size = new System.Drawing.Size(89, 17);
            this.radioButtonNow.TabIndex = 2;
            this.radioButtonNow.Text = "Мгновенный";
            this.radioButtonNow.UseVisualStyleBackColor = true;
            this.radioButtonNow.CheckedChanged += new System.EventHandler(this.radioButtonNow_CheckedChanged);
            // 
            // radioButtonAuto
            // 
            this.radioButtonAuto.AutoSize = true;
            this.radioButtonAuto.Checked = true;
            this.radioButtonAuto.Location = new System.Drawing.Point(7, 43);
            this.radioButtonAuto.Name = "radioButtonAuto";
            this.radioButtonAuto.Size = new System.Drawing.Size(109, 17);
            this.radioButtonAuto.TabIndex = 1;
            this.radioButtonAuto.TabStop = true;
            this.radioButtonAuto.Text = "Автоматический";
            this.radioButtonAuto.UseVisualStyleBackColor = true;
            this.radioButtonAuto.CheckedChanged += new System.EventHandler(this.radioButtonAuto_CheckedChanged);
            // 
            // radioButtonStep
            // 
            this.radioButtonStep.AutoSize = true;
            this.radioButtonStep.Location = new System.Drawing.Point(7, 20);
            this.radioButtonStep.Name = "radioButtonStep";
            this.radioButtonStep.Size = new System.Drawing.Size(84, 17);
            this.radioButtonStep.TabIndex = 0;
            this.radioButtonStep.Text = "Пошаговый";
            this.radioButtonStep.UseVisualStyleBackColor = true;
            this.radioButtonStep.CheckedChanged += new System.EventHandler(this.radioButtonStep_CheckedChanged);
            // 
            // groupBoxOperands
            // 
            this.groupBoxOperands.Controls.Add(this.buttonClearRibbon);
            this.groupBoxOperands.Controls.Add(this.labelB);
            this.groupBoxOperands.Controls.Add(this.labelA);
            this.groupBoxOperands.Controls.Add(this.numericUpDownB);
            this.groupBoxOperands.Controls.Add(this.numericUpDownA);
            this.groupBoxOperands.Controls.Add(this.radioButtonRibbon);
            this.groupBoxOperands.Controls.Add(this.radioButtonForm);
            this.groupBoxOperands.Location = new System.Drawing.Point(265, 258);
            this.groupBoxOperands.Name = "groupBoxOperands";
            this.groupBoxOperands.Size = new System.Drawing.Size(191, 100);
            this.groupBoxOperands.TabIndex = 1;
            this.groupBoxOperands.TabStop = false;
            this.groupBoxOperands.Text = "Операнды";
            // 
            // buttonClearRibbon
            // 
            this.buttonClearRibbon.Location = new System.Drawing.Point(92, 71);
            this.buttonClearRibbon.Name = "buttonClearRibbon";
            this.buttonClearRibbon.Size = new System.Drawing.Size(93, 23);
            this.buttonClearRibbon.TabIndex = 9;
            this.buttonClearRibbon.Text = "Очистить ленту";
            this.buttonClearRibbon.UseVisualStyleBackColor = true;
            this.buttonClearRibbon.Click += new System.EventHandler(this.buttonClearRibbon_Click);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Location = new System.Drawing.Point(126, 43);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(14, 13);
            this.labelB.TabIndex = 8;
            this.labelB.Text = "B";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(126, 19);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(14, 13);
            this.labelA.TabIndex = 7;
            this.labelA.Text = "A";
            // 
            // numericUpDownB
            // 
            this.numericUpDownB.Location = new System.Drawing.Point(143, 40);
            this.numericUpDownB.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownB.Name = "numericUpDownB";
            this.numericUpDownB.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownB.TabIndex = 6;
            this.numericUpDownB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownB.ValueChanged += new System.EventHandler(this.numericUpDownB_ValueChanged);
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.Location = new System.Drawing.Point(143, 16);
            this.numericUpDownA.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.Size = new System.Drawing.Size(42, 20);
            this.numericUpDownA.TabIndex = 5;
            this.numericUpDownA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownA.ValueChanged += new System.EventHandler(this.numericUpDownA_ValueChanged);
            // 
            // radioButtonRibbon
            // 
            this.radioButtonRibbon.AutoSize = true;
            this.radioButtonRibbon.Location = new System.Drawing.Point(6, 43);
            this.radioButtonRibbon.Name = "radioButtonRibbon";
            this.radioButtonRibbon.Size = new System.Drawing.Size(71, 17);
            this.radioButtonRibbon.TabIndex = 4;
            this.radioButtonRibbon.Text = "На ленте";
            this.radioButtonRibbon.UseVisualStyleBackColor = true;
            this.radioButtonRibbon.CheckedChanged += new System.EventHandler(this.radioButtonRibbon_CheckedChanged);
            // 
            // radioButtonForm
            // 
            this.radioButtonForm.AutoSize = true;
            this.radioButtonForm.Checked = true;
            this.radioButtonForm.Location = new System.Drawing.Point(6, 20);
            this.radioButtonForm.Name = "radioButtonForm";
            this.radioButtonForm.Size = new System.Drawing.Size(76, 17);
            this.radioButtonForm.TabIndex = 3;
            this.radioButtonForm.TabStop = true;
            this.radioButtonForm.Text = "На форме";
            this.radioButtonForm.UseVisualStyleBackColor = true;
            this.radioButtonForm.CheckedChanged += new System.EventHandler(this.radioButtonForm_CheckedChanged);
            // 
            // groupBoxTrack
            // 
            this.groupBoxTrack.Controls.Add(this.buttonSaveTrack);
            this.groupBoxTrack.Controls.Add(this.buttonOpenTrack);
            this.groupBoxTrack.Controls.Add(this.checkBoxSaveTrack);
            this.groupBoxTrack.Location = new System.Drawing.Point(462, 258);
            this.groupBoxTrack.Name = "groupBoxTrack";
            this.groupBoxTrack.Size = new System.Drawing.Size(164, 100);
            this.groupBoxTrack.TabIndex = 1;
            this.groupBoxTrack.TabStop = false;
            this.groupBoxTrack.Text = "Трасса";
            // 
            // buttonSaveTrack
            // 
            this.buttonSaveTrack.Enabled = false;
            this.buttonSaveTrack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSaveTrack.Location = new System.Drawing.Point(83, 43);
            this.buttonSaveTrack.Name = "buttonSaveTrack";
            this.buttonSaveTrack.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveTrack.TabIndex = 2;
            this.buttonSaveTrack.Text = "Сохранить";
            this.buttonSaveTrack.UseVisualStyleBackColor = true;
            this.buttonSaveTrack.Click += new System.EventHandler(this.buttonSaveTrack_Click);
            // 
            // buttonOpenTrack
            // 
            this.buttonOpenTrack.Enabled = false;
            this.buttonOpenTrack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOpenTrack.Location = new System.Drawing.Point(6, 43);
            this.buttonOpenTrack.Name = "buttonOpenTrack";
            this.buttonOpenTrack.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenTrack.TabIndex = 1;
            this.buttonOpenTrack.Text = "Открыть";
            this.buttonOpenTrack.UseVisualStyleBackColor = true;
            this.buttonOpenTrack.Click += new System.EventHandler(this.buttonOpenTrack_Click);
            // 
            // checkBoxSaveTrack
            // 
            this.checkBoxSaveTrack.AutoSize = true;
            this.checkBoxSaveTrack.Checked = true;
            this.checkBoxSaveTrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveTrack.Location = new System.Drawing.Point(6, 17);
            this.checkBoxSaveTrack.Name = "checkBoxSaveTrack";
            this.checkBoxSaveTrack.Size = new System.Drawing.Size(116, 17);
            this.checkBoxSaveTrack.TabIndex = 0;
            this.checkBoxSaveTrack.Text = "Сохранять трассу";
            this.checkBoxSaveTrack.UseVisualStyleBackColor = true;
            this.checkBoxSaveTrack.CheckedChanged += new System.EventHandler(this.checkBoxSaveTrack_CheckedChanged);
            // 
            // dgvStates
            // 
            this.dgvStates.AllowUserToAddRows = false;
            this.dgvStates.AllowUserToDeleteRows = false;
            this.dgvStates.AllowUserToResizeColumns = false;
            this.dgvStates.AllowUserToResizeRows = false;
            this.dgvStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStates.ColumnHeadersVisible = false;
            this.dgvStates.Location = new System.Drawing.Point(14, 100);
            this.dgvStates.MultiSelect = false;
            this.dgvStates.Name = "dgvStates";
            this.dgvStates.RowHeadersVisible = false;
            this.dgvStates.Size = new System.Drawing.Size(612, 153);
            this.dgvStates.TabIndex = 2;
            this.dgvStates.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvStates_MouseClick);
            // 
            // dgvRibbon
            // 
            this.dgvRibbon.AllowUserToAddRows = false;
            this.dgvRibbon.AllowUserToDeleteRows = false;
            this.dgvRibbon.AllowUserToResizeColumns = false;
            this.dgvRibbon.AllowUserToResizeRows = false;
            this.dgvRibbon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRibbon.ColumnHeadersVisible = false;
            this.dgvRibbon.Location = new System.Drawing.Point(14, 29);
            this.dgvRibbon.MultiSelect = false;
            this.dgvRibbon.Name = "dgvRibbon";
            this.dgvRibbon.RowHeadersVisible = false;
            this.dgvRibbon.Size = new System.Drawing.Size(612, 65);
            this.dgvRibbon.TabIndex = 3;
            this.dgvRibbon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvRibbon_MouseClick);
            // 
            // buttonStart
            // 
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStart.Location = new System.Drawing.Point(544, 364);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(82, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.алгоритмToolStripMenuItem,
            this.руководствоПользователяToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // алгоритмToolStripMenuItem
            // 
            this.алгоритмToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.стандартныеToolStripMenuItem});
            this.алгоритмToolStripMenuItem.Name = "алгоритмToolStripMenuItem";
            this.алгоритмToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.алгоритмToolStripMenuItem.Text = "Алгоритм";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.новыйToolStripMenuItem.Text = "Новый";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьАлгоритмToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьАлгоритмКакToolStripMenuItem_Click);
            // 
            // стандартныеToolStripMenuItem
            // 
            this.стандартныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сложениеToolStripMenuItem,
            this.нОДToolStripMenuItem});
            this.стандартныеToolStripMenuItem.Name = "стандартныеToolStripMenuItem";
            this.стандартныеToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.стандартныеToolStripMenuItem.Text = "Стандартные";
            // 
            // сложениеToolStripMenuItem
            // 
            this.сложениеToolStripMenuItem.Name = "сложениеToolStripMenuItem";
            this.сложениеToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.сложениеToolStripMenuItem.Text = "Сложение";
            this.сложениеToolStripMenuItem.Click += new System.EventHandler(this.сложениеToolStripMenuItem_Click);
            // 
            // нОДToolStripMenuItem
            // 
            this.нОДToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.нОДToolStripMenuItem.Name = "нОДToolStripMenuItem";
            this.нОДToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.нОДToolStripMenuItem.Text = "Умножение";
            this.нОДToolStripMenuItem.Click += new System.EventHandler(this.нОДToolStripMenuItem_Click);
            // 
            // руководствоПользователяToolStripMenuItem
            // 
            this.руководствоПользователяToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.руководствоПользователяToolStripMenuItem.Name = "руководствоПользователяToolStripMenuItem";
            this.руководствоПользователяToolStripMenuItem.Size = new System.Drawing.Size(166, 20);
            this.руководствоПользователяToolStripMenuItem.Text = "Руководство пользователя";
            this.руководствоПользователяToolStripMenuItem.Click += new System.EventHandler(this.руководствоПользователяToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // buttonStep
            // 
            this.buttonStep.Enabled = false;
            this.buttonStep.Location = new System.Drawing.Point(462, 364);
            this.buttonStep.Name = "buttonStep";
            this.buttonStep.Size = new System.Drawing.Size(75, 23);
            this.buttonStep.TabIndex = 11;
            this.buttonStep.Text = "Шаг";
            this.buttonStep.UseVisualStyleBackColor = true;
            this.buttonStep.Click += new System.EventHandler(this.buttonStep_Click);
            // 
            // timerAuto
            // 
            this.timerAuto.Tick += new System.EventHandler(this.timerAuto_Tick);
            // 
            // checkBoxMove
            // 
            this.checkBoxMove.AutoSize = true;
            this.checkBoxMove.Location = new System.Drawing.Point(14, 361);
            this.checkBoxMove.Name = "checkBoxMove";
            this.checkBoxMove.Size = new System.Drawing.Size(100, 17);
            this.checkBoxMove.TabIndex = 12;
            this.checkBoxMove.Text = "Двигать ленту";
            this.checkBoxMove.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 390);
            this.Controls.Add(this.checkBoxMove);
            this.Controls.Add(this.buttonStep);
            this.Controls.Add(this.dgvStates);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.dgvRibbon);
            this.Controls.Add(this.groupBoxTrack);
            this.Controls.Add(this.groupBoxOperands);
            this.Controls.Add(this.groupBoxWork);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Машина Тьюринга";
            this.groupBoxWork.ResumeLayout(false);
            this.groupBoxWork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBoxOperands.ResumeLayout(false);
            this.groupBoxOperands.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            this.groupBoxTrack.ResumeLayout(false);
            this.groupBoxTrack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRibbon)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxWork;
        private System.Windows.Forms.RadioButton radioButtonNow;
        private System.Windows.Forms.RadioButton radioButtonAuto;
        private System.Windows.Forms.RadioButton radioButtonStep;
        private System.Windows.Forms.GroupBox groupBoxOperands;
        private System.Windows.Forms.RadioButton radioButtonRibbon;
        private System.Windows.Forms.RadioButton radioButtonForm;
        private System.Windows.Forms.GroupBox groupBoxTrack;
        private System.Windows.Forms.CheckBox checkBoxSaveTrack;
        private System.Windows.Forms.NumericUpDown numericUpDownB;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Button buttonOpenTrack;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem алгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem руководствоПользователяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem стандартныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сложениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нОДToolStripMenuItem;
        private System.Windows.Forms.Button buttonStep;
        private System.Windows.Forms.DataGridView dgvRibbon;
        public System.Windows.Forms.DataGridView dgvStates;
        private System.Windows.Forms.Timer timerAuto;
        private System.Windows.Forms.Button buttonSaveTrack;
        private System.Windows.Forms.CheckBox checkBoxMove;
        private System.Windows.Forms.Button buttonClearRibbon;
    }
}

