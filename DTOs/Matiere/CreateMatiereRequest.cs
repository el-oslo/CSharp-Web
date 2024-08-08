using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Matiere
{
    public class CreateMatiereRequest
    {
        public string Codematiere { get; set; } = null!;

        public string? Nommatiere { get; set; }
    }
}