using Desafio.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task Create(Book book);
        Task Update(Book book);
        Task Delete(int id);
    }
}