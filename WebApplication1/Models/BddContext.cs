using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BddContext: DbContext
    {
        public DbSet<Etudiant> Etudiants { get; set; }
        public DbSet<Convention> Conventions { get; set; }
        public DbSet<Attestation> Attestations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=rrrrr;database=WebApplication");
        }
        public void InitializeDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
            using (Dal ctx = new Dal())
            {
                Convention cn1 = new Convention();
                cn1.nom = "CN1";
                cn1.NbHeur = 35;

                Convention cn2 = new Convention();
                cn2.nom = "CN2";
                cn2.NbHeur = 39;

                Convention cn3 = new Convention();
                cn3.nom = "CN3";
                cn3.NbHeur = 42;

                

                this.Conventions.AddRange(cn1,cn2,cn3);

                Etudiant e1 = new Etudiant();
                e1.Nom = "Compagnom";
                e1.Prenom = "Raoul";
                e1.Mail = "RaoulCompagnon@yahoo.com";
                e1.convention = cn1;
                e1.NomComplet = e1.Nom + " " + e1.Prenom;

                Etudiant e2 = new Etudiant();
                e2.Nom = "Longpré";
                e2.Prenom = "Suzette";
                e2.Mail = "SuzetteLongpre@gmail.com";
                e2.convention = cn2;
                e2.NomComplet = e2.Nom + " " + e2.Prenom;

                Etudiant e3 = new Etudiant();
                e3.Nom = "Bureau";
                e3.Prenom = "Oriel";
                e3.Mail = "OrielBureau@outlook.com";
                e3.convention = cn2;
                e3.NomComplet = e3.Nom + " " + e3.Prenom;

                Etudiant e4 = new Etudiant();
                e4.Nom = "Mazuret";
                e4.Prenom = "Dominique";
                e4.Mail = "DominiqueMazuret@outlook.com";
                e4.convention = cn3;
                e4.NomComplet = e4.Nom + " " + e4.Prenom;

                Etudiant e5 = new Etudiant();
                e5.Nom = "Tremblay";
                e5.Prenom = "Joseph";
                e5.Mail = "JosephTremblay@outlook.com";
                e5.convention = cn1;
                e5.NomComplet = e5.Nom + " " + e5.Prenom;



                this.Etudiants.AddRange(
                    e1,e2,e3,e4,e5

                      ) ;
                
            }


            this.SaveChanges();
        }
    
   


}
}
