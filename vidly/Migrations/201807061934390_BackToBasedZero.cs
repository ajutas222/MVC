namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackToBasedZero : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
