using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_Management.Model
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        [DefaultValue(false)]
        public bool IsDelete { get; set; }
    }
}
