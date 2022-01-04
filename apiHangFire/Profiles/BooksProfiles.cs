using AutoMapper;
using apiHangFire.Dtos;
using apiHangFire.Model;

namespace apiHangFire.Profiles
{
    public class BooksProfiles : Profile
    {
        public BooksProfiles(){
 
          CreateMap<book,BookReadDto>();
          CreateMap<BookCreateDto,book>();
           

        }
    }
}