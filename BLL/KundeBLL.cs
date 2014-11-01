using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
//using System.Web.Mvc.Ajax;
using WebApplication1.Model;
using System.Data.Entity;
using WebApplication1.DAL;
//using System.Web.Mvc.Html;

namespace WebApplication1.BLL
{
  public class KundeBLL
  {
    
    public bool Registrer(Kunde innKunde)
    {
        var kundeDal = new KundeDAL();
        return kundeDal.Registrer(innKunde);
    }

    public Kunde hentEnKunde(Kunde kunde)
    {
        var kundeDal = new KundeDAL();
        return kundeDal.hentEnKunde(kunde);
    }

    public  bool Endre(int id, Kunde ekunde)
    {
           var kundeDal = new Kunde();
        return kundeDal.Endre(id,ekunde);
      }

    public byte[] lagHash(string innPassord)
    {
        var kundeDal = new KundeDAL();
        return kundeDal.lagHash(innPassord);
    }
  }
}
