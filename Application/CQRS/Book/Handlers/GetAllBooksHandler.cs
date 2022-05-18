using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using System;
using Hangfire;
using Application.Dtos;
using Application.CQRS.Book.Queries;
using Application.Common.Interfaces;

namespace Application.CQRS.Book.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookReadDto>>
    {
        private readonly IBookRepo _repository;
        private readonly IMapper _mapper;
        public GetAllBooksHandler(IBookRepo repository, IMapper mapper)
        {

            _mapper = mapper;
            _repository = repository;

        }

        public async Task<List<BookReadDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {

            var getAllBook = await _repository.GetAllBooks();


            return _mapper.Map<List<BookReadDto>>(getAllBook);

        }
    }

}


