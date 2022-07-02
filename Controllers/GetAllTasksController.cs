using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ToDoTasks.Methods;
using ToDoTasks.Models;

namespace ToDoTasks.Controllers
{
    public class GetAllTasksController : ApiController
    {
            public HttpResponseMessage Options()
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
            }

            public List<TaskModel> GET(HttpRequestMessage request)
            {
                DBTransactions dBTransactions = new DBTransactions();
            List<TaskModel> allTasks = dBTransactions.GetAllTasks();
                return allTasks;
            }

        }
    }
