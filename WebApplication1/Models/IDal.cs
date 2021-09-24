using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IDal : IDisposable
    {
        void DeleteCreateDatabase();
        List<Attestation> ObtientTouteslesAttestations();
        List<Etudiant> ObtientTouslesEtudiants();
        List<Convention> ObtientTouteslesConventions();
        void CreateFormulaire(int id, Convention convention, Etudiant etudiant);
    }
}
