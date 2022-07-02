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
    public class UpdateTaskStatusController : ApiController
    {
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        public HttpResponseMessage POST(HttpRequestMessage request)
        {
            DBTransactions dBTransactions = new DBTransactions();
            string paramsSend = request.Content.ReadAsStringAsync().Result;
            TaskModel input = JsonConvert.DeserializeObject<TaskModel>(paramsSend);
            int taskId = input.Id;
            string taskStatus = input.Status;
            string result = dBTransactions.UpdateTaskStatusDB(taskId,taskStatus).ToString();
            return Request.CreateResponse<string>(HttpStatusCode.OK, result);
        }
    }
}
