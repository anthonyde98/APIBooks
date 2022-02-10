using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBooks.Services.Books
{
    public interface IBook
    {
        Task<List<Models.Data.Libro>> Buscar();
        Task<bool> Existe(int id);
        Task<Models.DTOs.Book.Book> Buscar(int id);
        Task<Models.DTOs.Book.Book> Crear(Models.DTOs.Book.Book book);
        Task<Models.DTOs.Book.Book> Editar(int id, Models.DTOs.Book.Book book);
        Task<string> Eliminar(int id);
    }
}
