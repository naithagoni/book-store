using System;
using System.Linq;
using MongoDB.Driver;
using System.Collections.Generic;

using server.Models;
using System.Threading.Tasks;

namespace server.Services
{
#pragma warning disable CS1591
    public class BookService
    {
        private IMongoCollection<Book> _books;

        public BookService(IBookStoreDatabaseSettings bookSettings)
        {
            var client = new MongoClient(bookSettings.ConnectionString);
            var database = client.GetDatabase(bookSettings.DatabaseName);

            _books = database.GetCollection<Book>(bookSettings.ProductCollectionName);
        }

        public async Task<List<Book>> getBooks()
        {
            try
            {
                return (List<Book>)await _books.Find(book => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                throw;
            }
        }


        public async Task<Book> getBookById(string id)
        {
            try
            {
                return (Book)await _books.Find<Book>(book => book.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                throw;
            }
        }


        public Book createBook(Book book)
        {
            try
            {
                _books.InsertOne(book);
                return book;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                throw;
            }
        }


        public async Task<ReplaceOneResult> updateBook(string id, Book book)
        {
            try
            {
               var res = await _books.ReplaceOneAsync(bk => bk.Id == id, book);
                return res;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                throw;
            }
        }        
        
        
        
        public async Task<DeleteResult> deleteBook(string id)
        {
            try
            {
                var res = await _books.DeleteOneAsync(book => book.Id == id);
                return res;

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                throw;
            }
        }


    }
#pragma warning restore CS1591
}
