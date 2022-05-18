using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using System;
using Hangfire;
using Application.Dtos;
using Application.CQRS.Book.Commands;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.CQRS.Book.Handlers
{
    public class CreateBooksHandler : IRequestHandler<CreateBookCommands, BookReadDto>
    {
        private readonly IBookRepo _repository;
        private readonly IMapper _mapper;

        public CreateBooksHandler(IBookRepo repository, IMapper mapper)
        {

            _mapper = mapper;
            _repository = repository;

        }

        public async Task<BookReadDto> Handle(CreateBookCommands request, CancellationToken cancellationToken)
        {
            book books = new book();
            books.Title = request.Title;
            books.Description = request.Description;
            books.Author = request.Author;
            books.availability = request.availability;
            books.types = request.types;
            await _repository.CreateBooks(books);
            _repository.SaveChanges();

            return _mapper.Map<BookReadDto>(books);





        }
    }
}