using AdatechTask.Entities.Concrete;
using AdatechTask.Entities.Dtos;
using AutoMapper;

namespace AdatechTask.Services.AutoMapper.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<BookAddDto, Book>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<BookUpdateDto, Book>().ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<Book, BookUpdateDto>();
        }
    }
}
