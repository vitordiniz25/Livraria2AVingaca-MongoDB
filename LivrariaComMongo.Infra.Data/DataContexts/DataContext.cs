using LivrariaComMongo.Domain.Entidades;
using LivrariaComMongo.Infra.Settings;
using MongoDB.Driver;

namespace LivrariaComMongo.Infra.Data.DataContexts
{
    public class DataContext
    {
        public IMongoCollection<Livro> Livros { get; set; }

        public DataContext(AppSettings appSettings)
        {
            var client = new MongoClient(appSettings.ConnectionString);
            var database = client.GetDatabase(appSettings.DatabaseName);
            Livros = database.GetCollection<Livro>(appSettings.CollectionName);
        }
    }
}
