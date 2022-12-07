using System;
using System.Collections.Generic;

namespace ProjetoFinalV2;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NomeCliente { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string? Email { get; set; }

    public virtual ICollection<Venda> Venda { get; } = new List<Venda>();
}
