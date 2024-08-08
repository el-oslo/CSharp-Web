using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Enseignant
{
    public class EnseignantDto
    {
        public int Numenseignant { get; set; }
        
        public string? Nomenseignant { get; set; }

        public string? Prenomenseignant { get; set; }

        public string? Civiliteenseignant { get; set; }
    }
}