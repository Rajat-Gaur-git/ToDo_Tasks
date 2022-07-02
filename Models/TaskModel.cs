using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoTasks.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskHead { get; set; }
        public string TaskDescription { get; set; }
        public string Status { get; set; }
    }
}