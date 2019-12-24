namespace Project_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Two : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Note");
        }
    }
}
