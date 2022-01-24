namespace Project_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seconepm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolePersons", "PersonId", "dbo.People");
            DropForeignKey("dbo.RolePersons", "RoleId", "dbo.Roles");
            DropIndex("dbo.RolePersons", new[] { "PersonId" });
            DropIndex("dbo.RolePersons", new[] { "RoleId" });
            AlterColumn("dbo.RolePersons", "PersonId", c => c.Int());
            AlterColumn("dbo.RolePersons", "RoleId", c => c.Int());
            AlterColumn("dbo.Meetings", "DateStart", c => c.DateTime());
            AlterColumn("dbo.Meetings", "DateEnd", c => c.DateTime());
            CreateIndex("dbo.RolePersons", "PersonId");
            CreateIndex("dbo.RolePersons", "RoleId");
            AddForeignKey("dbo.RolePersons", "PersonId", "dbo.People", "Id");
            AddForeignKey("dbo.RolePersons", "RoleId", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RolePersons", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RolePersons", "PersonId", "dbo.People");
            DropIndex("dbo.RolePersons", new[] { "RoleId" });
            DropIndex("dbo.RolePersons", new[] { "PersonId" });
            AlterColumn("dbo.Meetings", "DateEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Meetings", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RolePersons", "RoleId", c => c.Int(nullable: false));
            AlterColumn("dbo.RolePersons", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.RolePersons", "RoleId");
            CreateIndex("dbo.RolePersons", "PersonId");
            AddForeignKey("dbo.RolePersons", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RolePersons", "PersonId", "dbo.People", "Id", cascadeDelete: true);
        }
    }
}
