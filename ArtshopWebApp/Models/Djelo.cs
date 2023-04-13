using System;
using System.Collections.Generic;

namespace ArtshopWebApp.Models;

public partial class Djelo
{
    public int Iddjelo { get; set; }

    public int Godinadjelo { get; set; }

    public string Natpisdjelo { get; set; } = null!;

    public double Cijenadjelo { get; set; }

    public string Opisdjelo { get; set; } = null!;

    public string Tipdjelo { get; set; } = null!;

    public int Idautor { get; set; }

    public byte[]? Imgdjelo { get; set; }

    public virtual Autor IdautorNavigation { get; set; } = null!;

    public virtual ICollection<Ponudum> Ponuda { get; } = new List<Ponudum>();
}
