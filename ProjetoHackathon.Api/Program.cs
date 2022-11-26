using Microsoft.EntityFrameworkCore;
using ProjetoHackathon.Domain.Handlers;
using ProjetoHackathon.Domain.Repositories;
using ProjetoHackathon.Infra.Contexts;
using ProjetoHackathon.Infra.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Injecao de dependencias - DI
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("connectionString")
    )
);
builder.Services.AddTransient<IClinicaRepository, ClinicaRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ClinicaHandler, ClinicaHandler>();
builder.Services.AddTransient<ClienteHandler, ClienteHandler>();
builder.Services.AddTransient<UsuarioHandler, UsuarioHandler>();

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
