using System;
using Microsoft.AspNetCore.Mvc;
using Walter.Data;
using Walter.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Bem Vindo a Biblioteca do Walter!!");


app.MapPost("/api/livro/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Livro livro) =>
{
    var existe = ctx.Livros.FirstOrDefault(l => l.Nome == livro.Nome);

    if (existe != null)
    {
        return Results.Conflict("Já existe um livro com esse nome!!");
    }

    ctx.Livros.Add(livro);
    ctx.SaveChanges();
    return Results.Created("", livro);
});

app.MapGet("/api/livro/listar", ([FromServices] AppDataContext ctx) =>
{
    var livros = ctx.Livros.ToList();

    if (livros.Any())
    {
        return Results.Ok(livros);
    }

    return Results.NotFound("Nenhum livro cadastrado!!");
});

app.MapGet("/api/livro/buscar/{nome}", ([FromServices] AppDataContext ctx, string nome) =>
{
    var livro = ctx.Livros.FirstOrDefault(l => l.Nome == nome);

    if (livro == null)
    {
        return Results.NotFound("Não existe um livro com esse nome!!");
    }

    return Results.Ok(livro);
});

app.MapPut("/api/livro/emprestar/{nome}", ([FromServices] AppDataContext ctx, string nome) =>
{
    var livro = ctx.Livros.FirstOrDefault(l => l.Nome == nome);

    if (livro == null)
    {
        return Results.NotFound("Não existe um livro com esse nome!!");
    }

    if (livro.Disponivel == false)
    {
        return Results.Conflict("Esse livro já está emprestado!!");
    }

    livro.Disponivel = false;
    livro.AtualizadoEm = DateTime.Now;

    ctx.Livros.Update(livro);
    ctx.SaveChanges();
    return Results.Ok("Livro Emprestado com sucesso!!");
});

app.MapPut("/api/livro/devolver/{nome}", ([FromServices] AppDataContext ctx, string nome) =>
{
    var livro = ctx.Livros.FirstOrDefault(l => l.Nome == nome);

    if (livro == null)
    {
        return Results.NotFound("Não existe um livro com esse nome!!");
    }

    if (livro.Disponivel == true)
    {
        return Results.Conflict("Esse livro não está em emprestimo!!");
    }

    livro.Disponivel = true;
    livro.AtualizadoEm = DateTime.Now;

    ctx.Livros.Update(livro);
    ctx.SaveChanges();
    return Results.Ok("Livro Devolvido com sucesso!!");
});

app.MapGet("/api/livro/disponiveis", ([FromServices] AppDataContext ctx) =>
{
    var livros = ctx.Livros.Where(l => l.Disponivel == true);

    if (livros.Any())
    {
        return Results.Ok(livros);
    }
    return Results.NotFound("Nenhum livro disponivel!!");
});

app.MapGet("/api/livro/emprestados", ([FromServices] AppDataContext ctx) =>
{
    var livros = ctx.Livros.Where(l => l.Disponivel == false);

    if (livros.Any())
    {
        return Results.Ok(livros);
    }
    return Results.NotFound("Nenhum livro emprestado!!");
});

app.Run();