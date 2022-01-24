using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model
{
    public class Task:BaseModel
    {
        public string Name { get; set; }
        public int? Number { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public bool? Stutes { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<TaskMeeting> TaskMeetings { get; set; }
    }
}
