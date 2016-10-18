using System;
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
        TaskService taskService = new TaskService();
        
        [HttpGet("[action]")]
        public IActionResult GetTasks()
        {
            return Json(taskService.GetTasks());            
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
            taskService.AddTask(task);
            return Ok(task);
        }
    }



    public class TaskService
    {
        private string _baseDirectory = System.AppContext.BaseDirectory;
        private List<TaskItem> tasksData = new List<TaskItem>();
        public List<TaskItem> GetTasks()
        {
            string json = System.IO.File.ReadAllText(_baseDirectory + "\\tasksData.json");
            tasksData = JsonConvert.DeserializeObject<List<TaskItem>>(json);

            return tasksData;
        }
        //public void SaveTask (TaskItem task)
        //{
        //    var tsk = JsonConvert.SerializeObject(task);
        //    System.IO.File.WriteAllText(_baseDirectory+"tasksData.json", tsk);

        //}

        public void SaveTasks(List<TaskItem> data)
        {
            var tsk = JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText(_baseDirectory + "\\tasksData.json", tsk);

        }

        public void AddTask(TaskItem task)
        {
            var currentTasks = GetTasks();
            if (currentTasks.Count() > 0)
            {
                var maxId = currentTasks.Where(t => t.Id == currentTasks.Max(m => m.Id)).FirstOrDefault().Id;
                task.Id = maxId + 1;
            }
            else task.Id = 1;

            tasksData.Add(task);
            SaveTasks(tasksData);

        }

        public void DeleteTask(int id)
        {
            var currentTasks = GetTasks();
            var toDelete = currentTasks.Find(t => t.Id == id);
            currentTasks.Remove(toDelete);
            SaveTasks(currentTasks);   
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


        public static List<TaskItem> TasksData = new List<TaskItem>
        {
            new TaskItem() {Id=1, Title = "First Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=2, Title = "Second Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=3, Title = "Third Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=4, Title = "Fourth Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" }
        };
    }


}
