using AutoMapper;
using Common.DTO;
using DAL.Models;

namespace Common.MappingProfiles
{
    public class BookCoverageProfile : Profile
    {
        public BookCoverageProfile()
        {
            CreateMap<BookCoverage, BookCoverage>()
                .ForMember(bc => bc.Id, o => o.Ignore());


            CreateMap<BookCoverageDTO, BookCoverage>();
            CreateMap<BookCoverage, BookCoverageDTO>();
        }
    }
}
