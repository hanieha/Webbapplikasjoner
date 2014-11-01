using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication1.Model;


namespace WebApplication1.DAL
{

    public class Varer
    {
        [Key]
        public int VareId { get; set; }
        public int LandId { get; set; }
        public int bid { get; set; }

        public string Navn { get; set; }
        public decimal Pris { get; set; }
        public int Antall { get; set; }
        public string VareArtUrl { get; set; }
        public Kategori Kategori { get; set; }
        public Land Land { get; set; }

        public virtual List<Salg> Bestillinger { get; set; }
    }
    public class Kunder
    {
        [Key]
        public int Kid { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Epost { get; set; }
        public string Postnr { get; set; }
        public byte[] Passord { get; set; }

        //public virtual List<Kunde> Kunder { get; set; }
        public virtual Poststeder Poststeder { get; set; }
        public virtual List<Bestilling> Bestillinger { get; set; }

    }

    public class Poststeder
    {
        [Key]
        public string Postnr { get; set; }
        public string Poststed { get; set; }
        //public virtual Poststeder Poststeder { get; set; }
        public virtual List<Kunde> Kunder { get; set; }
        public virtual List<Stakeholder> Stakeholdere { get; set; }
    }

    public class Bestilling
    {
        [Key]
        public int Bid { get; set; }
        public decimal Belop { get; set;}
        public System.DateTime OrderDate { get; set; }
        public virtual List<Bestilling> Bestillinger { get; set; }
        
    }


    public class Kategorier
    {
        [Key]
        public int KatId { get; set; }
        public string KatNavn { get; set; }
        public virtual List<Kategori> kategorier { get; set; }
    }


    public class Adminer
    {
        [Key]
        public int Aid { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Epost { get; set; }
        public string Rolle { get; set; }
        public byte[] Passord { get; set; }
        public virtual Poststeder Poststeder { get; set; }

        public string Poststed { get; set; }
    }


   

    public class Stakeholder
    {
        [Key]
        public int Sid { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Postnr { get; set; }
        public string Epost { get; set; }
        public string Rolle { get; set; }
        public byte[] Passord { get; set; }
        public virtual Poststeder Poststeder { get; set; }
    }

    public class DrikkContext : DbContext
    {
        public DrikkContext()
            : base("name=Drink")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Poststeder> Poststeder { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }
        public DbSet<Vare> Varer { get; set; }
        public DbSet<Stakeholder> Stakeholdere { get; set; }
        public DbSet<Kategori> Kategorier { get; set; }
        public DbSet<Land> Lander{ get; set; }
        public DbSet<Adminer> Adminer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poststeder>().HasKey(p => p.Postnr);
            modelBuilder.Entity<Kategori>().HasKey(p => p.KatId);
            modelBuilder.Entity<Vare>().HasKey(p => p.VareId);
            modelBuilder.Entity<Bestilling>().HasKey(p => p.Bid);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

      /*  internal List<Bestilling> Bestilling()
        {
            throw new NotImplementedException();
        }*/
    }
}
