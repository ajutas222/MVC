namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes Set Name='Pay as You Go' where id=1");
            Sql("UPDATE MembershipTypes Set Name='Monthly' where id=2");
            Sql("UPDATE MembershipTypes Set Name='Monthly' where id=3");
            Sql("UPDATE MembershipTypes Set Name='Monthly' where id=4");
        }
        
        public override void Down()
        {
        }
    }
}
