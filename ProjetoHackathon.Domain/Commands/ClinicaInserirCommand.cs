using ProjetoHackathon.Domain.Commands.Interfaces;
using ProjetoHackathon.Domain.Entities;
using ProjetoHackathon.Domain.Validations;

namespace ProjetoHackathon.Domain.Commands;

public class ClinicaInserirCommand : Notificavel, ICommand
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public int IdUsuario { get; set; }


    public ClinicaInserirCommand() { }

    public ClinicaInserirCommand(string nome, string email, string senha, int idUsuario)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        IdUsuario = idUsuario;
    }

    public void Validar()
    {
        if (string.IsNullOrEmpty(Nome))
            AdicionarNotificacao("Nome da clinica deve ser informado");
        if (IdUsuario <= 0)
            AdicionarNotificacao("Código do usuario informado inválido");
        if (string.IsNullOrEmpty(Email))
            AdicionarNotificacao("Email da clinica deve ser informada");
        if (string.IsNullOrEmpty(Senha))
            AdicionarNotificacao("Senha da clinica deve ser informada");
    }
}