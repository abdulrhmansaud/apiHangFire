using System;
using AutoMapper.Configuration.Annotations;

namespace apiHangFire.Dtos
{
    public class BookReadDto
    {
     
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public bool availability { get; set; }
    }
}