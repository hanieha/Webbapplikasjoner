using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.BLL;
using WebApplication1.Model;

// Denne Controller skal gjøre følgende fuksjoner:
//      - liste ulike kategorier
//      - Liste varer etter ulike kategorier
//      - Vise detaljer om en hver enkel vare 
//
namespace WebApplication1.Controllers
{
    public class SalgController : Controller
    {

        SalgBLL salgDB = new SalgBLL();

        //Salg
        public ActionResult Index()
        {
            // lister lister av varer---- kan endres til List av mest solgte / pepulære varer for eks
      
            var vareliste = salgDB.hentEnVare(5);
            return View(vareliste);
            /*var kategori = salgDB.Kategorier.ToList();
            return View(kategori); */
        }


        public ActionResult Bestilling(String bestilt)
        {
            var handlekurv = (List<Vare>)Session["Handlekurv"];
            var bestilling = new Salg();
            bestilling.OrderDate = DateTime.Now;
           
           return RedirectToAction("Kvitterring", "Salg");
        }

       /* public ActionResult SisteSolgt(int bid)
        {
            Session["SisteSolgt"] = bid;
             var sisteSolgt = new SalgBLL().SisteSolgt(bid);
            //var sisteSolgt = salgDB.SisteSolgt(bid);
            if (sisteSolgt != null)
                return View(sisteSolgt);
            else
                return null;
        }*/
    
        public ActionResult KategoriListe(string kategori)
        {
            // henter varer etter en spesifisert kategori i databasen
            var kategoriModel = salgDB.KategoriListe(kategori);

            return View(kategoriModel);
        }


        // /salg/Detaljer/
        public ActionResult Detaljer(int id)
        {
            Session["VareId"] = id;
            Vare drikke = salgDB.Detaljer(id);
            var lnd = salgDB.Detaljer(id);  
            drikke.Land.Navn = lnd.Navn;
            if (drikke != null)
                return View(drikke);
            else
                return null;
        }

        // Legger en vare til handlekurven
        public ActionResult LeggTilHandlekurv(int id)
        {
            Vare innVare = salgDB.hentEnVare(id); 
            List<Vare> handlekurv;

            if (Session["Handlekurv"] != null)
                handlekurv = (List<Vare>)Session["Handlekurv"];
            else
                handlekurv = new List<Vare>();

            handlekurv.Add(innVare);
            Session["Handlekurv"] = handlekurv;

            string brukerId;
            brukerId = System.Web.HttpContext.Current.Session.SessionID;

            return RedirectToAction("Detaljer", "Salg", new { id = innVare.VareId });
        }

        // Finner info om den vare som er i handlekurven fra databasen
        public ActionResult VisHandlekurv()
        {
            var handlekurv = Session["Handlekurv"];
            if (handlekurv != null)
                return View(handlekurv);
            else
                return null;
            //Console.WriteLine("{0} Handlekurven er tomm!! ");
        }

        // Fjerner en vare fra handlekurven
        public ActionResult FjernFraHandlekurv(int id)
        {
            Vare fjernVare = salgDB.hentEnVare(id);
            List<Vare> handlekurv;

            if (Session["Handlekurv"] != null)
            {
                handlekurv = (List<Vare>)Session["Handlekurv"];
                handlekurv.Remove(fjernVare);
                Session["Handlekurv"] = handlekurv;

                return RedirectToAction("VisHandlekurv", "Salg", new { id = fjernVare.VareId });
            }
            return RedirectToAction("VisHandlekurv", "Salg");
        }

        public ActionResult Betaling()
        {
            if (Session["LoggetInn"] != null)
            {
                var handlekurv = Session["Handlekurv"];
                return View(handlekurv);
            }
            else
                return RedirectToAction("Innlogging", "Kunde");
        }


        /*
        // Finner info om den vare som er i handlekurven fra databasen
        public ActionResult handlekurv(int Id)
        {
          if (Session["LoggetInn"] != null)
          {
              //var db = new DBSalg();
              Vare enVare = salgDB.hentEnVare(Id);
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