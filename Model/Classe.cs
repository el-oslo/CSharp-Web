using System;
using System.Collections.Generic;

namespace Api.Model;

public partial class Classe
{
    public string Numclasse { get; set; } = null!;

    public string? Niveau { get; set; }

    public string? Parcours { get; set; }

    public virtual ICollection<Cour> Cours { get; set; } = [];
}
