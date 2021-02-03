using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev2
{
    public partial class FormName : Form
    {
        public FormName()
        {
            InitializeComponent();
        }


        private void FormName_Load(object sender, EventArgs e)
        {
            this.Owner.Enabled = false;
            this.ActiveControl = textBox1;
            //Form kapatılmadan oyun formuna müdahale edilmesini kapattım ki oyuncu konusunda sorunlar çıkmasın
        }

        private void FormName_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
            //oyuncu belirlendikten sonra oyuna devam edilebilir
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Controls.Find("labelName", true).First().Text = textBox1.Text;
            this.Close();
            //Oyuncu belirlendi
        }
    }
}
