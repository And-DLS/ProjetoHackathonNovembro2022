using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class ClinicaAlterarCommand : Notificavel, ICommand
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public int IdUsuario { get; set; }

    public ClinicaAlterarCommand() { }

    public ClinicaAlterarCommand(int id, string nome, int idUsuario, string email, string senha)
    {
        Id = id;
        Nome = nome;
        IdUsuario = idUsuario;
        Email = email;
        Senha = senha;
    }

    public void Validar()
    {
        if (Id <= 0)
            AdicionarNotificacao("Código informado inválido");

        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("O nome deve ser informado");

        if (IdUsuario <= 0)
            AdicionarNotificacao("Código do usuario informado inválido");

        if (string.IsNullOrEmpty(Email))
            AdicionarNotificacao("O email deve ser informado");

        if (string.IsNullOrEmpty(Senha))
            AdicionarNotificacao("A senha deve ser informada");
    }
}