using Microsoft.AspNetCore.Mvc;
using ProjetoHackathon.Domain.Commands;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Handlers;
using ProjetoHackathon.Domain.Repositories;

namespace ProjetoHackathon.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteRepository _repository;
    private readonly ClienteHandler _handler;

    public ClienteController(IClienteRepository repository, ClienteHandler handler)
    {
        _repository = repository;
        _handler = handler;
    }

    [HttpGet]
    public IEnumerable<Cliente> BuscarTodos()
    {
        return _repository.BuscarTodos();
    }

    [HttpGet("{id}")]
    public Cliente? BuscarPorId(int id)
    {
        return _repository.BuscarPorId(id);
    }

    [HttpGet("clinica/{id}")]
    public IEnumerable<Cliente> BuscarPorClinica(int id)
    {
        return _repository.BuscarPorClinica(id);
    }

    [HttpPost]
    public CommandResult Inserir(ClienteInserirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [HttpPut]
    public CommandResult Alterar(ClienteAlterarCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }

    [HttpDelete]
    public CommandResult Excluir(ClienteExcluirCommand command)
    {
        return (CommandResult)_handler.Handle(command);
    }
}
