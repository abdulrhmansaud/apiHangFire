using apiHangFire.Enums;

namespace apiHangFire.Dtos
{
    public class BookCreateDto
    {
        
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public bool availability { get; set; }

        public BooksType types { get; set; }
    }
}