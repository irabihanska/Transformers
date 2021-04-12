using AutoMapper;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    class BookCoveragesRepository : Repository<BookCoverage>, IBookCoverageRepository
    {
        public BookCoveragesRepository(Libro_SwapDBContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
