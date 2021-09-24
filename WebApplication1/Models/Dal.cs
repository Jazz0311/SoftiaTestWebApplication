using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<Attestation> ObtientTouteslesAttestations()
        {
            return _bddContext.Attestations.Include(c=>c.Convention).Include(d => d.Etudiant).ToList();
        }
        public List<Etudiant> ObtientTouslesEtudiants()
        {
            return _bddContext.Etudiants.Include(c=>c.convention).ToList();
        }
        public List<Convention> ObtientTouteslesConventions()
        {
            return _bddContext.Conventions.ToList();
        }

        public void CreateFormulaire(int id, Convention convention, Etudiant etudiant)
        {
            
            Attestation newAttestation = new Attestation()
            {
                Id = id,
                Convention = convention,
                Etudiant = etudiant,
                Message = "Bonjour " + etudiant.Nom + " " + etudiant.Prenom +Environment.NewLine+"Vous avez suivi " + convention.NbHeur  + Environment.NewLine + "Heures "+" de formation chez Formation plus." + "\n" + "Pouvez-vous nous retourner ce mail avec la pièce jointe signée." + "\n" + "Cordialement," + "\n" + "FormationPlus"

            };

            _bddContext.Attestations.Add(newAttestation);
            _bddContext.SaveChanges();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }
    }
}
