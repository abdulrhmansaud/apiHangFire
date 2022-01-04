using System.Collections.Generic;
using apiHangFire.Dtos;
using MediatR;

namespace apiHangFire.Queries
{
    public class GetAllBooksQuery : IRequest<List<BookReadDto>>
    {
        
    }
}