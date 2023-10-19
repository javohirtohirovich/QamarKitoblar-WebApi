using AutoMapper;
using QamarKitoblar.Domain.Entities.Books;
using QamarKitoblar.Service.Dtos.Books;

namespace QamarKitoblar.WebApi.Configurations;

public class MapperConfiguration:Profile
{
    public MapperConfiguration()
    {
        CreateMap<BookCreateDto, Book>().ReverseMap();
    }
}
