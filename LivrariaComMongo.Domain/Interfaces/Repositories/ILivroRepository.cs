using LivrariaComMongo.Domain.Entidades;
using LivrariaComMongo.Domain.QueryResults;
using System.Collections.Generic;

namespace LivrariaComMongo.Domain.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        Livro Inserir(Livro livro);
        void Atualizar(Livro livro);
        void Excluir(string id);
        List<Livro> Listar();
        Livro Obter(string id);
        bool CheckId(string id);
    }
}
