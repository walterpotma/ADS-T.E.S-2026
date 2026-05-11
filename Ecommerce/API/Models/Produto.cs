using System;

namespace API.Models;

public class Produto
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? Nome { get; set; }
    public string? Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public DateTime AtualizadoEm { get; set; }
}
