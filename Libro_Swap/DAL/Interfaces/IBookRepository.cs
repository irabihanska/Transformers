using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetAllWithDetailsAsync();
    }
}