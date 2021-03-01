
namespace server.Models
{
    public class BookStoreDatabaseSettings : IBookStoreDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string OrderCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBookStoreDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string OrderCollectionName { get; set; }
        string CustomerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
