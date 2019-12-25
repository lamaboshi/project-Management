using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management.Model
{
    public class TaskMetRPP:BaseModel
    {
        public int? TaskMeetingId { get; set; }
        public TaskMeeting TaskMeeting { get; set; }
        public int? RolePersonProjectId { get; set; }
        public RolePersonProject RolePersonProject { get; set; }


    }
}
