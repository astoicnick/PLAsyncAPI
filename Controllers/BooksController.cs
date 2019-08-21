using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plApi.Services;

namespace plApi.Controllers {
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase {
        private IBooksRepository _booksRepo;

        public BooksController(IBooksRepository booksRepo)
        {
            _booksRepo = booksRepo
                ?? throw new ArgumentNullException(nameof(booksRepo));
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks(){
          var bookEntities = await _booksRepo.GetBooksAsync();
          return Ok(bookEntities); 
        }
    }
}