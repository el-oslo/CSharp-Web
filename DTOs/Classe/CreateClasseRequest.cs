using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Classe
{
    public class CreateClasseRequest
    {
        public string Numclasse { get; set; } = null!;
        public string? Niveau { get; set; }
        public string? Parcours { get; set; }
    }
}