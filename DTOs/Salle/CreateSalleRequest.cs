using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Salle
{
    public class CreateSalleRequest
    {
        public int Numsalle { get; set; }

        public string? Designsalle { get; set; }
    }
}