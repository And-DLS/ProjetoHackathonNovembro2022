namespace ProjetoHackathon.Domain.Entities;

public class Usuario : Entity
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Cnpj { get; set; }
    public string Senha { get; set; }
    public IList<Clinica> Clinicas { get; set; }

    public Usuario(string nome, string email, int cnpj, string senha)
    {
        Nome = nome;
        Email = email;
        Cnpj = cnpj;
        Senha = senha;
        Clinicas = new List<Clinica>();
    }

    public Usuario(int id, string nome, string email, int cnpj, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Cnpj = cnpj;
        Senha = senha;
        Clinicas = new List<Clinica>();
    }

    public Usuario()
    {
        Clinicas = new List<Clinica>();
    }
}