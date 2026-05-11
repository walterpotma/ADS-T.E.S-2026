using System;

namespace Walter.Models;

public class Livro
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Autor { get; set; }
    public bool Disponivel { get; set; } = true;
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    public DateTime AtualizadoEm { get; set; }
}
