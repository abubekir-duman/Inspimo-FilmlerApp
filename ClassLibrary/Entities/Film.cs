﻿using ClassLibrary.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities
{
    public class Film:Kayit
    {
       

        public string Adi { get; set; }

        public short YapimYili { get; set; }

        public decimal Gisesi { get; set; }

        public bool YerliMi { get; set; }

        public DateTime GösterimTarihi { get; set; }

        public Platform Platform { get; set; }

        public Yonetmen Yonetmeni { get; set; }

        public List<Tur> Turleri { get; set; }

        public Film()
        {
            Turleri = new List<Tur>();
        }

    }

   
   

   
}
