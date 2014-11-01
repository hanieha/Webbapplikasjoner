using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication1.Model
{
    public class Kunde
    {
        public int Kid { get; set; }

        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string Etternavn { get; set; }

        [Required(ErrorMessage = "Adressen må oppgis")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Epost må oppgis")]
        public string Epost { get; set; }

        [Required(ErrorMessage = "Postnr må oppgis")]
        public string Postnr { get; set; }

        [Required(ErrorMessage = "Adressen må oppgis")]
        public string Poststed { get; set; }

        [Required(ErrorMessage = "Adressen må oppgis")]
        public string Passord { get; set; }

        public List<Kunde> Kunder { get; set; }


        public bool Endre(int id, Kunde ekunde)
        {
            throw new NotImplementedException();
        }
    }
}
