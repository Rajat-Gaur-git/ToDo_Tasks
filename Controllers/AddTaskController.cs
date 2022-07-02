using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoTasks.Methods;
using ToDoTasks.Models;

namespace ToDoTasks.Controllers
{
    public class AddTaskController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode=HttpStatusCode.OK};
        }

        public HttpResponseMessage POST(HttpRequestMessage request)
        {
            string paramsSend = Request.Content.ReadAsStringAsync().Result;
            string response;
            TaskModel task = new TaskModel();
            task = JsonConvert.DeserializeObject<TaskModel>(paramsSend.ToString());
            string taskHead = task.TaskHead;
            string taskDesc = task.TaskDescription;
            string taskStatus = task.Status;
            DBTransactions dBTransactions = new DBTransactions();
            response = dBTransactions.AddTaskToDB(taskHead,taskDesc,taskStatus);
            return Request.CreateResponse(HttpStatusCode.OK, response);


        }
    }
}
