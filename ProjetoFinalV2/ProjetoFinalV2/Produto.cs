using System;
using System.Collections.Generic;

namespace ProjetoFinalV2;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string NomeProduto { get; set; } = null!;

    public int? Quantidade { get; set; }

    public double PrecoCompra { get; set; }

    public double Tributos { get; set; }

    public double PrecoVenda { get; set; }

    public virtual ICollection<Venda> Venda { get; } = new List<Venda>();
}
