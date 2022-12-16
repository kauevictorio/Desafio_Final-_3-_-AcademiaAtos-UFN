namespace WebVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vendas", "produto_Id", "dbo.Produtoes");
            DropIndex("dbo.Vendas", new[] { "produto_Id" });
            AddColumn("dbo.Clientes", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Clientes", "Fone", c => c.String());
            AddColumn("dbo.Clientes", "Endereco", c => c.String());
            AddColumn("dbo.Clientes", "Admin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Produtoes", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtoes", "Estoque", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "Categoria", c => c.String());
            AddColumn("dbo.Produtoes", "Disponivel", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vendas", "produto", c => c.String());
            DropColumn("dbo.Clientes", "FirstName");
            DropColumn("dbo.Clientes", "LastName");
            DropColumn("dbo.Clientes", "cidade");
            DropColumn("dbo.Clientes", "pais");
            DropColumn("dbo.Produtoes", "PrecoDeVenda");
            DropColumn("dbo.Produtoes", "PrecoDeCompra");
            DropColumn("dbo.Produtoes", "Quantidade");
            DropColumn("dbo.Vendas", "produto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendas", "produto_Id", c => c.Int());
            AddColumn("dbo.Produtoes", "Quantidade", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "PrecoDeCompra", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtoes", "PrecoDeVenda", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Clientes", "pais", c => c.String());
            AddColumn("dbo.Clientes", "cidade", c => c.String());
            AddColumn("dbo.Clientes", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Clientes", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Vendas", "produto");
            DropColumn("dbo.Produtoes", "Disponivel");
            DropColumn("dbo.Produtoes", "Categoria");
            DropColumn("dbo.Produtoes", "Estoque");
            DropColumn("dbo.Produtoes", "Preco");
            DropColumn("dbo.Clientes", "Admin");
            DropColumn("dbo.Clientes", "Endereco");
            DropColumn("dbo.Clientes", "Fone");
            DropColumn("dbo.Clientes", "Name");
            CreateIndex("dbo.Vendas", "produto_Id");
            AddForeignKey("dbo.Vendas", "produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
