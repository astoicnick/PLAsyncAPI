using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace plApi.Services {
    public interface IBooksRepository {
        //IEnumerable<Entities.Book> GetBooks();

        //Entities.Book GetBook(Guid id);

        //Async versions
        Task<IEnumerable<Entities.Book>> GetBooksAsync();
        Task<Entities.Book> GetBookAsync(Guid id);
    }
}