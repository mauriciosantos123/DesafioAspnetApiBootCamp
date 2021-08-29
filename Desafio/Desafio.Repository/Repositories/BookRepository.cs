using Desafio.Domain.Entities;
using Desafio.Domain.Repositories;
using Desafio.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Repository.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}