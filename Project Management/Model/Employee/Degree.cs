using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model.Employee
{
   public class Degree:BaseModel
    {
        public string language { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
    }
}
