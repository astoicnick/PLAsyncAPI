using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using plApi.Contexts;
using plApi.Entities;

namespace plApi.Services {
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private BooksContext _context;
        public BooksRepository(BooksContext bookContext)
        {
             _context = bookContext ?? throw new ArgumentNullException(nameof(bookContext));
        }
        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context.Books.Include(book => book.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(book => book.Author).ToListAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing) {
            if (disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }   
        }
    }
}