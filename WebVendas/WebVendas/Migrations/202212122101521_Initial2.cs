namespace WebVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetalhePedidoes",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        IdProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedido)
                .ForeignKey("dbo.Pedidoes", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cliente = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalhePedidoes", "Id", "dbo.Produtoes");
            DropForeignKey("dbo.DetalhePedidoes", "Id", "dbo.Pedidoes");
            DropIndex("dbo.DetalhePedidoes", new[] { "Id" });
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetalhePedidoes");
        }
    }
}
