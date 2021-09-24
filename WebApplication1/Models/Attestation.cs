using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Attestation
    {
        public int Id { get; set; }
        public Etudiant Etudiant{ get; set; }
        public Convention Convention { get; set; }
        public string Message { get; set; }
    }
}
