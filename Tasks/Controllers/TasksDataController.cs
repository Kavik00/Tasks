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
        private static List<TaskItem> TasksData = new List<TaskItem>
        {
            new TaskItem() {Id=1, Title = "First Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=2, Title = "Second Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=3, Title = "Third Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" },
            new TaskItem() {Id=4, Title = "Fourth Task", Completed=false, Created = DateTime.Now, Updated = DateTime.Now, Notes="", ButtonText = "Complete" }
        };



        [HttpGet("[action]")]
        public IActionResult GetTasks()
        {
            return Json(TasksData);            
        }

        [HttpDelete("{task}")]
        public IActionResult DeleteTask(TaskItem task)
        {
            TasksData.Remove(task);
            //return new NoContentResult();

        [HttpPost]
        [ProducesResponseType(typeof(TaskItem),201)]
        public IActionResult SaveTask([FromBody] TaskItem task)
        {
            //var tsk = JsonConvert.SerializeObject(task);

            //System.IO.File.WriteAllText(@"C:\Users\gary\Source\Repos\Tasks\Tasks\Tasks\tasksData.json", tsk);

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
}
