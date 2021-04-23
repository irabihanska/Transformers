using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using AutoMapper;
using Common.DTO;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork _unitOfWork;

        private IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<BookDTO> Get(int id)
        {
            var item = await _unitOfWork.BookRepository.Get(id);

            return _mapper.Map<Book, BookDTO>(item);
        }

        public async Task<List<BookDTO>> GetAll()
        {
            var items = await _unitOfWork.BookRepository.GetAll();

            return _mapper.Map<List<Book>, List<BookDTO>>(items);
        }

        public async Task<BookDTO> Create(BookDTO item)
        {
            var newItem = _mapper.Map<BookDTO, Book>(item);

            await _unitOfWork.BookRepository.Create(newItem);
            await _unitOfWork.SaveAsync();
            
            return _mapper.Map<Book, BookDTO>(newItem);
        }

        public async Task<BookDTO> Update(BookDTO item)
        {
            var updItem = _mapper.Map<BookDTO, Book>(item);

            await _unitOfWork.BookRepository.Update(updItem);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<Book, BookDTO>(updItem);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.BookRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
