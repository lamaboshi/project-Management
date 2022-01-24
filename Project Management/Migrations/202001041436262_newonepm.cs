namespace Project_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newonepm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Specialties", "DegreeId", "dbo.Degrees");
            DropForeignKey("dbo.SpecialtyPersons", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.SpecialtyPersons", "PersonId", "dbo.People");
            DropForeignKey("dbo.RolePersonProjects", "RolePersonId", "dbo.RolePersons");
            DropForeignKey("dbo.RolePersonProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Meetings", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Specialties", new[] { "DegreeId" });
            DropIndex("dbo.SpecialtyPersons", new[] { "PersonId" });
            DropIndex("dbo.SpecialtyPersons", new[] { "SpecialtyId" });
            DropIndex("dbo.RolePersonProjects", new[] { "ProjectId" });
            DropIndex("dbo.RolePersonProjects", new[] { "RolePersonId" });
            DropIndex("dbo.Meetings", new[] { "ProjectId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            AlterColumn("dbo.Specialties", "DegreeId", c => c.Int());
            AlterColumn("dbo.SpecialtyPersons", "PersonId", c => c.Int());
            AlterColumn("dbo.SpecialtyPersons", "SpecialtyId", c => c.Int());
            AlterColumn("dbo.RolePersonProjects", "ProjectId", c => c.Int());
            AlterColumn("dbo.RolePersonProjects", "RolePersonId", c => c.Int());
            AlterColumn("dbo.Projects", "Start", c => c.DateTime());
            AlterColumn("dbo.Projects", "End", c => c.DateTime());
            AlterColumn("dbo.Projects", "stutas", c => c.Boolean());
            AlterColumn("dbo.Projects", "DateIn", c => c.DateTime());
            AlterColumn("dbo.Meetings", "Number", c => c.Int());
            AlterColumn("dbo.Meetings", "Stutes", c => c.Boolean());
            AlterColumn("dbo.Meetings", "ProjectId", c => c.Int());
            AlterColumn("dbo.Tasks", "Number", c => c.Int());
            AlterColumn("dbo.Tasks", "DateStart", c => c.DateTime());
            AlterColumn("dbo.Tasks", "DateEnd", c => c.DateTime());
            AlterColumn("dbo.Tasks", "Stutes", c => c.Boolean());
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Int());
            CreateIndex("dbo.Specialties", "DegreeId");
            CreateIndex("dbo.SpecialtyPersons", "PersonId");
            CreateIndex("dbo.SpecialtyPersons", "SpecialtyId");
            CreateIndex("dbo.RolePersonProjects", "ProjectId");
            CreateIndex("dbo.RolePersonProjects", "RolePersonId");
            CreateIndex("dbo.Meetings", "ProjectId");
            CreateIndex("dbo.Tasks", "ProjectId");
            AddForeignKey("dbo.Specialties", "DegreeId", "dbo.Degrees", "Id");
            AddForeignKey("dbo.SpecialtyPersons", "SpecialtyId", "dbo.Specialties", "Id");
            AddForeignKey("dbo.SpecialtyPersons", "PersonId", "dbo.People", "Id");
            AddForeignKey("dbo.RolePersonProjects", "RolePersonId", "dbo.RolePersons", "Id");
            AddForeignKey("dbo.RolePersonProjects", "ProjectId", "dbo.Projects", "Id");
            AddForeignKey("dbo.Meetings", "ProjectId", "dbo.Projects", "Id");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Meetings", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.RolePersonProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.RolePersonProjects", "RolePersonId", "dbo.RolePersons");
            DropForeignKey("dbo.SpecialtyPersons", "PersonId", "dbo.People");
            DropForeignKey("dbo.SpecialtyPersons", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Specialties", "DegreeId", "dbo.Degrees");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Meetings", new[] { "ProjectId" });
            DropIndex("dbo.RolePersonProjects", new[] { "RolePersonId" });
            DropIndex("dbo.RolePersonProjects", new[] { "ProjectId" });
            DropIndex("dbo.SpecialtyPersons", new[] { "SpecialtyId" });
            DropIndex("dbo.SpecialtyPersons", new[] { "PersonId" });
            DropIndex("dbo.Specialties", new[] { "DegreeId" });
            AlterColumn("dbo.Tasks", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tasks", "Stutes", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Tasks", "DateEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tasks", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Meetings", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Meetings", "Stutes", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Meetings", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "DateIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "stutas", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "End", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Start", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RolePersonProjects", "RolePersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.RolePersonProjects", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecialtyPersons", "SpecialtyId", c => c.Int(nullable: false));
            AlterColumn("dbo.SpecialtyPersons", "PersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Specialties", "DegreeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "ProjectId");
            CreateIndex("dbo.Meetings", "ProjectId");
            CreateIndex("dbo.RolePersonProjects", "RolePersonId");
            CreateIndex("dbo.RolePersonProjects", "ProjectId");
            CreateIndex("dbo.SpecialtyPersons", "SpecialtyId");
            CreateIndex("dbo.SpecialtyPersons", "PersonId");
            CreateIndex("dbo.Specialties", "DegreeId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Meetings", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RolePersonProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RolePersonProjects", "RolePersonId", "dbo.RolePersons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SpecialtyPersons", "PersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SpecialtyPersons", "SpecialtyId", "dbo.Specialties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Specialties", "DegreeId", "dbo.Degrees", "Id", cascadeDelete: true);
        }
    }
}
