
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

using server.Services;
using server.Models;
using System.Threading.Tasks;

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
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Malformed request.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The origin server did not find.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The server encountered an unexpected condition.")]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "The server is currently unable to handle the request.")]
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
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, "Book details are returned", Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Malformed request.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The origin server did not find.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The server encountered an unexpected condition.")]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "The server is currently unable to handle the request.")]
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


        /// <summary>
        /// Create a book.
        /// </summary>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created, "Book details are stored", Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Malformed request.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The origin server did not find.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The server encountered an unexpected condition.")]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "The server is currently unable to handle the request.")]
        public ActionResult<Book> CreateBook(Book book)
        {
            if (book == null)
                return Problem($"Book data is not provided!", null, StatusCodes.Status400BadRequest);
            try
            {
                return Ok(_bookService.createBook(book));

            }
            catch (Exception e)
            {
                return Problem($"{e.Message}", null, StatusCodes.Status500InternalServerError);
            }
        }



        /// <summary>
        /// Update a book.
        /// </summary>
        /// <param name="id">Pass book ID</param>
        [HttpPut("{id}")]
        [SwaggerResponse(StatusCodes.Status201Created, "Book modified", Type = typeof(Book))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Malformed request.")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The origin server did not find.")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "The server encountered an unexpected condition.")]
        [SwaggerResponse(StatusCodes.Status503ServiceUnavailable, "The server is currently unable to handle the request.")]
        public ActionResult<Book> UpdateBook(string id, Book book)
        {

            if (String.IsNullOrWhiteSpace(id))
                return Problem($"Book Id is not set!", null, StatusCodes.Status400BadRequest);

            if (book == null)
                return Problem($"Book data is not provided!", null, StatusCodes.Status400BadRequest);

            try
            {
                return Ok(_bookService.updateBook(id, book));

            }
            catch (Exception e)
            {
                return Problem($"{e.Message}", null, StatusCodes.Status500InternalServerError);
            }
        }


    }
#pragma warning restore CS1591
}
