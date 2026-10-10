using LibraryManagementAPI.Interface;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


  
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _bookRepository.GetAllBooks();

            return Ok(response);
        }


      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var response = await _bookRepository.GetBookById(id);

            return Ok(response);
        }


      
        [HttpPost]
        public async Task<IActionResult> InsertBook(BookRequest request)
        {
            var response = await _bookRepository.InsertBook(request);

            return Ok(response);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(
            int id,
            BookRequest request)
        {
            var response = await _bookRepository.UpdateBook(id, request);

            return Ok(response);
        }


   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookRepository.DeleteBook(id);

            return Ok(response);
        }


      
        [HttpGet("search")]
        public async Task<IActionResult> SearchBooks(string search)
        {
            var response = await _bookRepository.SearchBooks(search);

            return Ok(response);
        }
    }
}