using System;
using System.Collections.Generic;

namespace ProjetoFinalV2;

public partial class Venda
{
    public int IdVenda { get; set; }

    public int? IdProduto { get; set; }

    public int QuantidadeVendido { get; set; }

    public int? IdCliente { get; set; }

    public byte[] DataVenda { get; set; } = null!;

    public double ValorVenda { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Produto? IdProdutoNavigation { get; set; }
}
