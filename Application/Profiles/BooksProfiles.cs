using AutoMapper;
using Application.Dtos;
using Domain.Entities;

namespace Application.Profiles
{
    public class BooksProfiles : Profile
    {
        public BooksProfiles()
        {

            CreateMap<book, BookReadDto>();
            CreateMap<BookCreateDto, book>();


        }
    }
}