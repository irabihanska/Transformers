using System;
using System.Collections.Generic;
using DAL.Repositories;
using DAL.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace DAL.UnitOfWork
{
    class UnitOfWork : IUnitOfWork
    {
        private LibroContext _context;
        private readonly IMapper _mapper;

        private ICoverageRepository _coverageRepository;

        public UnitOfWork(LibroContext context)
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

        public ICoverageRepository CoverageRepository => _coverageRepository ?? (_coverageRepository = new CoveragesRepository(_context, _mapper));
    }
}
