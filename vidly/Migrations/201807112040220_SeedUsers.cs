namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            // Seeding the data
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b053ce5a-3e5b-4858-b5d4-c127c1530ddb', N'ajutas@gmail.com', 0, N'ADmJwio3p67dijSNEz+IiW7wmiLPYooFWHI4FsqNAzCfCtZR3PiBVoY1ZrB4MP+S8A==', N'894dc944-52ae-45b9-beae-1ff93f3a6998', NULL, 0, 0, NULL, 1, 0, N'ajutas@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b9b91a02-8438-4c1d-b578-687090bb5332', N'admin@gmail.com', 0, N'ADYmZvYHyqCtMzbQK7WS/NCpjvxaXxAXJxf8haywmxOYLEw1RixZ+jtg8yHpBfTKiw==', N'3c394fed-082c-4765-a59a-9b7b9361f5a3', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3fce1fe9-c3c2-4fd9-a0d4-04279ebe8407', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b9b91a02-8438-4c1d-b578-687090bb5332', N'3fce1fe9-c3c2-4fd9-a0d4-04279ebe8407')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
