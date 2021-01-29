using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Odev2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayi_olustur, sayi1, sayi2, sayi3, sayi4, asilsayi, sayackac;
        bool darkTheme = false;

        private void koyuTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!darkTheme)
            {
                foreach (var lbl in Controls.OfType<Label>())
                {
                    lbl.ForeColor = Color.LightSteelBlue;
                    if (lbl.Name == label1.Name)
                    {
                        lbl.ForeColor = Color.GreenYellow;
                    }

                    if (lbl.Name == label3.Name)
                    {
                        lbl.ForeColor = Color.Tomato;
                    }
                }
                this.BackColor = Color.FromArgb(35, 40, 50);
                foreach (var item in menuStrip1.Items.OfType<ToolStripMenuItem>())
                {
                    item.ForeColor = Color.LightSteelBlue;
                }
                textBox1.BackColor = Color.FromArgb(45, 50, 60);
                textBox1.ForeColor = Color.White;
                button1.BackColor = Color.LightSlateGray;
                button1.FlatStyle = FlatStyle.Popup;
                menuStrip1.Items[2].Text = "Açık Tema";
                darkTheme = true;
            }
            else
            {
                foreach (var lbl in Controls.OfType<Label>())
                {
                    lbl.ForeColor = Color.Black;
                    if (lbl.Name == label1.Name)
                    {
                        lbl.ForeColor = Color.DarkGreen;
                    }

                    if (lbl.Name == label3.Name)
                    {
                        lbl.ForeColor = Color.DarkRed;
                    }
                }
                this.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                foreach (var item in menuStrip1.Items.OfType<ToolStripMenuItem>())
                {
                    item.ForeColor = Color.Black;
                }
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                button1.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                button1.FlatStyle = FlatStyle.Standard;
                menuStrip1.Items[2].Text = "Koyu Tema";
                darkTheme = false;
            }
        }
        private void acikTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        //Hem formload kısmında hem de button_click kısmında kullanacağım değişkenleri golablde tanımladım

        public static int galatasaray()
        {
            Random rd = new Random(); //bir rastgele nesnesi oluşturdum
            int a, b, c, d, sayi; // gerekli değişkenleri atadım
            while(true) //istediğim sayıyı oluşturana dek sürecek bir sonsuz dögü tasarladım
            {
                a = rd.Next(0, 10); //binler basamağını atadım
                b = rd.Next(0, 10);//yüzler basamağını atadım
                c = rd.Next(0, 10);//onlar basamağını atadım
                d = rd.Next(0, 10);//birler basamağını atadım
                if (a != b && a != 0 && a != c && a != d && b != c && b != d && c != d)
                //her rakamın farklı olduğunu ve sayının 4 rakamdan oluştuğunu kontrol ettirdim
                {
                    break;
                    //sonsuz döngüyü kırdım
                }
            }
            sayi = (a * 1000) + (b * 100) + (c * 10) + d; //sayımı oluşturdum
            return sayi; //oluşturduğum sayıyı dışarıya verdim
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FormName frmname = new FormName();
            frmname.Owner = this;
            frmname.Show();
            sayackac = 0;
            label1.Hide(); //henüz tahmin olmadığı için tahmin sonucumu gizledim
            label3.Hide();
            label8.Hide();
            labelGiris.Hide();
            sayi_olustur = galatasaray();
            //Oluşturduğum bir başka class içindeki metod yardımı ile rakamları farklı 4 basamaklı rastgele sayımı oluşturdum
            asilsayi = sayi_olustur; //sayı üzerinde denetim yapabilmem için sayimi değişkene sabitledim
            sayi4 = sayi_olustur % 10; //birler basamağını buldum
            sayi_olustur /= 10; //birler basamağını eksilttim
            sayi3 = sayi_olustur % 10; //onlar basamağını buldum
            sayi_olustur /= 10; //onlar basamağını eksilttim
            sayi2 = sayi_olustur % 10; //yüzler basamağını buldum
            sayi_olustur /= 10; //yüzler basamağını eksilttim
            sayi1 = sayi_olustur; //binler basamağını buldum
            string skorlar = File.ReadAllText(Environment.CurrentDirectory + @"\highscore.txt");
            int pos = skorlar.IndexOf(':');
            skorlar = skorlar.Substring(pos+1);
            labelHigh.Text = skorlar;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, d, sayi, yerdogru=0, sayidogru=0; // gerekli değişkenleri atadım
            sayackac++; //globalde tanımladığım sayacı arttırarak kullanıcın kaç kez deneme yaptığını bulacağım
            labelScore.Text = sayackac.ToString();
            sayi = Int32.Parse(textBox1.Text); //kulanıcının girdisini aldım
            d = sayi % 10; //birler basamağını buldum
            sayi /= 10;//birler basamağını eksilttim
            c = sayi % 10;//onlar basamağını buldum
            sayi /= 10;//onlar basamağını eksilttim
            b = sayi % 10;//yüzler basamağını buldum
            sayi /= 10;//yüzler basamağını eksilttim
            a = sayi;//binler basamağını buldum
            if (a == b || a == 0 || a == c || a == d || b == c || b == d || c == d || textBox1.Text.Length != 4)
            //kullanıcı girdisinin 4 basamaklı olduğunu ve her rakamın birbirinden farklı olduğunu denetledim
            {
                MessageBox.Show("Bütün rakamları farklı olan 4 basamaklı bir sayı girmeniz gerekmektedir!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //hata durumunda, hata mesajı gönderdim
            }
            else
            {
                labelGiris.Text = textBox1.Text;
                label1.Show();
                label3.Show();
                label8.Show();
                labelGiris.Show();
                //hata yoksa tahmin sonucunu ve son tahmini göstermeye devam ettim
            }
            if (a == sayi1) // binler basamağını kontrol ettirdim
            {
                yerdogru++;
            }
            if (b == sayi2) // yüzler basamağını kontrol ettirdim
            {
                yerdogru++;
            }
            if (c == sayi3) //onlar basamağını kontrol ettirdim
            {
                yerdogru++;
            }
            if (d == sayi4) //birler basamağını kontrol ettirdim
            {
                yerdogru++;
            }
            if (a == sayi2 || a == sayi3 || a == sayi4) //binler basamağındaki sayıyı diğer sayılarda aradım
            {
                sayidogru++;
            }
            if (b == sayi1 || b == sayi3 || b == sayi4)// yüzler basamağındaki sayıyı diğer sayılarda aradım
            {
                sayidogru++;
            }
            if (c == sayi1 || c == sayi2 || c == sayi4)//onlar basamağındaki sayıyı diğer sayılarda aradım
            {
                sayidogru++;
            }
            if (d == sayi1 || d == sayi2 || d == sayi3)//birler basamağındaki sayıyı diğer sayılarda aradım
            {
                sayidogru++;
            }
            label1.Text = yerdogru.ToString() + " sayi adet hem mevcut hem de yeri doğru"; //tahmin sonucunu ekrana yazdırdım
            label3.Text = sayidogru.ToString() + " sayi mevcut ancak yeri doğru değil";
            if(Int32.Parse(textBox1.Text) == asilsayi) //sonucun doğruluğunu denetledim
            {
                if (Int32.Parse(labelScore.Text) <= Int32.Parse(labelHigh.Text))
                {
                    File.WriteAllText(Environment.CurrentDirectory + @"\highscore.txt", labelName.Text + ":" + sayackac.ToString() + "\r\n");
                }
                DialogResult dr = MessageBox.Show(sayackac.ToString() + " kerede bildiniz! Tekrar Oynamak İster Misiniz?","Tebrikler!",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                //Oyuncuya tekrar oynamak isteyip istemediğini sordum ve sonuca göre oyunu tekrar başlattım veya kapattım
                if (dr == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
            textBox1.Text = "";
            //Oyunun oynanma hızı ve kolaylığı açısından textboxu sıfırladım.
            //Oyuncu, son tahminini soldaki labeldan görmeye devam edebilecek
        }
    }
}
