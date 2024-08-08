using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Util;
using Newtonsoft.Json;

namespace Api.DTOs.Cours
{
    public class CoursDto
    {
        public int Numcours { get; set; }
        public string Codematiere { get; set; } = null!;

        public int Numenseignant { get; set; }

        public string Numclasse { get; set; } = null!;

        public int Numsalle { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly Heuredebut { get; set; }

        public TimeOnly Heurefin { get; set; }
    }
}