using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model
{
    public class ContactContext: DbContext
    {
        public ContactContext() : base("Name=ConnectionStringLama")
        {

        }
        public DbSet<Employee.Degree> Degrees { get; set; }
        public DbSet<Employee.Person> People { get; set; }
        public DbSet<Employee.Role> Roles { get; set; }
        public DbSet<Employee.RolePerson> RolePeople { get; set; }
        public DbSet<Employee.Specialty> Specialties { get; set; }
        public DbSet<Employee.SpecialtyPerson> SpecialtyPeople { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RolePersonProject> RolePersonProjects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskMeeting> TaskMeetings { get; set; }
        public DbSet<TaskMetRPP> TaskMetRPPs { get; set; }

    }
}
