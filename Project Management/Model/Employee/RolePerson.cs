using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model.Employee
{
   public class RolePerson:BaseModel
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<RolePersonProject> RolePersonProjects { get; set; }
    }
}
