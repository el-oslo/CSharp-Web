using System;
using System.Collections.Generic;
using Api.Util;
using Newtonsoft.Json;

namespace Api.Model;

public partial class Cour
{
    public int Numcours { get; set; }

    public string Codematiere { get; set; } = null!;

    public int Numenseignant { get; set; }

    public string Numclasse { get; set; } = null!;

    public int Numsalle { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Heuredebut { get; set; }

    public TimeOnly Heurefin { get; set; }

    public virtual Matiere CodematiereNavigation { get; set; } = null!;

    public virtual Classe NumclasseNavigation { get; set; } = null!;

    public virtual Enseignant NumenseignantNavigation { get; set; } = null!;

    public virtual Salle NumsalleNavigation { get; set; } = null!;
}
