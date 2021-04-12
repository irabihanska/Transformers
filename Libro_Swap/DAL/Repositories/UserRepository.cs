using AutoMapper;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    class UserRepository : Repository<Libro_SwapUser>, IUserRepository
    {
        public UserRepository(Libro_SwapDBContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
