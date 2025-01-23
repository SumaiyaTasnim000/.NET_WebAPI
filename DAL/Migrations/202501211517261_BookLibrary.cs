namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookLibrary : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Borrows", "BookId", "dbo.Books");
            DropForeignKey("dbo.Borrows", "UserId", "dbo.Users");
            AddForeignKey("dbo.Borrows", "BookId", "dbo.Books", "Id");
            AddForeignKey("dbo.Borrows", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrows", "UserId", "dbo.Users");
            DropForeignKey("dbo.Borrows", "BookId", "dbo.Books");
            AddForeignKey("dbo.Borrows", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Borrows", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
