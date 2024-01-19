using ClassLibrary.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Tur:Kayit
    {
        public string Adi { get; set; }

        public Tur(string adi,int id):base(id)
        {
            Adi = adi;  
        }
    }
}
