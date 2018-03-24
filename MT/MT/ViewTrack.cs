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
    public partial class ViewTrack : Form
    {
        public ViewTrack()
        {
            InitializeComponent();
        }
        private string toN(int i,int N)
        {
            string s = Convert.ToString(i);
            while (s.Length != N) s = "0" + s;
            return s;
        }
        public void delTrack()
        {
            richTextBoxTrack.Clear();
        }
        public void addTrack(List<string> fullTrack)
        {
            for(int i=0;i<fullTrack.Count;i++)
            richTextBoxTrack.Text += toN(i,Convert.ToString(fullTrack.Count).Length) + ". " + fullTrack[i] + "\n";
        }
    }
}
