using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Services
{
    public class BookRepo : IBookRepo
    {
        private readonly Dbconnect _dbconnect;
        public BookRepo(Dbconnect dbconnect)
        {

            _dbconnect = dbconnect;
        }
        public async Task CreateBooks(book books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            await _dbconnect.books.AddAsync(books);
        }

        public async Task<IEnumerable<book>> GetAllBooks()
        {


            return await _dbconnect.books.ToListAsync();
        }
        public async Task<book> GetBookById(int id)
        {
            return await _dbconnect.books.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return _dbconnect.SaveChanges() >= 0;
        }
    }
}