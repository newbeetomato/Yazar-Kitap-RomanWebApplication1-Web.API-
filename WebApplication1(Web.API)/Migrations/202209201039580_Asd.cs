namespace WebApplication1_Web.API_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kitaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        YazarID = c.Int(nullable: false),
                        TurID = c.Int(nullable: false),
                        RafID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rafs", t => t.RafID, cascadeDelete: true)
                .ForeignKey("dbo.Turs", t => t.TurID, cascadeDelete: true)
                .ForeignKey("dbo.Yazars", t => t.YazarID, cascadeDelete: true)
                .Index(t => t.YazarID)
                .Index(t => t.TurID)
                .Index(t => t.RafID);
            
            CreateTable(
                "dbo.Rafs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Turs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yazars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurName = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Status = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kitaps", "YazarID", "dbo.Yazars");
            DropForeignKey("dbo.Kitaps", "TurID", "dbo.Turs");
            DropForeignKey("dbo.Kitaps", "RafID", "dbo.Rafs");
            DropIndex("dbo.Kitaps", new[] { "RafID" });
            DropIndex("dbo.Kitaps", new[] { "TurID" });
            DropIndex("dbo.Kitaps", new[] { "YazarID" });
            DropTable("dbo.Yazars");
            DropTable("dbo.Turs");
            DropTable("dbo.Rafs");
            DropTable("dbo.Kitaps");
        }
    }
}
