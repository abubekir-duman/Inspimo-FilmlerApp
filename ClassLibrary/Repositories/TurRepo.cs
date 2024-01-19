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
    public class TurRepo : IRepo
    {

        public List<Tur> TurleriGetir()
        {
            return Veriler.Turler;
        }


        public Kayit KayitGetir(int id)
        {
            Tur tur = null;

            List<Tur> turler = TurleriGetir();

            foreach(Tur t in turler)
            {
                if (t.Id == id)
                {
                    tur = t;
                    break;
                }
            }
            return tur;
        }

        public List<Tur> TurleriGetir(List<int> turIdleri)
        {
            List<Tur> turler = new List<Tur>();
            List<Tur> mevcutTurler = TurleriGetir();

            foreach (int turId in turIdleri)
            {
                foreach (Tur mevcutTur in mevcutTurler)
                {
                    if (mevcutTur.Id == turId)
                    {
                        turler.Add(mevcutTur);
                        break;
                    }
                }
            }
            return turler;

        }

    }
}
