using ClassLibrary.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Yonetmen:Kayit
    {
            public string Adi { get; set; }

            public string Soyadi { get; set; }



        public Yonetmen(string adi, string soyadi,int id):base(id)
        {
            Adi = adi;
            Soyadi = soyadi;
        }

        public Yonetmen(string adi):base(-1)
        {
            Adi = Adi;
        }

        public string AdiSoyadi => (Adi + "" + Soyadi).Trim();
        public override string ToString() => AdiSoyadi;
       
    }
}
