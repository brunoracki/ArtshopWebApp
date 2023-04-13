using System;
using System.Collections.Generic;

namespace ArtshopWebApp.Models;

public partial class Autor
{
    public int Idautor { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public DateOnly? Datrod { get; set; }

    public string? Adresa { get; set; }

    public int? Postbroj { get; set; }

    public string? Drzava { get; set; }

    public string? Telbroj { get; set; }

    public string? Mjestorod { get; set; }

    public virtual ICollection<Djelo> Djelos { get; } = new List<Djelo>();
}
