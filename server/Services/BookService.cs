using System;
using System.Linq;
using MongoDB.Driver;
using System.Collections.Generic;

using server.Models;

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

        public List<Book> getBooks()
        {
            try
            {
                var res = _books.Find(book => true);
                return res.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                throw;
            }
        }
        
        public Book getBookById(string id)
        {
            try
            {
                var res = _books.Find<Book>(book => book.Id == id).FirstOrDefault();
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
