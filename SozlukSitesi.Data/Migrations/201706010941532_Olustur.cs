namespace SozlukSitesi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Olustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baslik",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        YayinTarihi = c.DateTime(nullable: false),
                        Like = c.Int(nullable: false),
                        Hate = c.Int(nullable: false),
                        Yayınlayan_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kullanici", t => t.Yayınlayan_ID)
                .Index(t => t.Yayınlayan_ID);
            
            CreateTable(
                "dbo.Entry",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        girisTarihi = c.DateTime(nullable: false),
                        Metin = c.String(nullable: false),
                        kisaMetin = c.String(nullable: false),
                        Like = c.Int(nullable: false),
                        Hate = c.Int(nullable: false),
                        Baslik_ID = c.Int(nullable: false),
                        eSahibi_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Baslik", t => t.Baslik_ID, cascadeDelete: true)
                .ForeignKey("dbo.Kullanici", t => t.eSahibi_ID)
                .Index(t => t.Baslik_ID)
                .Index(t => t.eSahibi_ID);
            
            CreateTable(
                "dbo.Mesaj",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Goruldu = c.Boolean(nullable: false),
                        GonderimTarihi = c.DateTime(nullable: false),
                        Metin = c.String(),
                        Alan_ID = c.Int(),
                        Gonderen_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kullanici", t => t.Alan_ID)
                .ForeignKey("dbo.Kullanici", t => t.Gonderen_ID)
                .Index(t => t.Alan_ID)
                .Index(t => t.Gonderen_ID);
            
            AddColumn("dbo.Kullanici", "Cinsiyet", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mesaj", "Gonderen_ID", "dbo.Kullanici");
            DropForeignKey("dbo.Mesaj", "Alan_ID", "dbo.Kullanici");
            DropForeignKey("dbo.Entry", "eSahibi_ID", "dbo.Kullanici");
            DropForeignKey("dbo.Entry", "Baslik_ID", "dbo.Baslik");
            DropForeignKey("dbo.Baslik", "Yayınlayan_ID", "dbo.Kullanici");
            DropIndex("dbo.Mesaj", new[] { "Gonderen_ID" });
            DropIndex("dbo.Mesaj", new[] { "Alan_ID" });
            DropIndex("dbo.Entry", new[] { "eSahibi_ID" });
            DropIndex("dbo.Entry", new[] { "Baslik_ID" });
            DropIndex("dbo.Baslik", new[] { "Yayınlayan_ID" });
            DropColumn("dbo.Kullanici", "Cinsiyet");
            DropTable("dbo.Mesaj");
            DropTable("dbo.Entry");
            DropTable("dbo.Baslik");
        }
    }
}
