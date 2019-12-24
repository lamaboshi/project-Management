using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model
{
    public class Project: BaseModel
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Note { get; set; }
        public bool stutas { get; set; }
        public DateTime DateIn { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<RolePersonProject> RolePersonProjects { get; set; }

    }
}
