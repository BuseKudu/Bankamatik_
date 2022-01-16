using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankamatik_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             BANKA
            Musteri: TC,Ad,Soyad,Bakiye,Telefon,Adres

            * Kayıt
            * Giriş
                * ParaÇekme
                * ParaYatırma
                * Kredi Çekme -> Limit:bakiye*5 
                *                Vade:Çekilen miktar 1-10000 max 12 ay  100001-1000000 24 ay
                *                Ödenecek Tutar: 12 ay cekilenmiktar * 1.24
                *                                24 ay cekilenmiktar * 2.18
                * 
             */
          
            Musteri m = new Musteri();
            #region          ********************  YENİ KAYIT  ********************         
            while (true)            
            {
                Console.WriteLine("***********HOŞGELDİNİZ***********");
                Console.WriteLine("Lütfen Kayıt Oluşturunuz:");
                Musteri.YeniKayit(m);
                Console.WriteLine("**********Kayıt Başarılı!**********");
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            #endregion
            #region       ********************    ANAMENÜ  ********************
                while (true)        
                {
                    
                    Musteri.KullaniciGiris(m);
                    Musteri.MusteriYaz(m);
                    while (true)
                    {
                        
                        Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçiniz:\n**Para Çekme  = 1\n**Para Yatırma  = 2\n**Kredi Başvurusu  = 3\n**ÇIKIŞ = 4 ");
                        int secim = Convert.ToInt32(Console.ReadLine());

                        if (secim == 1)             /********************    Para Çekme   ********************/
                        {
                            Console.WriteLine("PARA ÇEKME");
                            Musteri.ParaCekme(m);
                            
                        }
                        else if (secim==2)          /********************    Para Yatırma    ********************/
                        {
                            Console.WriteLine("PARA YATIRMA");
                            Musteri.ParaYatırma(m);
                            
                        }
                        else if (secim == 3)        /********************      Kredi Başvurusu     ********************/
                        {
                            Console.WriteLine("KREDİ");
                            Musteri.KrediFaizHesapla(m);
                            
                        }
                        else if (secim==4)
                        {
                            Console.WriteLine($"İyi Günler {m._Ad} {m._IkinciAd} {m._Soyad}");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Geçersiz Tuşlama!!!");
                            
                        }
                        
                    }    
                    

                }
                #endregion
            }


            Console.ReadKey();
        }
    }
}
