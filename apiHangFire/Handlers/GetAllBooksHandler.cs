using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using apiHangFire.Data;
using apiHangFire.Dtos;
using apiHangFire.Queries;
using MediatR;


namespace apiHangFire.Handlers
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<BookReadDto>>
    {
        private readonly IBookRepo _repository; 
        private readonly IMapper _mapper; 
        public GetAllBooksHandler(IBookRepo repository, IMapper mapper){

            _mapper = mapper; 
            _repository = repository;

        }

        public async Task<List<BookReadDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {

            var getAllBook =  await _repository.GetAllBooks();
             

            return _mapper.Map<List<BookReadDto>>(getAllBook);
        }
    }
}