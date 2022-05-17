using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using apiHangFire.Data;
using apiHangFire.Dtos;
using apiHangFire.Queries;
using MediatR;
using apiHangFire.HangFire;
using System;
using Hangfire;

namespace apiHangFire.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookReadDto>>
    {


        HangFireJobs hangFireJobs = new HangFireJobs();

        private readonly IBookRepo _repository;
        private readonly IMapper _mapper;
        public GetAllBooksHandler(IBookRepo repository, IMapper mapper) {

            _mapper = mapper;
            _repository = repository;

        }

        public async Task<List<BookReadDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {

            var getAllBook = await _repository.GetAllBooks();

            BackgroundJob.Enqueue(() => hangFireJobs.CreateJobAllbooks());
            BackgroundJob.Schedule(() => hangFireJobs.CreateJobAllbooks(), TimeSpan.FromMinutes(4));
            BackgroundJob.Schedule(() => hangFireJobs.CreateJobAllbooks(), TimeSpan.FromMinutes(5));
            BackgroundJob.Schedule(() => hangFireJobs.CreateJobAllbooks(), TimeSpan.FromMinutes(6));

            return _mapper.Map<List<BookReadDto>>(getAllBook);

        }
    }

} 


