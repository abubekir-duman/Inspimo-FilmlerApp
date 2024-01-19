using ClassLibrary.Data;
using ClassLibrary.Entities;
using ClassLibrary.Entities.Bases;
using ClassLibrary.Repositories.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories
{
    public class FilmRepo : IRepo
    {

        public List<Film> FilmleriGetir()
        {
            return Veriler.Filmler;
        }

        public List<Film> FilmleriGetir(string adi)
        {
            List<Film> filmler = new List<Film>();
            List<Film> mevcutFilmler = FilmleriGetir();

            foreach (Film mevcutFilm in mevcutFilmler)
            {
                if (mevcutFilm.Adi.ToUpper().Contains(adi.ToUpper().Trim()))
                {
                    filmler.Add(mevcutFilm);
                }
                    

            }
            return filmler;
        }


        public Kayit KayitGetir(int id)
        {
            Film film = null;

            List<Film> mevcutFilmler = FilmleriGetir();

            foreach (Film mevcutFilm in mevcutFilmler)
            {
                if (mevcutFilm.Id == id)
                {
                    film = mevcutFilm;
                    break;
                }
            }
            return film;
        }

        public Film FilmGetir(string adi, int id = 0)
        {
            Film film = null;
            List<Film> mevcutFilmler = FilmleriGetir();

            foreach (Film mevcutFilm in mevcutFilmler)
            {
                if (id == 0 && mevcutFilm.Adi.Equals(adi, StringComparison.OrdinalIgnoreCase))
                {
                    film = mevcutFilm;
                    break;
                }
                else if (mevcutFilm.Id != id && mevcutFilm.Adi.Equals(adi, StringComparison.OrdinalIgnoreCase))
                {
                    film = mevcutFilm;
                    break;
                }
            }
            return film;
        }


        public string FilmEkle(Film film)
        {
            if (film.Turleri is null || film.Turleri.Count == 0)
                return "Filmin türleri girilmemiştir!";
            Film mevcutFilm = FilmGetir(film.Adi);
            if (mevcutFilm is not null)
                return "Girilen ada sahip film bulunmaktadır!";
            film.Id = Veriler.EnSonId++;
            Veriler.Filmler.Add(film);
            return "Film başarıyla eklendi.";

        }

        public string FilmGüncelle(Film film)
        {
            if (film.Turleri is null || film.Turleri.Count == 0)
                return "Filmin türleri girilmemiştir!";
            if (FilmGetir(film.Adi, film.Id) is not null)
                return "Girilen ada sahip film bulunmaktadır!";
            Kayit mevcutKayit = KayitGetir(film.Id);
            if (mevcutKayit is null)
                return Veriler.KayitBulunamadiMesaji;

            Film mevcutFilm = mevcutKayit as Film;
            mevcutFilm.Adi = film.Adi;
            mevcutFilm.YapimYili = film.YapimYili;
            mevcutFilm.Gisesi = film.Gisesi;
            mevcutFilm.Yonetmeni = film.Yonetmeni;
            mevcutFilm.Turleri = film.Turleri;
            mevcutFilm.GösterimTarihi = film.GösterimTarihi;
            mevcutFilm.YerliMi = film.YerliMi;
            mevcutFilm.Platform = film.Platform;
            return "Film başarıyla güncellendi.";


        }

        public string FilmSil(int id)
        {
            Kayit mevcutFilm = KayitGetir(id);
            if (mevcutFilm is null)
                return Veriler.KayitBulunamadiMesaji;
            Veriler.Filmler.Remove((Film)mevcutFilm);
            return "Film başarıyla silindi.";
        }
    }
}







        
