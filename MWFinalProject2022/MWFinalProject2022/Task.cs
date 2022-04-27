using System;
using System.Collections.Generic;
using System.Text;

namespace MWFinalProject2022
{
    public class Task
    {
        public Task(string taskId, string description, DateTime deadLine)
        {
            TaskId = taskId;
            Description = description;
            DeadLine = deadLine.ToShortDateString(); ;
        }

        public string TaskId { get; set; }
        public string Description { get; set; }
        public string DeadLine { get; set; }
    }

}
