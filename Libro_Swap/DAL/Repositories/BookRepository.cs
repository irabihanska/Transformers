using AutoMapper;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(Libro_SwapDBContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
