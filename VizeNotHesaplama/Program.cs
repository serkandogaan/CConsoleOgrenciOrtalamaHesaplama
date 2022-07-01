using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizeNotHesaplama
{
    class Program
    {
        class Ogrenciler
        {
            public string Adi;
            public string SoyAdi;
            private int VizeNotu;
            private int FinalNotu;

            public int Vize
            {
                get
                {
                    return VizeNotu;
                }
                set
                {
                    if (value < 0)
                    {
                        VizeNotu = 0;
                    }
                    else
                    {
                        VizeNotu = value;
                    }
                }
            }
            public int Final
            {
                get
                {
                    return FinalNotu;
                }
                set
                {
                    if (value < 0)
                    {
                        VizeNotu = 0;
                    }
                    else
                    {
                        FinalNotu = value;
                    }
                }
            }

            public Ogrenciler(string isim, string soyisim, int vizesonuc, int finalsonuc)
            {
                Adi = isim;
                SoyAdi = soyisim;
                Vize = vizesonuc;
                Final = finalsonuc;
            }
        }
        static VizeNotEntities db = new VizeNotEntities();
        static void Main(string[] args)
        {
            
            string GirilenOgrenciAdi, GirilenOgrenciSoyAdi;
            int GirilenOgrenciVizeNotu, GirilenOgrenciFinalNotu, DonemOrt;
            int secim = 100;
            while (secim != 0)
            {
                Console.WriteLine("1 - Öğrenci Ekleme \n2 - Öğrencileri Listele \n3 - Kalan Öğrencileri Listele \n0 - Çıkış ");
                secim = Convert.ToInt32(Console.ReadLine());
                if (secim == 1)
                {
                    Console.WriteLine("--- Oğrenci Not Girişi ---");
                    Console.WriteLine("Öğrenci Adını Giriniz : ");
                    GirilenOgrenciAdi = Console.ReadLine();
                    Console.WriteLine("Öğrenci Soyadını Giriniz : ");
                    GirilenOgrenciSoyAdi = Console.ReadLine();
                    Console.WriteLine("Öğrenci Vize Notunu Giriniz : ");
                    GirilenOgrenciVizeNotu = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Öğrenci Final Notunu Giriniz : ");
                    GirilenOgrenciFinalNotu = Convert.ToInt32(Console.ReadLine());

                    DonemOrt = (GirilenOgrenciVizeNotu * 40) / 100 + (GirilenOgrenciFinalNotu * 60) / 100;

                    if (DonemOrt >= 85)
                    {
                        OgrenciBilgileri ogrenci = new OgrenciBilgileri()
                        {
                            OgrenciAdi = GirilenOgrenciAdi,
                            OgrenciSoyadi = GirilenOgrenciSoyAdi,
                            OgrenciVizeNot = GirilenOgrenciVizeNotu,
                            OgrenciFinalNot = GirilenOgrenciFinalNotu,
                            OgrenciOrtalama = DonemOrt,
                            OgrenciHarfNotu = "AA",
                        };

                        db.OgrenciBilgileris.Add(ogrenci);
                        db.SaveChanges();

                    }
                    else if (DonemOrt >= 70 && DonemOrt < 85)
                    {
                        OgrenciBilgileri ogrenci = new OgrenciBilgileri()
                        {
                            OgrenciAdi = GirilenOgrenciAdi,
                            OgrenciSoyadi = GirilenOgrenciSoyAdi,
                            OgrenciVizeNot = GirilenOgrenciVizeNotu,
                            OgrenciFinalNot = GirilenOgrenciFinalNotu,
                            OgrenciOrtalama = DonemOrt,
                            OgrenciHarfNotu = "BB",
                        };

                        db.OgrenciBilgileris.Add(ogrenci);
                        db.SaveChanges();
                    }
                    else if (DonemOrt >= 50 && DonemOrt < 70)
                    {
                        OgrenciBilgileri ogrenci = new OgrenciBilgileri()
                        {
                            OgrenciAdi = GirilenOgrenciAdi,
                            OgrenciSoyadi = GirilenOgrenciSoyAdi,
                            OgrenciVizeNot = GirilenOgrenciVizeNotu,
                            OgrenciFinalNot = GirilenOgrenciFinalNotu,
                            OgrenciOrtalama = DonemOrt,
                            OgrenciHarfNotu = "CC",
                        };

                        db.OgrenciBilgileris.Add(ogrenci);
                        db.SaveChanges();
                    }
                    else if (DonemOrt < 50)
                    {
                        OgrenciBilgileri ogrenci = new OgrenciBilgileri()
                        {
                            OgrenciAdi = GirilenOgrenciAdi,
                            OgrenciSoyadi = GirilenOgrenciSoyAdi,
                            OgrenciVizeNot = GirilenOgrenciVizeNotu,
                            OgrenciFinalNot = GirilenOgrenciFinalNotu,
                            OgrenciOrtalama = DonemOrt,
                            OgrenciHarfNotu = "DD",
                        };

                        db.OgrenciBilgileris.Add(ogrenci);
                        db.SaveChanges();
                    }

                }

                else if (secim == 2)
                {
                    OgrencileriListele();
                }

                else if (secim == 3)
                {
                    KalanOgrencileriListele();
                }


            }


            Console.ReadKey();
        }

        public static void OgrencileriListele()
        {
            Console.WriteLine("Öğrenci Listesi \n Öğrenci Adı - Öğrenci Soy Adı - Vize - Final - Dönem Ortalama - Harf Notu");
            foreach (var ogrenciler in db.OgrenciBilgileris)
            {
                Console.WriteLine(ogrenciler.OgrenciAdi + " " + ogrenciler.OgrenciSoyadi + " " + ogrenciler.OgrenciVizeNot + " " + ogrenciler.OgrenciFinalNot + " " + ogrenciler.OgrenciOrtalama + " " + ogrenciler.OgrenciHarfNotu);
            }
            
        }

        public static void KalanOgrencileriListele()
        {
            Console.WriteLine("Kalan Öğrenci Listesi \n Öğrenci Adı - Öğrenci Soy Adı - Vize - Final - Dönem Ortalama - Harf Notu");
            foreach (var ogrenciler in db.OgrenciBilgileris.Where(x => x.OgrenciOrtalama < 50))
            {
                Console.WriteLine(ogrenciler.OgrenciAdi + " " + ogrenciler.OgrenciSoyadi + " " + ogrenciler.OgrenciVizeNot + " " + ogrenciler.OgrenciFinalNot + " " + ogrenciler.OgrenciOrtalama + " " + ogrenciler.OgrenciHarfNotu);
            }
        }


    }
}
