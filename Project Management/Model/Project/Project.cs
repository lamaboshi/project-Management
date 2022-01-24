using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model
{
    public class Project: BaseModel
    {
        public string Name { get; set; }
        [Display(Name = "Remember me?")]
        public DateTime? Start { get; set; }
        [Display(Name = "Remember me?")]
        public DateTime? End { get; set; }
        public String Note { get; set; }
        [Display(Name = "Remember me?")]
        
        public bool? stutas { get; set; }
        public DateTime? DateIn { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<RolePersonProject> RolePersonProjects { get; set; }

    }
}
