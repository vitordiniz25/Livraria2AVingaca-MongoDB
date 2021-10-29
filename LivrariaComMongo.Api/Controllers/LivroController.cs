using LivrariaComMongo.Domain.Commands.Input;
using LivrariaComMongo.Domain.Entidades;
using LivrariaComMongo.Domain.Handlers;
using LivrariaComMongo.Domain.Interfaces.Repositories;
using LivrariaComMongo.Infra.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LivrariaComMongo.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/v1")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;
        private readonly LivroHandler _handler;

        public LivroController(ILivroRepository repository, LivroHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("livros")]
        public ICommandResult InserirLivro([FromBody] AdicionarLivroCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("livros/{id}")]
        public ICommandResult AtualizarLivro(string id, [FromBody] AtualizarLivroCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("livros/{id}")]
        public ICommandResult ExcluirLivro(string id)
        {
            return _handler.Handle(new RemoverLivroCommand() { Id = id });
        }

        [HttpGet]
        [Route("livros")]
        public List<Livro> ListarLivros()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("livro/{id}")]
        public Livro ObterLivro(string id)
        {
            return _repository.Obter(id);
        }
    }
}
