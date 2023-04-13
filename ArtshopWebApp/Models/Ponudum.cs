using System;
using System.Collections.Generic;

namespace ArtshopWebApp.Models;

public partial class Ponudum
{
    public int Idponuda { get; set; }

    public double Cijenaponuda { get; set; }

    public DateOnly Datumponuda { get; set; }

    public int Iddjelo { get; set; }

    public int Idkupac { get; set; }

    public virtual Djelo IddjeloNavigation { get; set; } = null!;

    public virtual Kupac IdkupacNavigation { get; set; } = null!;
}
