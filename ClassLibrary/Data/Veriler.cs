using ClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public static class Veriler
    {
        public static int EnSonId { get; set; } = 0;

        public static List<Film> Filmler { get; set; }

        public static List<Yonetmen> Yonetmenler { get; set; }

        public static List<Tur> Turler { get; set; }

        public static string KayitBulunamadiMesaji => "Kayıt bulunamadı.";

        public static string HataMesaji => "İşlem sırasında hata meydana geldi.";

        static Veriler()
        {
            Turler = new List<Tur>();
            Turler.Add(new Tur("Aksiyon", ++EnSonId));
            Turler.Add(new Tur("Bilim Kurgu", ++EnSonId));
            Turler.Add(new Tur("Suç", ++EnSonId));

            Yonetmenler = new List<Yonetmen>()
            {
                new Yonetmen()
                {
                    Id = ++EnSonId,
                    Adi="James",
                    Soyadi="Cameron"
                },
                new Yonetmen()
                {
                    Id = ++EnSonId,
                    Adi="Guy",
                    Soyadi="Ritchie"
                }
            };

            Filmler = new List<Film>();

            Film film = new Film()
            {
                Id = ++EnSonId,
                Adi = "Avatar",
                YapimYili = 2009,
                Gisesi = 1000000,
                GösterimTarihi = DateTime.Parse("10.12.2009", new CultureInfo("tr-Tr")),
                Platform = Platform.sinema
            };

            film.Yonetmeni = Yonetmenler.First();
            film.Turleri.Add(Turler[0]);
            film.Turleri.Add(Turler[1]);
            Filmler.Add(film);

            film = new Film()
            {
                Id = ++EnSonId,
                Adi = "Sherlock Holmes",
                YapimYili = 2009,
                Gisesi = 2000000,
                GösterimTarihi = DateTime.Parse("15.01.2010", new CultureInfo("tr-Tr")),
                Platform = Platform.sinema,
                Yonetmeni = Yonetmenler.Last()
            };

            film.Turleri.Add(Turler[0]);
            film.Turleri.Add(Turler[2]);
            Filmler.Add(film);

           

        }

        public static string KayitSayisiMesajiGetir(int kayitSayisi)
        {
            return kayitSayisi == 0 ? KayitBulunamadiMesaji : kayitSayisi + "kayıt bulundu";
        }




    }
}
