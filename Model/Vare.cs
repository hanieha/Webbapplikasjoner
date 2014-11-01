using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Vare
    {
        [Key]
        public int VareId { get; set; }
        public int LandId { get; set; }
        public int bid { get; set; }

        public string Navn { get; set; }
        public decimal Pris { get; set; }
        public int Antall { get; set; }
        public string VareArtUrl { get; set; }
        public Kategori Kategori { get; set; }
        public Land Land { get; set; }
       
        public virtual List<Salg> Bestillinger { get; set; }
    }
}