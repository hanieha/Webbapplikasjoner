using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class Admin
    {
        public int Aid { get; set; }

        [Required(ErrorMessage = "Fornavn må oppgis")]
        public string Fornavn { get; set; }

        [Required(ErrorMessage = "Etternavn må oppgis")]
        public string Etternavn { get; set; }

        [Required(ErrorMessage = "Adressen må oppgis")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Postnr må oppgis")]
        public string Postnr { get; set; }

        [Required(ErrorMessage = "Epost må oppgis")]
        public string Epost { get; set; }

        [Required(ErrorMessage = "Rolle må oppgis")]
        public string Rolle { get; set; }

        [Required(ErrorMessage = "Passord må oppgis")]
        public string Passord { get; set; }

        [Required(ErrorMessage = "Poststed må oppgis")]
        public string Poststed { get; set; }
    }
}