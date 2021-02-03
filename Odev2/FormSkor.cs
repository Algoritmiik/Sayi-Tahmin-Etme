using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev2
{
    public partial class FormSkor : Form
    {
        public FormSkor()
        {
            InitializeComponent();
        }

        private void FormSkor_Load(object sender, EventArgs e)
        {
            string skor = File.ReadAllText(Environment.CurrentDirectory + @"\highscore.txt");
            int pos = skor.IndexOf(':');
            listBox1.Items.Add(skor.Substring(0, pos+1) + " " + skor.Substring(pos + 1));
            listBox1.Enabled = false;
        }
    }
}
