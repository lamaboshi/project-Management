using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.View.InnerClass
{
  public class EmployeeInfo
    {
        public EmployeeInfo()
        {
            ListDegr = new List<Model.Employee.Degree>();
            Listrole = new List<Model.Employee.Role>();
            Listspac = new List<Model.Employee.Specialty>();
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public List<Model.Employee.Role> Listrole { get; set; }
        public List<Model.Employee.Specialty> Listspac { get; set; }
        public List<Model.Employee.Degree> ListDegr { get; set; }
    }
}
