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
    public partial class FormOynanis : Form
    {
        public FormOynanis()
        {
            InitializeComponent();
        }

        private void FormOynanis_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Oyun başladığında otomatik olarak her basamağı farklı, dört basamaklı bir sayı belirlenir. Oyuncu her defasında bu sayıyı bilmeye çalışacaktır. Her tahmininizde, tahminizin doğruluğuna göre size iki farklı dönüt sağlanacaktır. Bu dönütlere göre tahmininizi düzenleyip, oyunun aklında tuttuğu sayıyı bilmeye çalışmalısınız. Doğru tahminde bulunduğunuzda, oyunu kazanmış olacaksınız. İyi Oyunlar!";
            richTextBox1.Enabled = false;
            //Nasıl oynandığını yazdırdım
        }
    }
}
