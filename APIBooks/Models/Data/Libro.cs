using System;
using System.Collections.Generic;

#nullable disable

namespace APIBooks.Models.Data
{
    public partial class Libro
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public decimal Precio { get; set; }
    }
}
