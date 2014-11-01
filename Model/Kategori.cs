using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Kategori
    {
        public int KatId { get; set; }
        public string KatNavn {get; set;}
        public List<Kategori> Kategorier { get; set; }
    }
}

