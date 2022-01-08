namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'026d36a7-8885-45d2-81cc-1c9dc5e3b03a', N'guest@vildy.com', 0, N'ACLv8mcSoSHU+JILUwqnMIolVLw8N1noTx+E1YTsRVAUsylQnIDV2tcKaHZIJFzcCQ==', N'33f6e9ad-07d4-49e3-99f3-a8db306c2368', NULL, 0, 0, NULL, 1, 0, N'guest@vildy.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5cbe08df-d78e-47d5-bda8-9965b68f2bf0', N'admin2@vidly.com', 0, N'AHPM4bGKr/kbAc82sGLzOJNQqOpXUoisQHkFWNYbr+q2YB2uZSw+kHic039TyMwGig==', N'fe146926-df39-4be5-9bc6-208add053cc2', NULL, 0, 0, NULL, 1, 0, N'admin2@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'321e3e15-c47a-4577-940e-7673dff4840d', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5cbe08df-d78e-47d5-bda8-9965b68f2bf0', N'321e3e15-c47a-4577-940e-7673dff4840d')

");
        }
        
        public override void Down()
        {
        }
    }
}
