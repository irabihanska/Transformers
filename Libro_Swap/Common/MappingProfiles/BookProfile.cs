using AutoMapper;
using Common.DTO;
using DAL.Models;

namespace Common.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, Book>()
                .ForMember(bc => bc.Id, o => o.Ignore());


            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();
        }
    }
}
