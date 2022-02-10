using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBooks.Models.DTOs.Book
{
    public class Book
    {
        public string Titulo { get; set; }
        public string Editorial { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public decimal Precio { get; set; }
    }
}
