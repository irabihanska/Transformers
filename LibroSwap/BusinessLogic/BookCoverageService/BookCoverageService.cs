using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL.Models;
using AutoMapper;
using Common.DTO;

namespace BusinessLogic.CoverageService
{
    public class BookCoverageService : IBookCoverageService
    {
        private IUnitOfWork _unitOfWork;

        private IMapper _mapper;

        public BookCoverageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<BookCoverageDTO> Get(int id)
        {
            var item = await _unitOfWork.CoverageRepository.Get(id);

            return _mapper.Map<BookCoverage, BookCoverageDTO>(item);
        }

        public async Task<List<BookCoverageDTO>> GetAll()
        {
            var items = await _unitOfWork.CoverageRepository.GetAll();

            return _mapper.Map<List<BookCoverage>, List<BookCoverageDTO>>(items);
        }

        public async Task<BookCoverageDTO> Create(BookCoverageDTO item)
        {
            var newItem = _mapper.Map<BookCoverageDTO, BookCoverage>(item);

            await _unitOfWork.CoverageRepository.Create(newItem);
            await _unitOfWork.SaveAsync();
            
            return _mapper.Map<BookCoverage, BookCoverageDTO>(newItem);
        }

        public async Task<BookCoverageDTO> Update(BookCoverageDTO item)
        {
            var updItem = _mapper.Map<BookCoverageDTO, BookCoverage>(item);

            await _unitOfWork.CoverageRepository.Update(updItem);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BookCoverage, BookCoverageDTO>(updItem);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CoverageRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
