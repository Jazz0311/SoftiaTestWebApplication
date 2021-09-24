using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                List<Etudiant> Etud = dal.ObtientTouslesEtudiants();

                ViewBag.listEtudiants = Etud;
              
            }
            return View();

        }
        [HttpPost]
        public IActionResult Index(Etudiant e)
        {
            using (IDal dal = new Dal())
            {
                Etudiant etud= dal.ObtientTouslesEtudiants().Where(a => a.NomComplet == e.NomComplet).FirstOrDefault();
                dal.CreateFormulaire(etud.Id, etud.convention, etud);
                Attestation at = dal.ObtientTouteslesAttestations().Where(a => a.Id == etud.Id).FirstOrDefault();
                return View("Formulaire",at);

            }
            
        }

        public IActionResult Formulaire(Attestation at)
        {
            using (IDal dal = new Dal())
            {
            
                return View(at);
            }
            
        }





    }
}
