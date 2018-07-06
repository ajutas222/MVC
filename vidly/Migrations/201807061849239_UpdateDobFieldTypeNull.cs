namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDobFieldTypeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
