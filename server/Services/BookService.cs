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

        //public Product Get(string id) =>
        //    _books.Find<Product>(book => book.Id == id).FirstOrDefault();

        //public Product Create(Product book)
        //{
        //    _books.InsertOne(book);
        //    return book;
        //}

        //public void Update(string id, Product bookIn) =>
        //    _books.ReplaceOne(book => book.Id == id, bookIn);

        //public void Remove(Product bookIn) =>
        //    _books.DeleteOne(book => book.Id == bookIn.Id);

        //public void Remove(string id) =>
        //    _books.DeleteOne(book => book.Id == id);
    }
#pragma warning restore CS1591
}
