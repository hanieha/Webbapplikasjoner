using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;

namespace WebApplication1.DAL
{
    public class AdminDAL
    {
        public bool settInnNyAdmin(Admin innAdmin)
        {
            var db = new DrikkContext();
            var nyAdmin = new Admin()
            {
                Fornavn = innAdmin.Fornavn,
                Etternavn = innAdmin.Etternavn,
                Adresse = innAdmin.Adresse,
                Epost = innAdmin.Epost,
                Postnr = innAdmin.Postnr,
                Rolle = innAdmin.Rolle,
                //Passord = lagHash(innAdmin.Passord)
            };
            try
            {
                var eksistererPostnr = db.Poststeder.Find(innAdmin.Postnr);
                if (eksistererPostnr == null)
                {
                    var nyttPoststed = new Poststeder()
                    {
                        Postnr = innAdmin.Postnr,
                        Poststed = innAdmin.Poststed
                    };
                    //nyAdmin.Poststed = nyttPoststed
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }

        public bool Admin_i_db(Admin innAdmin)
        {
            using (var db = new DrikkContext())
            {
                byte[] passordDB = lagHash(innAdmin.Passord);
                var funnetAdmin = db.Adminer.FirstOrDefault(b => b.Passord == passordDB && b.Epost == innAdmin.Epost);
                if (funnetAdmin == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        public byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        //lister alle kunder
        public List<Kunde> hentAlleKunder()
        {
            var db = new DrikkContext();
            List<Kunde> alleKunder = db.Kunder.Select(k => new Kunde()
            {
                Kid = k.Kid,
                Fornavn = k.Fornavn,
                Etternavn = k.Etternavn,
                Epost = k.Epost,
                Adresse = k.Adresse,
                Postnr = k.Postnr,
                Poststed = k.Poststed
            }).ToList();
            return alleKunder;
        }

        // Henter info om en kunde
        public Kunde hentEnKunde(int id)
        {
            var db = new DrikkContext();
            var enDbKunde = db.Kunder.Find(id);
            if (enDbKunde == null)
            {
                return null;
            }
            else
            {
                var utKunde = new Kunde()
                {
                    Kid = enDbKunde.Kid,
                    Fornavn = enDbKunde.Fornavn,
                    Etternavn = enDbKunde.Etternavn,
                    Epost = enDbKunde.Epost,
                    Adresse = enDbKunde.Adresse,
                    Postnr = enDbKunde.Postnr,
                    Poststed = enDbKunde.Poststed
                };
                return utKunde;
            }
        }

        // Endrer info om en kunde
        public bool endreKunde(int id, Kunde innKunde)
        {
            var db = new DrikkContext();
            try
            {
                Kunde endreKunde = db.Kunder.Find(id);
                endreKunde.Fornavn = innKunde.Fornavn;
                endreKunde.Etternavn = innKunde.Etternavn;
                endreKunde.Adresse = innKunde.Adresse;
                endreKunde.Epost = innKunde.Epost;
                if (endreKunde.Postnr != innKunde.Postnr)
                {
                    // Postnummeret er endret. Må først sjekke om det nye postnummeret eksisterer i tabellen.
                    Poststeder eksisterendePoststed = db.Poststeder.FirstOrDefault(p => p.Postnr == innKunde.Postnr);
                    if (eksisterendePoststed == null)
                    {
                        var nyttPoststed = new Poststeder()
                        {
                            Postnr = innKunde.Postnr,
                            Poststed = innKunde.Poststed
                        };
                        db.Poststeder.Add(nyttPoststed);
                    }
                    else
                    {   // poststedet med det nye postnr eksisterer, endre bare postnummeret til kunden
                        endreKunde.Postnr = innKunde.Postnr;
                    }
                };
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Fjerner en Kunde fra databasen
        public bool slettKunde(int id)
        {
            var db = new DrikkContext();
           // Kunde kunde = new Kunde();
            try
            {
                var slettKunde = db.Kunder.Find(id);  
                db.Kunder.Remove(slettKunde);
                db.SaveChanges();
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }


    }
}