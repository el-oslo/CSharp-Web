using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Classe
{
    public class UpdateClasseRequest
    {
        public string? Niveau { get; set; }
        public string? Parcours { get; set; }
    }
}