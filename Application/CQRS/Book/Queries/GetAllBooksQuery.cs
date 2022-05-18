using System.Collections.Generic;
using Application.Dtos;
using MediatR;

namespace Application.CQRS.Book.Queries
{
    public class GetAllBooksQuery : IRequest<List<BookReadDto>>
    {

    }
}