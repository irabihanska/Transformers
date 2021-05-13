using DAL.Repositories;
using DAL.Interfaces;
using DAL.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Libro_SwapDBContext _context;
        private readonly IMapper _mapper;

        private IBookCoverageRepository _coverageRepository;

        private IUserRepository _userRepository;

        private IBookRepository _bookRepository;

        public UnitOfWork(Libro_SwapDBContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IBookCoverageRepository CoverageRepository => _coverageRepository ??= new BookCoveragesRepository(_context, _mapper);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context, _mapper);

        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context, _mapper);
    }
}
