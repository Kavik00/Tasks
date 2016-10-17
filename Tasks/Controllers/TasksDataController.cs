﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    
    public class TasksDataController : Controller
    {
        public static List<TaskItem> TasksData = new List<TaskItem>
        {
            new TaskItem() {Id=1, Title = "First Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=2, Title = "Second Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=3, Title = "Third Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=4, Title = "Fourth Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" }
        };

        TaskService taskService = new TaskService();


        [HttpGet("[action]")]
        public IActionResult GetTasks()
        {
            return Json(TasksData);            
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteTask(int id)
        {
            taskService.DeleteTask(id);
            return new NoContentResult();
        }

        [HttpPost ("[action]")]
        [ProducesResponseType(typeof(TaskItem),201)]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {

            TasksData.Add(task);
            //"taskService.SaveTasks(TasksData);
            return Ok(task);
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Notes { get; set; }
        public string ButtonText { get; set; }

    }

    public class TaskService
    {
        public void SaveTask (TaskItem task)
        {
            var tsk = JsonConvert.SerializeObject(task);
            System.IO.File.WriteAllText(@"C:\Users\gary\Source\Repos\Tasks\Tasks\Tasks\tasksData.json", tsk);

        }

        public void SaveTasks(List<TaskItem> data)
        {
            var tsk = JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText(@"C:\Users\gary\Source\Repos\Tasks\Tasks\Tasks\tasksData.json", tsk);

        }

        public void DeleteTask(int id)
        {
           var toDelete = TasksDataController.TasksData.Find(t => t.Id == id);
            TasksDataController.TasksData.Remove(toDelete);

               
        }

    }
}
