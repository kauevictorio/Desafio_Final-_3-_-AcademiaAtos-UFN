using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFinalV2;

public partial class DesafioFinalDbContext : DbContext
{
    public DesafioFinalDbContext()
    {
    }

    public DesafioFinalDbContext(DbContextOptions<DesafioFinalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Venda> Vendas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;initial Catalog=desafioFinal_db;User ID=desafioFinal_db;password=desafioFinal_db;language=Portuguese;Trusted_Connection=True;TrustServerCertificate=True;").UseLazyLoadingProxies();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F59C8A674D");

            entity.HasIndex(e => e.Telefone, "UQ__Clientes__2A16D97FA594C8A5").IsUnique();

            entity.HasIndex(e => e.Cpf, "UQ__Clientes__D836E71F39E1617D").IsUnique();

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente");
            entity.Property(e => e.Cpf)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cpf");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nome_cliente");
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produtos__BA38A6B848B58B40");

            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nome_produto");
            entity.Property(e => e.PrecoCompra).HasColumnName("preco_compra");
            entity.Property(e => e.PrecoVenda).HasColumnName("preco_venda");
            entity.Property(e => e.Quantidade).HasColumnName("quantidade");
            entity.Property(e => e.Tributos).HasColumnName("tributos");
        });

        modelBuilder.Entity<Venda>(entity =>
        {
            entity.HasKey(e => e.IdVenda).HasName("PK__Vendas__4595B5ABB878BADA");

            entity.Property(e => e.IdVenda).HasColumnName("id_venda");
            entity.Property(e => e.DataVenda)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("data_venda");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");
            entity.Property(e => e.QuantidadeVendido).HasColumnName("quantidade_vendido");
            entity.Property(e => e.ValorVenda).HasColumnName("valor_venda");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Vendas__id_clien__2B3F6F97");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Venda)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__Vendas__id_produ__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
