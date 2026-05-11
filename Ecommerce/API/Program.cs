using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
var app = builder.Build();

app.MapGet("/", () => "Bem Vindo ao Ecommerce API!!");

app.MapGet("/api/produto", ([FromServices] AppDataContext _context) =>
{   
    if(_context.Produtos.Any())
    {
        return Results.Ok(_context.Produtos.ToList());
    }
    return Results.NotFound("Nenhum produto encontrado");
});

app.MapGet("/api/produto/{id}", ([FromServices] AppDataContext _context, string id) =>
{
    var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
    
    if (produto == null) return Results.NotFound();

    return Results.Ok(produto);
});

app.MapPost("/api/produto", ([FromServices] AppDataContext _context, [FromBody] Produto produto) =>
{
    Produto? resultado = _context.Produtos.FirstOrDefault(p => p.Nome == produto.Nome);
    if (resultado != null)
    {
        return Results.Conflict("Produto já existe");
    }
    _context.Produtos.Add(produto);
    _context.SaveChanges();
    return Results.Created();
});

app.Run();