using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(Libro_SwapDBContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<List<Book>> GetAllWithDetailsAsync()
        {
            return await _context.Books.Include(b => b.Author).Include(b => b.BookCoverage).Include(b => b.Bookhouse).Include(b => b.City).Include(b => b.CurrentOwner).Include(b => b.Genre).Include(b => b.Language).Include(b => b.SecondaryGenre).Include(b => b.TertiaryGenre).Include(b => b.Translator)
                .ToListAsync();
        }
    }
}
