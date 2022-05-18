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
    public class GetBooksByIdHandler : IRequestHandler<GetBooksByIdQuery, BookReadDto>
    {
        private readonly IBookRepo _repository;
        private readonly IMapper _mapper;
        public GetBooksByIdHandler(IBookRepo repository, IMapper mapper)
        {

            _mapper = mapper;
            _repository = repository;

        }
        public async Task<BookReadDto> Handle(GetBooksByIdQuery request, CancellationToken cancellationToken)
        {
            var getbyid = await _repository.GetBookById(request.Id);
            if (getbyid == null)
            {
                return null;
            }

            return _mapper.Map<BookReadDto>(getbyid);


        }

    }
}