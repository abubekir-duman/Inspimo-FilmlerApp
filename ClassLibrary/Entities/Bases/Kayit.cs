using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entities.Bases
{
    public abstract class Kayit
    {
        public int Id { get; set; }

        public DateTime OusturulmaTarihi { get; set; }

        protected Kayit(int id):this()
        {
            Id = id;
        }

        protected Kayit()
        {
            OusturulmaTarihi = DateTime.Now;
        }
    }
}
