using System;
using System.Collections.Generic;
using apiHangFire.Dtos;
using MediatR;

namespace apiHangFire.Queries
{
    public class GetBooksByIdQuery : IRequest<BookReadDto>
    {

        public int Id{ get; }
        public GetBooksByIdQuery(int id)
        {
           Id = id ;
        }
    }
}