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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayi_olustur, sayi1, sayi2, sayi3, sayi4, asilsayi, sayackac=0;
        //Hem formload kısmında hem de button_click kısmında kullanacağım değişkenleri golablde tanımladım

        public static int galatasaray()
        {
            Random rd = new Random(); //bir rastgele nesnesi oluşturdum
            int a, b, c, d, sayi; // gerekli değişkenleri atadım
            for (int i = 0; true; i++) //istediğim sayıyı oluşturana dek sürecek bir sonsuz dögü tasarladım
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
            label1.Hide(); //henüz tahmin olmadığı için tahmin sonucumu gizledim
            label3.Hide();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c, d, sayi, artisayac=0, eksisayac=0; // gerekli değişkenleri atadım
            sayackac++; //globalde tanımladığım sayacı arttırarak kullanıcın kaç kez deneme yaptığını bulacağım
            sayi = Int32.Parse(textBox1.Text); //kulanıcının girdisini aldım
            d = sayi % 10; //birler basamağını buldum
            sayi /= 10;//birler basamağını eksilttim
            c = sayi % 10;//onlar basamağını buldum
            sayi /= 10;//onlar basamağını eksilttim
            b = sayi % 10;//yüzler basamağını buldum
            sayi /= 10;//yüzler basamağını eksilttim
            a = sayi;//binler basamağını buldum
            if (a == b || a == 0 || a == c || a == d || b == c || b == d || c == d)
            //kullanıcı girdisinin 4 basamaklı olduğunu ve her rakamın birbirinden farklı olduğunu denetledim
            {
                MessageBox.Show("Bütün rakamları farklı olan 4 basamaklı bir sayı girmeniz gerekmektedir!");
                //hata durumunda, hata mesajı gönderdim
                label1.Hide();
                label3.Hide();
                //bir hata durumu söz konusu olduğu için tahmin sonucunu sakladım
            }
            else label1.Show(); label3.Show(); //hata yoksa tahmin sonucunu göstermeye devam ettim
            if (a == sayi1) // binler basamağını kontrol ettirdim
            {
                artisayac++;
            }
            if (b == sayi2) // yüzler basamağını kontrol ettirdim
            {
                artisayac++;
            }
            if (c == sayi3) //onlar basamağını kontrol ettirdim
            {
                artisayac++;
            }
            if (d == sayi4) //birler basamağını kontrol ettirdim
            {
                artisayac++;
            }
            if (a == sayi2 || a == sayi3 || a == sayi4) //binler basamağındaki sayıyı diğer sayılarda aradım
            {
                eksisayac++;
            }
            if (b == sayi1 || b == sayi3 || b == sayi4)// yüzler basamağındaki sayıyı diğer sayılarda aradım
            {
                eksisayac++;
            }
            if (c == sayi1 || c == sayi2 || c == sayi4)//onlar basamağındaki sayıyı diğer sayılarda aradım
            {
                eksisayac++;
            }
            if (d == sayi1 || d == sayi2 || d == sayi3)//birler basamağındaki sayıyı diğer sayılarda aradım
            {
                eksisayac++;
            }
            label1.Text = artisayac.ToString() + " sayi adet hem mevcut hem de yeri doğru"; //tahmin sonucunu ekrana yazdırdım
            label3.Text = eksisayac.ToString() + " sayi mevcut ancak yeri doğru değil";
            if(Int32.Parse(textBox1.Text) == asilsayi) //sonucun doğruluğunu denetledim
            {
                MessageBox.Show(sayackac.ToString() + " kerede bildiniz!"); //sayaç yardımı ile kaç kerede bildiğini ekrana yazdırdım
                Application.Exit(); //oyunu sona erdirdim
            }
        }
    }
}
