using ClassLibrary.Data;
using ClassLibrary.Entities;
using ClassLibrary.Entities.Bases;
using ClassLibrary.Repositories;
using System.Globalization;

namespace ConsoleApp
{
    internal class Program
    {
        static FilmRepo filmRepo = new FilmRepo();
        static TurRepo turRepo = new TurRepo();
        static YonetmenRepo yonetmenRepo=new YonetmenRepo();


        static void Main(string[] args)
        {

            string giris = MenuGetir();

            while (giris != "0")
            {
                switch (giris)
                {
                    case "1":
                        FilmleriListele();
                        break;
                    case "2":
                        AdaGoreFilmleriListele();
                        break;
                    case "3":
                        IdyeGoreFilmleriListele();
                        break;
                    case "4":
                        FilmEkle();
                        break;
                    case "5":
                        FilmGuncelle();
                        break;

                    case "6":
                        FilmSil();
                        break;
                    default:
                        Console.WriteLine("Geçersiz işlem!");
                        break;
                }
                giris = MenuGetir();
            }
        }

       

        static string MenuGetir()
        {
            Console.WriteLine("\nİşlem seçiniz\n" +
                "0:Çıkış\n" + 
                "1:Tüm filmleri listele\n" +
                "2: Ada göre filmleri listele\n" +
                "3:ID'ye göre filmi\n" +
                "4:Film ekle\n" +
                "5:Film güncelle\n" +
                "6:Film sil");

            return Console.ReadLine().Trim();
        }


       static void Yazdir(Film film)
        {
            string filmText;
            string yonetmenText;
            string turlerText;

            filmText = $"\nFilm\n" +
                $"ID:{film.Id}\n" +
                $"Oluşturulma Tarihi:{film.OusturulmaTarihi.ToString("dd.MM.yyyy HH:mm:ss")}\n" +
                $"Adı:{film.Adi}\n" +
                $"Yapım yılı:{film.YapimYili}\n" +
                $"Gişesi:{film.Gisesi.ToString("N2",new CultureInfo("tr-TR"))}\n" +
                $"Gösterim Tarihi:{film.GösterimTarihi.ToString("dd.MM.yyyy")}\n" +
                $"Platform:{film.Platform}\n" +
                $"Yerli/yabancı:{(film.YerliMi ? "yerli" : "yabancı")}";
            yonetmenText = $"\nYönetmen\n" +
                $"Adı soyadı:{film.Yonetmeni.AdiSoyadi}";
               
            turlerText = "\nTürleri:";
            foreach(Tur tur in film.Turleri)
            {
                turlerText += tur.Adi + ", ";
            }
            turlerText = turlerText.TrimEnd(',',' ');
            Console.WriteLine(filmText + yonetmenText + turlerText);
        }
    
        static void Yazdir(List<Film> filmler)
        {
            Console.WriteLine("\n"+ Veriler.KayitSayisiMesajiGetir(filmler.Count));

            foreach(Film film in filmler)
            {
                Yazdir(film);
            }
        }

        static void Yazdir(List<Yonetmen> yonetmenler)
        {
            string yonetmenText;

            foreach(Yonetmen yonetmen in yonetmenler)
            {
                yonetmenText = $"\nYönetmen\n" +
                    $"ID:{yonetmen.Id}\n"+
                    $"Adı:{yonetmen.Adi}\n" +
                    $"Soyadı:{yonetmen.Soyadi}";
                Console.WriteLine(yonetmenText);
            }
        }

        static void Yazdir(List<Tur> turler)
        {
            string turText;
            foreach(Tur tur in turler)
            {
                turText = $"\nTür\n" +
                    $"ID:{tur.Id}\n" +
                    $"Adı:{tur.Adi}\n" +
                    $"Oluşturulma tarihi:{tur.OusturulmaTarihi.ToString("dd.MM.yyyy HH:mm:ss")}";
                Console.WriteLine(turText);
            }
        }

        static void FilmleriListele()
        {
            Yazdir(filmRepo.FilmleriGetir());
        }


        static void AdaGoreFilmleriListele()
        {
            Console.Write("\nFilmin Adı:");
            string adi = Console.ReadLine().Trim();
            Yazdir(filmRepo.FilmleriGetir(adi));
        }


        static void IdyeGoreFilmleriListele()
        {
            try
            {
                Console.Write("\nFilm ID:");

                int filmId = Convert.ToInt32(Console.ReadLine());
                Kayit film = filmRepo.KayitGetir(filmId);

                if (film != null)
                    Yazdir((Film)film);
                else
                    Console.WriteLine(Veriler.KayitBulunamadiMesaji);
            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
           

        }

        static Film FilmOlustur(int id=0)
        {
            if (id > 0)
            {
                Kayit mevcutFilm = filmRepo.KayitGetir(id);
                if (mevcutFilm == null)
                {
                    Console.WriteLine(Veriler.KayitBulunamadiMesaji);
                    return null;
                }
            }

            Console.Write("\nAdı:");
            string adi=Console.ReadLine();
            Console.Write("Yapım yılı:");
            short yapimYili = Convert.ToInt16(Console.ReadLine());
            Console.Write("Gişesi:");
            decimal gisesi = decimal.Parse(Console.ReadLine(),new CultureInfo("tr-TR"));
            Console.Write("Gösterim Tarihi(gün.ay.yıl): ");
            DateTime gosterimTarihi=DateTime.Parse(Console.ReadLine(),new CultureInfo("tr-Tr"));
            Console.Write("Platform (1:Sinema,2: Netflix,3:Amazon): ");
            Platform platform = (Platform)Convert.ToInt32(Console.ReadLine());
            Console.Write("Yerli (1) / Yabancı (2): ");
            bool yerliMi = Console.ReadLine()== "1" ? true:false;
            Yazdir(yonetmenRepo.YonetmenleriGetir());
            Console.Write("Yonetmen ID: ");
            int yonetmenId = int.Parse(Console.ReadLine());
            Kayit mevcutYonetmen = yonetmenRepo.KayitGetir(yonetmenId);
            if(mevcutYonetmen == null)
            {
                Console.WriteLine(Veriler.KayitBulunamadiMesaji);
                return null;
            }
            Yazdir(turRepo.TurleriGetir());
            Console.WriteLine("Tür ID'leri (girişi sonlandırmak için 0): ");
            List<int> turIdleri= new List<int>();
            int turId;
            Kayit tur;
            bool turHata = false;
            do
            {
                turId = Convert.ToInt32(Console.ReadLine());
                if (turId != 0)
                {
                    tur = turRepo.KayitGetir(turId);
                    if (tur == null)
                    {
                        Console.WriteLine(Veriler.KayitBulunamadiMesaji);
                        turHata = true;
                        break;
                    }

                }
                turIdleri.Add(turId);
            } while (turId != 0);
            if (turHata)
                turIdleri.Clear();
            return new Film()
            {
                Id = id,
                Adi = adi.Trim(),
                YapimYili = yapimYili,
                Gisesi = gisesi,
                GösterimTarihi = gosterimTarihi,
                Platform = platform,
                YerliMi = yerliMi,
                Yonetmeni = mevcutYonetmen as Yonetmen,
                Turleri = turRepo.TurleriGetir(turIdleri)

            };
        }





        static void FilmSil()
        {
            try
            {
                Console.WriteLine("\nFilm Silme");
                Yazdir(filmRepo.FilmleriGetir());
                Console.Write("\nFilm Id:");
                int filmId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(filmRepo.FilmSil(filmId));    
            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
        }

       

        static void FilmEkle()
        {
            try
            {
                Console.WriteLine("\nFilm ekleme:");
                Film film = FilmOlustur();
                Console.WriteLine(filmRepo.FilmEkle(film));

            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
        }

        static void FilmGuncelle()
        {
            try
            {
                Console.WriteLine("\nFilm güncelleme: ");
                Yazdir(filmRepo.FilmleriGetir());
                Console.Write("\nFilm ID: ");
                int filmId=int.Parse(Console.ReadLine());
                Film film = FilmOlustur(filmId);
                Console.WriteLine(filmRepo.FilmGüncelle(film));
            }
            catch
            {
                Console.WriteLine(Veriler.HataMesaji);
            }
        }
    }
}
