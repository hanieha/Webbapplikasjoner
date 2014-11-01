using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Model;

// Denne Controller skal gjøre følgende fuksjoner:
//      - liste ulike kategorier
//      - Liste varer etter ulike kategorier
//      - Vise detaljer om en hver enkel vare 
//
namespace WebApplication1.BLL
{
    public class SalgBLL
    {
       
           public bool Bestilling(Bestilling bestilt)
        {
            SalgDAL salgDB = new SalgDAL();
            return salgDB.settInBestilling(bestilt);
        }

         /*  public Salg SisteSolgt(int bid)
        {
            SalgDAL salgDB = new SalgDAL();
            return salgDB.SisteSolgt(bid);
        }*/

        public Kategori KategoriListe(string kategori)
        {
            SalgDAL salgDB = new SalgDAL();
            return salgDB.KategoriListe(kategori);
        }

        // /salg/Detaljer/
        public  Vare Detaljer(int id)
        {
            SalgDAL salgDB = new SalgDAL();
            return salgDB.Detaljer(id); ;
        }

        public Vare hentEnVare(int id)
        {
            SalgDAL salgDB = new SalgDAL();
            return salgDB.hentEnVare(id);
        }

               /*
        // Finner info om den vare som er i handlekurven fra databasen
        public ActionResult handlekurv(int Id)
        {
          if (Session["LoggetInn"] != null)
          {
              var db = new DBSalg();
              Vare enVare = db.hentEnVare(Id);
              return View(enVare);
          }
          else
          {
            Session["redirect"] = Id;
            return RedirectToAction("Innlogging", "Kunde");
          }
        }*/
    }
}