using System;
using System.Collections.Generic;

namespace Api.Model;

public partial class Matiere
{
    public string Codematiere { get; set; } = null!;

    public string? Nommatiere { get; set; }

    public virtual ICollection<Cour> Cours { get; set; } = new List<Cour>();
}
