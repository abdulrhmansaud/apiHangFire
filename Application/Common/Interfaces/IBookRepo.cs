using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IBookRepo
    {
        bool SaveChanges();
        public Task<IEnumerable<book>> GetAllBooks();
        public Task<book> GetBookById(int id);
        Task CreateBooks(book books);

    }
}