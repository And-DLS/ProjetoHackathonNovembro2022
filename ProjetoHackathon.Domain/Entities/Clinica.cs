namespace ProjetoHackathon.Domain.Entities;

public class Clinica : Entity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public IList<Cliente> Clientes { get; set; }

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

    public Clinica(string nome, string email, string senha, int idUsuario)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        Clientes = new List<Cliente>();
        UsuarioId = idUsuario;
    }

    public Clinica(int id, string nome, string email, string senha, int idUsuario)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
        Clientes = new List<Cliente>();
        UsuarioId = idUsuario;
    }

    public Clinica()
    {
        Clientes = new List<Cliente>();
    }
}