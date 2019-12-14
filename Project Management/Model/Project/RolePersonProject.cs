using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model
{
    public class RolePersonProject:BaseModel
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int RolePersonId { get; set; }
        public Employee.RolePerson RolePerson { get; set; }
        public ICollection<TaskMetRPP> TaskMetRPPs { get; set; }
    }
}
