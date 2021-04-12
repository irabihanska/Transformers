using AutoMapper;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(LibroContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
