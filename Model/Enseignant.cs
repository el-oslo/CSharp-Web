using System;
using System.Collections.Generic;

namespace Api.Model;

public partial class Enseignant
{
    public int Numenseignant { get; set; }

    public string? Nomenseignant { get; set; }

    public string? Prenomenseignant { get; set; }

    public string? Civiliteenseignant { get; set; }

    public virtual ICollection<Cour> Cours { get; set; } = new List<Cour>();
}
