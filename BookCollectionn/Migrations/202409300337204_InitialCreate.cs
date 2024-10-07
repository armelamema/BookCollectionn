namespace BookCollectionn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .Index(t => t.AuthorID);
            
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        BookID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookID, t.GenreID })
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookGenres", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.BookGenres", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "AuthorID", "dbo.Authors");
            DropIndex("dbo.BookGenres", new[] { "GenreID" });
            DropIndex("dbo.BookGenres", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "AuthorID" });
            DropTable("dbo.Genres");
            DropTable("dbo.BookGenres");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
