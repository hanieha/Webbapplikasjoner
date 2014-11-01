using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;


namespace WebApplication1.DAL
{
    public class SalgDAL
    {

        public bool settInBestilling(Bestilling bestilt)
        {
            var db = new DrikkContext();

            using (var dbTransaksjon = db.Database.BeginTransaction())
            {
                var nybestilling = new Bestilling()
                {
                    Bid = bestilt.Bid,
                    //Antall = bestilt.Antall,
                    Belop = bestilt.Belop,
                    OrderDate = bestilt.OrderDate,
                    //Kunder_Kid = bestilt.Kunder_Kid
                };
                
                try
                {
                    db.Bestillinger.Add(bestilt);
                    db.SaveChanges();
                    dbTransaksjon.Commit();
                    return true;
                }
                catch (Exception feil)
                {
                    dbTransaksjon.Rollback();
                    return false;
                }
            }            
        }
       /* public Salg SisteSolgt(int bid)
        {
            var db = new DrikkContext();
            {
                var dbVare = db.Bestillinger.Find(bid);
                {
                    var bestiling = db.Bestillinger.FirstOrDefault(b => b.OrderDate == dbVare.OrderDate);
                    // dbVare.Kategori = Knavn;
                    var utBestilling = new Salg()
                    {
                        bid = dbVare.Bid,
                        Belop = dbVare.Belop
                    };
                    return utBestilling;
                }
            }
        }*/

        public Kategori KategoriListe(string kategori)
        {
            var db = new DrikkContext();
            var kategorier = db.Kategorier.Include("Varer").Single(g => g.KatNavn == kategori);

            return kategorier;
        }

        public Vare Detaljer(int id)
        {
            Vare drikke = new Vare();
            var db = new DrikkContext();
            var lnd = db.Lander.FirstOrDefault(k => k.LandId == drikke.LandId);
            drikke.Land.Navn = lnd.Navn;
            if (drikke != null)
            return drikke;
            else
            return null;
        }
        
        public Vare hentEnVare(int id)
        {
            var db = new DrikkContext();
            {
                Vare dbVare = db.Varer.Find(id);
                try
                {
                    // var Knavn = db.Kategorier.FirstOrDefault(k => k.KatNavn == dbVare.Kategori.KatNavn);
                    var utVare = new Vare()
                     {
                         VareId = dbVare.VareId,
                         Navn = dbVare.Navn,
                         Land = dbVare.Land,
                         Pris = dbVare.Pris,
                         Kategori = dbVare.Kategori

                     };

                    return utVare;
                }
                catch (Exception ex)
                {
                    return null;
                }

            }
        }


    }
}

