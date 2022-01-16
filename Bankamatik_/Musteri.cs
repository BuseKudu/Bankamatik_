using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankamatik_
{
    internal class Musteri
    {
        public int MusteriNo;
        private string Ad;
        private string IkinciAd;
        private string Soyad;
        private string TC;
        private Guid MusteriID;   
        private string Telefon;
        private string Adres;
        private string Sifre;
        private int Bakiye;
        public Musteri()
        {
            MusteriID = Guid.NewGuid();
        }
        public string _Ad
        {
            get { return Ad; }
            set { Ad = value; }
        }
        public string _IkinciAd
        {
            get { return IkinciAd; }
            set { IkinciAd = value; }
        }
        public string _Soyad
        {
            get { return Soyad; }  
            set { Soyad = value; }
        }
        public string _TC
        {
            get { return TC; }
            set
            {
                if (value.Length == 11)
                {
                    try
                    {
                        Convert.ToInt64(value);
                        TC = value;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        TC = "00000";
                    }
                }

                else
                    TC = string.Empty;
            }
        }
        
        public string _Telefon
        {
            get { return Telefon; }
            set { Telefon = value; }

        }

        public string _Adres
        {
            get { return Adres; }
            set { Adres = value; }
        }
        public string _Sifre
        {
            get { return Sifre; }
            set { Sifre = value; }
        }
        public int _Bakiye
        {
            get { return Bakiye; }
            set { Bakiye = value; }
        }
        #region Yeni Kayıt
        public static void YeniKayit(Musteri m)
        {
            #region           TC Kontrol 
            while (true)
            {
                Console.WriteLine("T.C. No:");
                string TCno = Console.ReadLine();
                if (TcDogrula(TCno)==false)
                {
                    Console.WriteLine("Geçersiz T.C. No! Tekrar Deneyiniz:");
                }
                else
                {
                    m._TC = TCno;
                    break;
                }
            }
            #endregion
            #region           İsim Kontrol
            while (true)    
            {
                Console.WriteLine("Adınız:");
                string isim=Console.ReadLine();
                if (IsimMi(isim)!="")
                {
                    Console.WriteLine("Hatalı Giriş!!!");                    
                }
                else
                {
                    m._Ad = isim;
                    break;
                }
            }
               Console.WriteLine("İkinci Adınız:");
               m._IkinciAd = Console.ReadLine();
            #endregion
            #region            Soyisim Kontrol 
            while (true)    
            {
                Console.WriteLine("Soyadınız:");
                string isim = Console.ReadLine();
                if (IsimMi(isim) != "")
                {
                    Console.WriteLine("Hatalı Giriş!!!");
                }
                else
                {
                    m._Soyad = isim;
                    break;
                }
            }
            #endregion
            #region          Telefon Kontrol
            while (true)    
            {
                Console.WriteLine("Lütfen Başına Sıfır Eklemeden Cep Telefonu Numaranızı Giriniz:");
                string telefon=Console.ReadLine();
                if (TelefonMu(telefon) != "")
                {
                    Console.WriteLine("Hatalı Giriş!!!");
                }
                else
                {
                    m._Telefon = telefon;
                    break;
                }
            }
            #endregion
            #region          Adres Kontrol
            while (true)   
            {
                Console.WriteLine("Lütfen Adres Giriniz:");
                string adres = Console.ReadLine();
                if (AdresMi(adres) != "")
                {
                    Console.WriteLine("Hatalı Giriş!!!");
                }
                else
                {
                    m._Adres = adres;
                    break;
                }
            }
            #endregion
            Random r = new Random();
            m._Bakiye = r.Next(0, 100000);
            #region        Şifre Kontrol
            while (true)
            {
                Console.WriteLine("Lütfen Bir Şifre Belirleyiniz:");
                string sifre = Console.ReadLine();
                if (SifreKurallari(sifre) != "")
                {
                    Console.WriteLine("Boş Bırakılamaz ve En Az 2 Hane Olmalıdır!!!");
                }
                else
                {
                    m._Sifre = sifre;
                    break;
                }
            }            
            while (true)
            {
                Console.WriteLine("Lütfen Şifrenizi Tekrar Giriniz:");
                string tsifre = Console.ReadLine();
                if (tsifre == m._Sifre)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Şifreler Eşleşmedi!!! Tekrar Deneyiniz!!!");
                }
            }
            #endregion

        }
        #endregion
        #region Ekrana Müşteri Yazdırma
        public static void MusteriYaz(Musteri m)
        {
            if (m.IkinciAd.Length>0)
            {
                Console.WriteLine($"{m._TC}{Environment.NewLine}{m._Ad} {m._IkinciAd} {m._Soyad}{Environment.NewLine}{m._Telefon}{Environment.NewLine}{m._Adres}{Environment.NewLine}Bakiye:{m._Bakiye} TL");
            }
            else
            {
                Console.WriteLine($"{m._TC}{Environment.NewLine}{m._Ad} {m._Soyad}{Environment.NewLine}{m._Telefon}{Environment.NewLine}{m._Adres}{Environment.NewLine}Bakiye:{m._Bakiye} TL");
            }
                
        }
        #endregion
        #region Kullanıcı Girişi
        public static bool KullaniciGiris(Musteri m)
        {      
            while (true)
            {
                Console.WriteLine("***********Lütfen Giriş Yapınız***********");
                Console.WriteLine("Lütfen T.C.No Giriniz:");
                string ktcno = Console.ReadLine();
                Console.WriteLine("Lütfen Şifrenizi Giriniz:");
                string ksifre = Console.ReadLine();
                if (ktcno == m._TC && ksifre == m._Sifre)
                {
                    Console.WriteLine("Giriş Başarılı!");
                    return true;
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlış T.C.No/Şifre Girdiniz!!");
                }
            }

            return false;
        }
        #endregion
        #region Kredi Faizi Hesaplama
        public static double KrediFaizHesapla(Musteri m)
        {
            while (true)
            {
                double cekilecektutar = KrediLimiti(m);
                double sonuc = 0;
                if (cekilecektutar > 0 && cekilecektutar < 10001) // Max 12 Ay Vade ve 1.24 Faiz
                {
                    Console.WriteLine("En Fazla 12 Ay Olmak Şartıyla, Kaç Ay Vade İstersiniz?");
                    int vade = Convert.ToInt32(Console.ReadLine());
                    double faiztutari = 0;
                    while (true)
                    {
                        if (vade>0 && vade<13)
                        {
                            faiztutari = ((cekilecektutar / 100) * 1.24) * vade ;
                            sonuc = faiztutari + cekilecektutar;
                            Console.WriteLine(faiztutari + "Tl Faiz Tutarıyla Toplam Ödemeniz Gereken Kredi Miktarı " + sonuc);
                            break;
                        }
                       
                        else
                        {
                            Console.WriteLine("En Az 1, En Fazla 12 Ay Vade Kullanabilirsiniz!");
                            
                        }
                    }
                }
                else if (cekilecektutar > 10001 && cekilecektutar < 100001) // Max 24 Ay Vade ve 2.18 Faiz
                {
                    Console.WriteLine("En Fazla 24 Ay Olmak Şartıyla, Kaç Ay Vade İstersiniz?");
                    int vade = Convert.ToInt32(Console.ReadLine());
                    double faiztutari = 0;
                    while (true)
                    {
                        if (vade > 0 && vade < 25)
                        {
                            faiztutari = ((cekilecektutar / 100) * 2.18) * vade;
                            sonuc = faiztutari + cekilecektutar;
                            Console.WriteLine(faiztutari+ "Tl Faiz Tutarıyla Toplam Ödemeniz Gereken Kredi Miktarı "+sonuc);
                            break;
                        }

                        else
                        {
                            Console.WriteLine("En Az 1, En Fazla 24 Ay Vade Kullanabilirsiniz!");
                            
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz Tutar!");
                }

                return sonuc;
                break;
            }
            
        }
        #endregion
        public static void ParaCekme(Musteri m)
        {         
            while (true)
            {
                Console.WriteLine("Mevcut Bakiyeniz: " + m._Bakiye + " TL");
                Console.WriteLine("Lütfen Çekmek İstediğiniz Tutarı Giriniz:");
                int tutar = Convert.ToInt32(Console.ReadLine());

                if (m._Bakiye>=tutar)
                {
                    int kalanbakiye = m._Bakiye - tutar;
                    Console.WriteLine("İşlem Başarılı!\nYeni Bakiyeniz: "+kalanbakiye+" TL");
                    break;
                }
                else
                {
                    Console.WriteLine("Yetersiz Bakiye!!!");
                }
            }
            
        }
   
        public static void ParaYatırma(Musteri m)
        {
            while (true)
            {
                Console.WriteLine("Lütfen Yatırmak İstediğiniz Tutarı Giriniz:");
                int tutar = Convert.ToInt32(Console.ReadLine());
                if (tutar > 0)
                {
                    m._Bakiye += tutar;
                    Console.WriteLine("İşlem Başarılı! Mevcut Bakiyeniz: " + m._Bakiye);
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz Tutar Girdiniz!!! Tekrar Deneyiniz!!");
                }
            }
                     
        }
       
        public static bool TcDogrula(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11 && tcKimlikNo[0] != 32)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }
       
        public static string SadeceRakamMı(string Yazı)
        {
            string mesaj = "";

            foreach (char karakter in Yazı)
            {
                if (!(karakter >= 48 && karakter <= 57))  // ASCII Char 48 == 0, ASCII Char 57 == 9
                {

                    if (karakter == 32)
                    {
                        mesaj += "Boşluk" + " karakterini kullanamazsınız.\n";
                    }
                    else
                    {
                        mesaj += karakter + " karakterini kullanamazsınız.\n";
                    }
                }
            }
            return mesaj;
        }

        public static string BosOlamaz(string Yazi)
        {
            string mesaj = "";

            if (Yazi.Length == 0)
            {
                mesaj += "Boş Geçilemez.";
            }
            return mesaj;
        }

        public static string BasaSıfırGelemez(string Yazi)
        {
            string mesaj = "";

            if (Yazi.Length > 0)
            {
                if (Yazi[0] == 48)   // ASCII Char 48 == 0
                {
                    mesaj += "Başa Sıfır Gelemez";
                }
            }

            return mesaj;
        }

        public static string SadeceHarfMi(string yazi)
        {
            string mesaj = "";

            foreach (char harf in yazi)
            {
                if (!
                           ((harf >= 65 && harf <= 90)  ||  //ASCII Char 65-90 Büyük Harfler
                            (harf >= 97 && harf <= 122) ||  //ASCII Char 97-122 Küçük Harfler
                            (harf == 199) ||                //ASCII Char 199 = Ç
                            (harf == 231) ||                //ASCII Char 231 = ç
                            (harf == 286) ||                //ASCII Char 286 = Ğ
                            (harf == 287) ||                //ASCII Char 287 = ğ
                            (harf == 304) ||                //ASCII Char 304 = İ
                            (harf == 305) ||                //ASCII Char 305 = ı
                            (harf == 214) ||                //ASCII Char 214 = Ö
                            (harf == 246) ||                //ASCII Char 246 = ö
                            (harf == 350) ||                //ASCII Char 350 = Ş
                            (harf == 351) ||                //ASCII Char 351 = ş
                            (harf == 220) ||                //ASCII Char 220 = Ü
                            (harf == 252)))                 //ASCII Char 252 = ü
                                            
                {
                    mesaj += harf + " Karakterini Giremezsiniz.\n";
                }
            }



            return mesaj;


        }

        public static string EnAzNHane(string yazi, int n)
        {
            string mesaj = "";

            if (yazi.Length < n)
            {
                mesaj += n.ToString() + " Haneden Küçük Olamaz.";
            }

            return mesaj;

        }

        public static string EnFazlaNHane(string yazi, int n)
        {
            string mesaj = "";

            if (yazi.Length > n)
            {
                mesaj += n.ToString() + " Haneden Büyük Olamaz.";
            }


            return mesaj;

        }

        public static string ĞİleBaslayamaz(string yazi)
        {
            string mesaj = "";


            if (yazi.Length > 0)
            {
                if (yazi[0] == 286 || yazi[0] == 287)
                {
                    mesaj += yazi[0] + " Karakteri Başa Gelemez.";
                }
            }


            return mesaj;
        }
        public static string WhiteSpaceBaslayamaz(string yazi)
        {
            string mesaj = "";


            if (yazi.Length > 0)        // ASCII Char 32 == White Space
            {
                if (yazi[0] == 32)
                {
                    mesaj += yazi[0] + " Karakteri Başa Gelemez.";
                }
            }


            return mesaj;
        }
        public static string IsimMi(string yazi)
        {
            string mesaj = "";

            mesaj += BosOlamaz(yazi);

            mesaj += EnAzNHane(yazi, 2);

            mesaj += SadeceHarfMi(yazi);

            mesaj += ĞİleBaslayamaz(yazi);


            return mesaj;
        }
        public static string TelefonMu(string numara)
        {
            string mesaj = "";

            mesaj += BosOlamaz(numara);

            mesaj += SadeceRakamMı(numara);

            mesaj += EnAzNHane(numara, 10);

            mesaj += BasaSıfırGelemez(numara);
            
            return mesaj;
        }
        public static string AdresMi(string yazi)
        {
            string mesaj = "";

            mesaj += BosOlamaz(yazi);

            mesaj += EnAzNHane(yazi, 2);

            mesaj += WhiteSpaceBaslayamaz(yazi);

            return mesaj;
        }

        public static string SifreKurallari(string sifre)
        {
            string mesaj = "";

            mesaj += BosOlamaz(sifre);

            mesaj += EnAzNHane(sifre, 2);

            mesaj += WhiteSpaceBaslayamaz(sifre);

            return mesaj;
        }
    
        public static double KrediLimiti(Musteri m)
        {
            while (true)
            {
                Console.WriteLine("Lütfen Çekmek İstediğiniz Tutarı Giriniz:");
                double cekilecektutar = Convert.ToDouble(Console.ReadLine());
                if (cekilecektutar<=m._Bakiye*5)
                {
                    return cekilecektutar;
                    break;
                }
                else
                {
                    double maxlimit=m._Bakiye*5;
                    Console.WriteLine("Kullanabileceğiniz Max. Kredi Tutarı: "+maxlimit);
                    cekilecektutar = 0;
                }
            }           
        }
    }
}
