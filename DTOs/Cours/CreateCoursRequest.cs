using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Util;
using Newtonsoft.Json;

namespace Api.DTOs.Cours
{
    public class CreateCoursRequest
    {
        public string Codematiere { get; set; } = null!;

        public int Numenseignant { get; set; }

        public string Numclasse { get; set; } = null!;

        public int Numsalle { get; set; }

        public string Date { get; set; } = null!;

        public string Heuredebut { get; set; } = null!;

        public string Heurefin { get; set; } = null!;   
    }
}