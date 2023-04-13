using System;
using System.Collections.Generic;

namespace ArtshopWebApp.Models;

public partial class Umjizlozba
{
    public int Idizlozba { get; set; }

    public int Iddjelo { get; set; }

    public virtual Djelo IddjeloNavigation { get; set; } = null!;

    public virtual Izlozba IdizlozbaNavigation { get; set; } = null!;
}
