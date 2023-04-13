using System;
using System.Collections.Generic;

namespace ArtshopWebApp.Models;

public partial class Izlozba
{
    public int Idizlozba { get; set; }

    public string Imegalerija { get; set; } = null!;

    public DateOnly? Pocetak { get; set; }

    public DateOnly? Kraj { get; set; }

    public string Drzava { get; set; } = null!;

    public string Mjesto { get; set; } = null!;

    public int Postbroj { get; set; }
}
