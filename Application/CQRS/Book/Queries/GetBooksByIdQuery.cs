using System;
using System.Collections.Generic;
using Application.Dtos;
using MediatR;

namespace Application.CQRS.Book.Queries
{
    public class GetBooksByIdQuery : IRequest<BookReadDto>
    {

        public int Id { get; }
        public GetBooksByIdQuery(int id)
        {
            Id = id;
        }
    }
}