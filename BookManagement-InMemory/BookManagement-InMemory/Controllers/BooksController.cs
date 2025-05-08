using BookManagement_InMemory.Models;
using BookManagement_InMemory.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement_InMemory.Controllers
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

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBooksById(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound("This Book Does not exist");
            }

            return Ok(book);
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bookRepository.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBooksById), new { id = book.Id }, book);
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest("Provided Id not matched");
            }

            try
            {
                await _bookRepository.UpateBookAsync(book);
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok(book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if(book == null)
            {
                return NotFound();
            }

            await _bookRepository.DeleteBookAsync(id);

            return Ok("Book Deleted Successfully");
        }
    }
}
