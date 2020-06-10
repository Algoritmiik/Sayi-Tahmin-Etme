using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev2
{
    class HalilIbrahimCavusoglu
    {
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

    }
}