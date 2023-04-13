using System;
using System.Collections.Generic;

namespace ArtshopWebApp.Models;

public partial class Kupac
{
    public int Idkupac { get; set; }

    public string Ime { get; set; } = null!;

    public string Prezime { get; set; } = null!;

    public string Telbroj { get; set; } = null!;

    public string? Adresa { get; set; }

    public string? Mjesto { get; set; }

    public int? Postbroj { get; set; }

    public string Email { get; set; } = null!;

    public string? Zemlja { get; set; }

    public string Korisnickoime { get; set; } = null!;

    public string Lozinka { get; set; } = null!;

    public virtual ICollection<Ponudum> Ponuda { get; } = new List<Ponudum>();
}
