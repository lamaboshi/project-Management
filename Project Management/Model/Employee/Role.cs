using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model.Employee
{
   public class Role:BaseModel
    {
        public String RoleEmpl { get; set; }
        public ICollection<RolePerson> RolePeople { get; set; }
    }
}
