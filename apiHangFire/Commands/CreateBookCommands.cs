using System;
using apiHangFire.Dtos;
using MediatR;

namespace apiHangFire.Commands
{
    public class CreateBookCommands : IRequest<BookReadDto>
    {

        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public bool availability { get; set; }
    }
}