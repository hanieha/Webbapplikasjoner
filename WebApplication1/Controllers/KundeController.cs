using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebApplication1.Model;
using System.Data.Entity;
using System.Web.Mvc.Html;
using WebApplication1.BLL;

namespace WebApplication1.Controllers
{
  public class KundeController : Controller
  {
    
    // Viser registreringsskjema
    public ActionResult Registrer()
    {
      return View();
    }

    // Henter info fra registreringsskjemaet
    [HttpPost]
    public ActionResult Registrer(Kunde nyKunde)
    {
      if (ModelState.IsValid)
      {
        var kundeDb = new KundeBLL();
        bool insertOk = kundeDb.Registrer(nyKunde);
        if (insertOk)
        {
          return RedirectToAction("Innlogging");
        }
      }
      return View();
    }

    // Viser innloggingsside, dersom brukeren ikke var innlogget
    public ActionResult Innlogging()
    {
      if (Session["LoggetInn"] == null)
      {
          ViewBag.Innlogget = false;
      }
      else if (Session["Handlekurv"] != null)
      {
          return RedirectToAction("Betaling", "Salg");
          ViewBag.Innlogget = true;
      }
      return View();
    }

    // Sender info fra Innloggingsside
    [HttpPost]
    public ActionResult Innlogging(Kunde loggetInnKunde)
    {
        var kundeDb = new KundeBLL();
        Kunde kundeId = kundeDb.hentEnKunde(loggetInnKunde);
      
        if (kundeId != null)
         {
              //Session["LoggetInn"] = true;
              Session["LoggetInn"] = kundeId;
              if (Session["redirect"] != null)
              {
                  return RedirectToAction("MinSide" + '/' + Session["redirect"], "salg"); // Nå går kunden til Detaljer.. kan byttes til Handlekurv for eks
              }
              else if (Session["Handlekurv"] != null)
              {
                  return RedirectToAction("Betaling", "Salg");
                  ViewBag.Innlogget = true;
              }
              else
              {
                  return RedirectToAction("MinSide", "Kunde");
              }
          }
          else
          {
            Session["LoggetInn"] = 0;
            ViewBag.Innlogget = false;
            //return View();
            return RedirectToAction("Registrer", "Kunde");
          }
    }

    // flyttet lagHash til DBKunde igjen

/*    private static int Kunde_i_DB(Kunde nyKunde)
    {
      using (var db = new DrikkContext())
      {
        //var kundeDb = new DBKunde();
        byte[] passordDb = KundeBLL.lagHas(nyKunde.Passord);
        Kunder funnetKunde = db.Kunder.FirstOrDefault(b => b.Passord == passordDb && b.Epost == nyKunde.Epost);
        if (funnetKunde != null)
          return funnetKunde.Kid;
        else
          return 0;
      }
    }*/

    // Viser redigeringsskjema
    public ActionResult Endre()
    {
        if(Session["LoggetInn"] == null)
        {
            return RedirectToAction("Innlogging", "Kunde");
        }
        else
        {
            //var model = Kunde_Info((int)Session["LoggetInn"]);
            var kundeDb = new KundeBLL();
            Kunde kundeInfo = kundeDb.hentEnKunde((Kunde)Session["LoggetInn"]);
            return View(kundeInfo);
        }
    }

    // Henter info fra registreringsskjemaet
    [HttpPost]
    public ActionResult Endre(Kunde ekunde)
    {
      var kundeDb = new KundeBLL();
      bool insertOk = kundeDb.Endre((int)Session["LoggetInn"], ekunde);
      if (insertOk)
      {
        return RedirectToAction("MinSide");
      }
      return View();
    }

   [HttpPost]
    public ActionResult MinSide(Kunde kunde)
    {
        if (Session["LoggetInn"] == null)
        {
            return RedirectToAction("Innlogging", "Kunde");
            ViewBag.Innlogget = false;
        }
        else
        {
            //ViewBag.Innlogget = (bool)Session["LoggetInn"];
            ViewBag.Innlogget = true;
            int id = (int)Session["LoggetInn"];
            var kundeDb = new KundeBLL();
            Kunde kundeInfo = kundeDb.hentEnKunde(kunde);
            return View(kundeInfo);
        }
    }

    // Logger ut brukeren
    public ActionResult LoggUt()
    {
        Session["LoggetInn"] = 0;
        ViewBag.Innlogget = false;
        return RedirectToAction("index", "Salg");
    }

  }
}
