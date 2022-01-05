using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using apiHangFire.Commands;
using apiHangFire.Data;
using apiHangFire.Dtos;
using apiHangFire.Model;
using MediatR;
using System;
using Hangfire;
using apiHangFire.HangFire;

namespace apiHangFire.Handlers
{
    public class CreateBooksHandler : IRequestHandler<CreateBookCommands, BookReadDto>
    {

        HangFireJobs hangFireJobs = new HangFireJobs();

        private readonly IBookRepo _repository; 
        private readonly IMapper _mapper; 
        public CreateBooksHandler(IBookRepo repository, IMapper mapper){

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
          await _repository.CreateBooks(books);
           _repository.SaveChanges();

          BackgroundJob.Enqueue(() => hangFireJobs.CreateJobForAddBook());
          BackgroundJob.Schedule(() => hangFireJobs.CreateJobForAddBook(), TimeSpan.FromMinutes(4));

            return _mapper.Map<BookReadDto>(books);





        }
    }
}