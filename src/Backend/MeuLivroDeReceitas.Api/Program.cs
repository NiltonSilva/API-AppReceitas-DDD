using MeuLivroDeReceitas.Api.Filtros;
using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Infrastructure;
using MeuLivroDeReceitas.Infrastructure.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositorio(builder.Configuration);

builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasExceptions)));

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

AtualizarBaseDeDados();

app.Run();

void AtualizarBaseDeDados()
{
    var conexao = builder.Configuration.GetConexao();
    var nomeDatabase = builder.Configuration.GetNomeDatabase();

    Database.CriarDatabase(conexao, nomeDatabase);

    app.MigrateBancoDeDados();
}