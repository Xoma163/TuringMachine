using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MT
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            labelDev.Text = "Разработчики:" + "\n"+"студенты группы 6401-090301D"+"\n"+"Постников А.С."+"\n"+"Терёхин А.А."+"\n"+"Шапошников А.А.";

            foreach (Label label in this.Controls.OfType<Label>())
                label.Left= (this.Width  - label.Width) / 2-7;

            labelDev.Left = 10;
        }
    }
}