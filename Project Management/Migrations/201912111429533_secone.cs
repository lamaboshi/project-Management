namespace Project_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        language = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Specialzation = c.String(),
                        DegreeId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Degrees", t => t.DegreeId, cascadeDelete: true)
                .Index(t => t.DegreeId);
            
            CreateTable(
                "dbo.SpecialtyPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        SpecialtyId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.SpecialtyId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleEmpl = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePersonProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        RolePersonId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.RolePersons", t => t.RolePersonId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.RolePersonId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        stutas = c.Boolean(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Stutes = c.Boolean(nullable: false),
                        ProjectMeetId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.TaskMeetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(),
                        MeetingId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meetings", t => t.MeetingId, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.TaskId)
                .Index(t => t.MeetingId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Stutes = c.Boolean(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.TaskMetRPPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskMeetingId = c.Int(nullable: false),
                        RolePersonProjectId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RolePersonProjects", t => t.RolePersonProjectId, cascadeDelete: true)
                .ForeignKey("dbo.TaskMeetings", t => t.TaskMeetingId, cascadeDelete: true)
                .Index(t => t.TaskMeetingId)
                .Index(t => t.RolePersonProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialtyPersons", "SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.SpecialtyPersons", "PersonId", "dbo.People");
            DropForeignKey("dbo.RolePersonProjects", "RolePersonId", "dbo.RolePersons");
            DropForeignKey("dbo.RolePersonProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TaskMetRPPs", "TaskMeetingId", "dbo.TaskMeetings");
            DropForeignKey("dbo.TaskMetRPPs", "RolePersonProjectId", "dbo.RolePersonProjects");
            DropForeignKey("dbo.TaskMeetings", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.TaskMeetings", "MeetingId", "dbo.Meetings");
            DropForeignKey("dbo.Meetings", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.RolePersons", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RolePersons", "PersonId", "dbo.People");
            DropForeignKey("dbo.Specialties", "DegreeId", "dbo.Degrees");
            DropIndex("dbo.TaskMetRPPs", new[] { "RolePersonProjectId" });
            DropIndex("dbo.TaskMetRPPs", new[] { "TaskMeetingId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.TaskMeetings", new[] { "MeetingId" });
            DropIndex("dbo.TaskMeetings", new[] { "TaskId" });
            DropIndex("dbo.Meetings", new[] { "Project_Id" });
            DropIndex("dbo.RolePersonProjects", new[] { "RolePersonId" });
            DropIndex("dbo.RolePersonProjects", new[] { "ProjectId" });
            DropIndex("dbo.RolePersons", new[] { "RoleId" });
            DropIndex("dbo.RolePersons", new[] { "PersonId" });
            DropIndex("dbo.SpecialtyPersons", new[] { "SpecialtyId" });
            DropIndex("dbo.SpecialtyPersons", new[] { "PersonId" });
            DropIndex("dbo.Specialties", new[] { "DegreeId" });
            DropTable("dbo.TaskMetRPPs");
            DropTable("dbo.Tasks");
            DropTable("dbo.TaskMeetings");
            DropTable("dbo.Meetings");
            DropTable("dbo.Projects");
            DropTable("dbo.RolePersonProjects");
            DropTable("dbo.Roles");
            DropTable("dbo.RolePersons");
            DropTable("dbo.People");
            DropTable("dbo.SpecialtyPersons");
            DropTable("dbo.Specialties");
            DropTable("dbo.Degrees");
        }
    }
}
