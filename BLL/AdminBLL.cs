using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.DAL;

namespace WebApplication1.BLL
{
    public class AdminBLL
    {
        public bool settInnNyAdmin(Admin nyAdmin)
        {
            var adminDal = new AdminDAL();
            return adminDal.settInnNyAdmin(nyAdmin);
        }

        public byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        public bool Admin_i_db(Admin innAdmin)
        {
            var adminDal = new AdminDAL();
            return adminDal.Admin_i_db(innAdmin);
        }

        public List<Kunde> hentAlleKunder()
        {
            var adminDal = new AdminDAL();
            List<Kunde> alleKunder = adminDal.hentAlleKunder();
            return alleKunder;
        }

        public Kunde hentEnKunde(int id)
        {
            var adminDal = new AdminDAL();
            return adminDal.hentEnKunde(id);
        }

        // Endrer info om en kunde
        public bool endreKunde(int id, Kunde innKunde)
        {
            var adminDal = new AdminDAL();
            return adminDal.endreKunde(id, innKunde);
        }

        // Fjerner en Kunde fra databasen
        public bool slettKunde(int id)
        {
            var adminDal = new AdminDAL();
            return adminDal.slettKunde(id);
        }
    }
}
