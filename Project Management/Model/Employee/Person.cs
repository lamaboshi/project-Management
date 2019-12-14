using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model.Employee
{
   public class Person:BaseModel
    {
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public ICollection<RolePerson> RolePeople { get; set; }
        public ICollection<SpecialtyPerson> SpecialtyPeoples { get; set; }
    }
}
