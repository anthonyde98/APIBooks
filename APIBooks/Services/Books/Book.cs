using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBooks.Models.Data;

namespace APIBooks.Services.Books
{
    public class Book: IBook
    {
        public readonly APIBooksContext DbContext;

        public Book(APIBooksContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Models.Data.Libro>> Buscar()
        {
            var books = await DbContext.Libros.ToListAsync();

            return books;
        }

        public async Task<bool> Existe(int id)
        {
            var respuesta = await DbContext.Libros.AnyAsync(l => l.LibroId == id);

            return respuesta;
        }

        public async Task<Models.DTOs.Book.Book> Buscar(int id)
        {
            var Book = from book in DbContext.Libros
                       where book.LibroId == id
                       select new Models.DTOs.Book.Book()
                       {
                           Titulo = book.Titulo,
                           Editorial = book.Editorial,
                           Autor = book.Autor,
                           FechaPublicacion = book.FechaPublicacion,
                           Precio = book.Precio
                       };

            return await Book.SingleOrDefaultAsync();
        }

        public async Task<Models.DTOs.Book.Book> Crear(Models.DTOs.Book.Book book)
        {
            DbContext.Libros.Add(new Models.Data.Libro()
            {
                Titulo = book.Titulo,
                Editorial = book.Editorial,
                Autor = book.Autor,
                FechaPublicacion = book.FechaPublicacion,
                Precio = book.Precio
            });

            await DbContext.SaveChangesAsync();

            return book;
        }

        public async Task<Models.DTOs.Book.Book> Editar(int id, Models.DTOs.Book.Book book)
        {
            var recentBook = await DbContext.Libros.FindAsync(id);

            recentBook.LibroId = id;
            recentBook.Titulo = book.Titulo == null ? recentBook.Titulo : book.Titulo;
            recentBook.Autor = book.Autor == null ? recentBook.Autor : book.Autor;
            recentBook.Editorial = book.Editorial == null ? recentBook.Editorial : book.Editorial;
            recentBook.FechaPublicacion = book.FechaPublicacion;

            DbContext.Update(recentBook);

            await DbContext.SaveChangesAsync();

            return await Buscar(id);
        }

        public async Task<string> Eliminar(int id)
        {
            var book = await DbContext.Libros.FindAsync(id);

            DbContext.Remove(book);
            await DbContext.SaveChangesAsync();

            return "Deleted";
        }
    }
}
