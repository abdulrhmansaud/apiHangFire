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
    public class GetBooksByIdHandler : IRequestHandler<GetBooksByIdQuery, BookReadDto>
    {
        HangFireJobs hangFireJobs = new HangFireJobs();

        private readonly IBookRepo _repository; 
        private readonly IMapper _mapper; 
        public GetBooksByIdHandler(IBookRepo repository, IMapper mapper){

            _mapper = mapper; 
            _repository = repository;

        }
        public async Task<BookReadDto> Handle(GetBooksByIdQuery request, CancellationToken cancellationToken)
        {
            var getbyid = await _repository.GetBookById(request.Id);
            if(getbyid == null){
                return null;
            }

            BackgroundJob.Enqueue(() => hangFireJobs.GetBooksById());
            BackgroundJob.Schedule(() => hangFireJobs.GetBooksById(), TimeSpan.FromMinutes(4));

            return _mapper.Map<BookReadDto>(getbyid);

           
        }

    }
}