using System;
using Application.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.CQRS.Book.Commands
{
    public class CreateBookCommands : IRequest<BookReadDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public bool availability { get; set; }

        public BooksType types { get; set; }
    }
}