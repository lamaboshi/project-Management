using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model.Employee
{
    public class Specialty:BaseModel
    {
        public String Specialzation { get; set; }
        public int DegreeId { get; set; }
        public Degree Degree { get; set; }
        public ICollection< SpecialtyPerson> SpecialtyPeoples { get; set; }
    }
}
