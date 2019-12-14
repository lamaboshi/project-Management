using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model
{
   public class TaskMeeting :BaseModel
    {
        public int? TaskId { get; set; }
        public Task Task { get; set; }
        public int MeetingId { get; set; }
        public Meeting Meeting { get; set; }
        public ICollection<TaskMetRPP> TaskMetRPPs { get; set; }
    }
}
