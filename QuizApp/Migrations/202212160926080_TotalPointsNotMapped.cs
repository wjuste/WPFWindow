namespace QuizApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalPointsNotMapped : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "TotalPoints");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "TotalPoints", c => c.Int(nullable: false));
        }
    }
}
