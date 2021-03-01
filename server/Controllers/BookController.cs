
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

using server.Services;
using server.Models;

namespace server.Controllers
{
#pragma warning disable CS1591
    /// <summary>
    /// Books controllers.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Get all the books.
        /// </summary>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Books are returned", Type = typeof(List<Book>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Submission not possible.")]
        public ActionResult<List<Book>> GetBooks()
        {
            try
            {
                var res = _bookService.getBooks();
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine($"List Books controller Exception: {e}");
                return Problem($"{e.Message}", null, StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// Get book details.
        /// </summary>
        /// <param name="id">Pass book ID</param>
        //[Route("{id}")]
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Book details are returned", Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Submission not possible.")]
        public ActionResult<Book> GetBookById(string id)
        {

            if (String.IsNullOrWhiteSpace(id))
                return Problem($"Book Id is not set!", null, StatusCodes.Status400BadRequest);
            try
            {
                var res = _bookService.getBookById(id);
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine($"List book controller Exception: {e}");
                return Problem($"{e.Message}", null, StatusCodes.Status500InternalServerError);
            }

        }

        //[HttpGet("{id:length(24)}", Name = "GetBook")]
        //public ActionResult<Product> Get(string id)
        //{
        //    var book = _bookService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return book;
        //}

        //[HttpPost]
        //public ActionResult<Product> Create(Product book)
        //{
        //    _bookService.Create(book);

        //    return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book);
        //}

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, Product bookIn)
        //{
        //    var book = _bookService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _bookService.Update(id, bookIn);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public IActionResult Delete(string id)
        //{
        //    var book = _bookService.Get(id);

        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    _bookService.Remove(book.Id);

        //    return NoContent();
        //}

    }
#pragma warning restore CS1591
}
