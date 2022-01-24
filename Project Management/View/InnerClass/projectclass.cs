using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.View.InnerClass
{
   public class projectclass
    {
   
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public string Name { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public String Note { get; set; }
        public bool? stutas { get; set; }
        public DateTime? DateIn { get; set; }
       public int? CountTask { get; set; }
        public int? CountMetting { get; set; }
        public List<EmployeeClass> RoleEmp { get; set; }
        public List<Model.Employee.Degree> EmpDeg { get; set; }
        public projectclass()
        {
            EmpDeg = new List<Model.Employee.Degree>();
            RoleEmp = new List<EmployeeClass>();

        }
    }
}
