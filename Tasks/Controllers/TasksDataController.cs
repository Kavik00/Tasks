using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    public class TasksDataController : Controller
    {
        private static List<Task> TasksData = new List<Task>
        {
            new Task() {Title = "First Task", Completed=false, Created = "10-11-2016", Updated = "10-11-2016", Notes="", ButtonText = "Complete" },
            new Task() {Title = "Second Task", Completed=false, Created = "10-11-2016", Updated = "10-11-2016", Notes="", ButtonText = "Complete" },
            new Task() {Title = "Third Task", Completed=false, Created = "10-11-2016", Updated = "10-11-2016", Notes="", ButtonText = "Complete" },
            new Task() {Title = "Fourth Task", Completed=false, Created = "10-11-2016", Updated = "10-11-2016", Notes="", ButtonText = "Complete" }
        };

        [HttpGet("[action]")]
        public IActionResult GetTasks()
        {
            return Json(TasksData);            
        }

        [HttpDelete("{task}")]
        public IActionResult DeleteTask(Task task)
        {
            TasksData.Remove(task);
            return new NoContentResult();
        }
    }

    public class Task
    {
        public string Title { get; set; }
        public bool Completed { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Notes { get; set; }
        public string ButtonText { get; set; }

    }
}
