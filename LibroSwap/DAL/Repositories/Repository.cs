using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Interfaces;
using System.Threading.Tasks;
using AutoMapper;


namespace DAL.Repositories
{
    class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly LibroContext _context;
        protected readonly DbSet<T> _dataset;
        protected readonly IMapper mapper;


        public Repository(LibroContext context, IMapper automapper)
        {
            _context = context;
            _dataset = _context.Set<T>();
            mapper = automapper;
        }

        public async Task<T> Get(int id)
        {
            var item = _dataset.FindAsync(id);
            return await item;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dataset.ToListAsync();
        }

        public async Task Create(T item)
        {
            await _dataset.AddAsync(item);
        }

        public async Task Update(T item)
        {
            var updItem = await Get(item.Id);
            _dataset.Remove(updItem);
            await _dataset.AddAsync(item);
        }

        public async Task Delete(int id)
        {
            var deleteItem = await Get(id);
            if (deleteItem != null)
            {
                _dataset.Remove(deleteItem);
            }
        }
    }
}
