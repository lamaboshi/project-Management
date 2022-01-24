using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model.Employee
{
   public class SpecialtyPerson:BaseModel
    {
       
        public int? PersonId { get; set; }
        public Person Person { get; set; }
        public int? SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }

    }
}
