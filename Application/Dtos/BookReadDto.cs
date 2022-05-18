using Domain.Enums;

namespace Application.Dtos
{
    public class BookReadDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public bool availability { get; set; }

        public BooksType types { get; set; }
    }
}