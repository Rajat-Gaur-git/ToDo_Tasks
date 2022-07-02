using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ToDoTasks.Models;

namespace ToDoTasks.Methods
{
    public class DBTransactions
    {
        private static readonly string sqlConnectionString = ConfigurationManager.ConnectionStrings["SQLconnectionString"].ConnectionString;

        public string AddTaskToDB(string taskHead,string taskDesc, string taskStatus)
        {
            string response = "Task Added Sucessfully";
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    string query = $"INSERT INTO Tasks(TaskHead, TaskDesription, Status) VALUES (@TaskHead, @TaskDescription  , @Status)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TaskHead", taskHead);
                        command.Parameters.AddWithValue("@TaskDescription", taskDesc);
                        command.Parameters.AddWithValue("@Status", taskStatus);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

            }
            catch (Exception exception)
            {

                Console.WriteLine(exception);
            }

            return response;
        }

        public List<TaskModel> GetAllTasks()
        {
            List<TaskModel> readData = new List<TaskModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    string readUrl = $"select Id, TaskHead, TaskDescription, Status from Tasks where (Status = 'Incomplete' or Status='In Progress')";
                    using (SqlCommand command = new SqlCommand(readUrl, connection))
                    {
                        using (SqlDataReader data = command.ExecuteReader())
                        {
                            command.CommandTimeout = 0;

                            while (data.Read())
                            {
                                int taskId = data.GetInt32(0);
                                string taskHead = data.GetString(1);
                                string taskDesc = data.GetString(2);
                                string taskStatus = data.GetString(3);
                                readData.Add(new TaskModel
                                {
                                    Id=taskId,
                                    TaskHead = taskHead,

                                    TaskDescription = taskDesc,
                                    Status=taskStatus
                                    
                                }
                                    );

                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return readData;
        }

        public string UpdateTaskStatusDB(int taskId,string taskStatus)
        {
            string response="Marking unsucessful";
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();
                    string query = $"Update Tasks set Status = {taskStatus} where Id = {taskId}";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                response = "Task Marked " + taskStatus.ToString();
                return response;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return response;
        }

    }

}