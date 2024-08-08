using System;
using System.Collections.Generic;

namespace Api.Model;

public partial class Salle
{
    public int Numsalle { get; set; }

    public string? Designsalle { get; set; }

    public virtual ICollection<Cour> Cours { get; set; } = new List<Cour>();
}
