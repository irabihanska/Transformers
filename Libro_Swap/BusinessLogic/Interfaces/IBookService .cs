using Common.DTO;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IBookService : IService<BookDTO>
    {
        Task<List<Book>> GetAllWithDetails();
    }
}
