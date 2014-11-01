using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebApplication1.Model
{
    public class SampleData : DropCreateDatabaseIfModelChanges<DbContext> 
    {
        protected override void Seed(DbContext context)
        {
            var Kategorier = new List<Kategori>
            {
                new Kategori { KatNavn = "Rodvindvin" },
                new Kategori { KatNavn = "Hvitvin" },
                new Kategori { KatNavn = "Rosevin" },
                new Kategori { KatNavn = "Fruktvin" },
                new Kategori { KatNavn = "Sterkevin" },
                new Kategori { KatNavn = "Oll" },
                new Kategori { KatNavn = "Alkoholfritt" },
            };

            var Lands = new List<Land>
            {
                new Land { Navn = "Italia" },
                new Land { Navn = "Frankrike" },
                new Land { Navn = "Chile" },
                new Land { Navn = "Spania" },
                new Land { Navn = "Bulgaria" },
            };

            new List<Vare>
            {
                new Vare { Navn = "A Mano Aleatico 2009", Kategori = Kategorier.Single(g => g.KatNavn == "Rodvin"), Pris = 90, Land = Lands.Single(a => a.Navn =="Italia"), VareArtUrl = "/Content/Images/Rødvin1.jpg" },
                new Vare { Navn = "Abbona Barbaresco 2009", Kategori = Kategorier.Single(g => g.KatNavn == "Rodvin"), Pris = 80, Land = Lands.Single(a => a.Navn =="Frankrike"), VareArtUrl = "/Content/Images/Rødvin1.jpg" },
                new Vare { Navn = "Anno Domini Prosecco Frizzante", Kategori = Kategorier.Single(g => g.KatNavn == "Hvitvin"), Pris = 128, Land = Lands.Single(a => a.Navn == "Chile"), VareArtUrl = "/Content/Images/Hvitvin1.jpg" },
                new Vare { Navn = "Abbazia di Novacella Müller Thurgau 2013", Kategori = Kategorier.Single(g => g.KatNavn == "Hvitvin"), Pris = 118, Land = Lands.Single(a => a.Navn =="Spania"), VareArtUrl = "/Content/Images/Hvitvin2.jpg" },
                new Vare { Navn = "Alex Rosen Catarratto 2011", Kategori = Kategorier.Single(g => g.KatNavn == "Sterkevin"), Pris = 188, Land = Lands.Single(a => a.Navn =="Spania"), VareArtUrl = "/Content/Images/Hvitvin.jpg3" },
                
            }.ForEach(a => context.SaveChanges()); 
        }
    }
}