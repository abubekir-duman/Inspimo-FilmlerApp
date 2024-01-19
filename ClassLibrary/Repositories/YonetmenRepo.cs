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
    public class YonetmenRepo : IRepo
    {


        public List<Yonetmen> YonetmenleriGetir()
        {
            return Veriler.Yonetmenler;
        }


        public Kayit KayitGetir(int id)
        {
            Yonetmen yonetmen = null;

            var mevcutYonetmenler = YonetmenleriGetir();

            foreach(var mevcutYonetmen in mevcutYonetmenler)
            {
                if (mevcutYonetmen.Id == id)
                {
                    yonetmen = mevcutYonetmen;
                    break;
                }
            }
            return yonetmen;

        }


        //public List<Kayit> KayitlariGetir()
        //{
        //    List<Kayit> kayitlar = new List<Kayit>();
        //    List<Yonetmen> mevcutYonetmenler = Veriler.Yonetmenler;

        //    foreach(Yonetmen mevcutYonetmen in mevcutYonetmenler)
        //    {
        //        kayitlar.Add(mevcutYonetmen);
        //    }
        //    return kayitlar;
        //}
    }
}
