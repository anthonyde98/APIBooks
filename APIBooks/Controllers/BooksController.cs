using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly Services.Books.IBook BookManager;

        public BooksController(Services.Books.IBook bookManager)
        {
            BookManager = bookManager;
        }

        // GET: api/<BooksController>
        [HttpGet]                            
        public async Task<IActionResult> Get()
        {
            try
            {
                var books = await BookManager.Buscar();

                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var respuesta = await BookManager.Existe(id);

                if (!respuesta)
                    return NotFound();

                var book = await BookManager.Buscar(id);

                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.DTOs.Book.Book book)
        {
            try
            {
                var Book = await BookManager.Crear(book);

                return Created("Book created successfully.", Book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Models.DTOs.Book.Book book)
        {
            try
            {
                var respuesta = await BookManager.Existe(id);

                if (!respuesta)
                    return NotFound();

                var Book = await BookManager.Editar(id, book);

                return Ok(Book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var respuesta = await BookManager.Existe(id);

                if (!respuesta)
                    return NotFound();

                var Book = await BookManager.Eliminar(id);

                return Ok(Book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
