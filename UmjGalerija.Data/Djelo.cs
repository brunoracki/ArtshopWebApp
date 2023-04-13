using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtshopWebApp.Data
{
    public class Djelo
    {
        public int IdDjelo { get; set; }
        public float CijenaDjelo { get; set; }
        public int GodinaDjelo { get; set; }
        public string NatpisDjelo { get; set; }

        public string OpisDjelo { get; set; }

        public string TipDjelo { get; set; }

    }

    public class Autor
    {
        public int IdAutor { get; set; }

        public string  imeAutor { get; set; }
         
        public string prezimeAutor { get; set; }

    }
}
