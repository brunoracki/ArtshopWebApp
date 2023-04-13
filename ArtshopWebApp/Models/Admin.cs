using System;
using System.Collections.Generic;

namespace ArtshopWebApp.Models;

public partial class Admin
{
    public int Idadmin { get; set; }

    public string Korisnickoime { get; set; } = null!;

    public string Lozinka { get; set; } = null!;
}
