using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;

namespace Desafio.API.Controllers
{
    [ApiController]
    [Route("v1/books")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Book>>> Get([FromServices] IBookRepository bookRepository)
        {
            var books = await bookRepository.GetAll();
            return books.ToList();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Book>> GetById([FromServices] IBookRepository bookRepository, int id)
        {
            var book = await bookRepository.GetById(id);
            return book;
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Book>> Post([FromServices] IBookRepository bookRepository, [FromBody] Book model)
        {
            if (ModelState.IsValid)
            {
                await bookRepository.Create(model);
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

 
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Book model, [FromServices] IBookRepository bookRepository)
        {
            if (model.Id != id)
                return BadRequest();

            await bookRepository.Update(model);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices] IBookRepository bookRepository)
        {
            var books = await bookRepository.GetById(id);
            if (books == null)
                return NotFound();

            await bookRepository.Delete(id);

            return NoContent();
        }
    }
}
