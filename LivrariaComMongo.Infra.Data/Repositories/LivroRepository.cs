using LivrariaComMongo.Domain.Entidades;
using LivrariaComMongo.Domain.Interfaces.Repositories;
using LivrariaComMongo.Infra.Data.DataContexts;
using MongoDB.Driver;
using System.Collections.Generic;

namespace LivrariaComMongo.Infra.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly DataContext _dataContext;

        public LivroRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Livro Inserir(Livro livro)
        {
            _dataContext.Livros.InsertOne(livro);
            return livro;
        }

        public void Atualizar(Livro livro)
        {
            _dataContext.Livros.ReplaceOne(book => book.Id == livro.Id, livro);
        }

        public void Excluir(string id)
        {
            _dataContext.Livros.DeleteOne(book => book.Id == id);
        }

        public List<Livro> Listar()
        {
            return _dataContext.Livros.Find(book => true).ToList();
        }

        public Livro Obter(string id)
        {
            return _dataContext.Livros.Find(book => book.Id == id).FirstOrDefault();
        }

        public bool CheckId(string id)
        {
            return _dataContext.Livros.Find(book => book.Id == id).Any();
        }
    }
}
