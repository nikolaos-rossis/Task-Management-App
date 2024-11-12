using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManagerRESTAPI.Models;
using Task = TaskManagerRESTAPI.Models.Task;
using TaskManagerRESTAPI;


namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class TaskController : ControllerBase 
    {
        TaskManager apiTaskManager = new TaskManager();

        //GET api/task/
        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            // Returns the list of all tasks as an HTTP 200 (OK) response.
            return Ok(apiTaskManager.getTasks().Values);
        }

        //GET api/task/{taskID}
        [HttpGet("{taskID}")]
        public ActionResult<Task> GetTask(string taskID)
        {
            // Tries to find a task by its ID.
            if (apiTaskManager.getTasks().TryGetValue(taskID, out var task))
            {
                // Returns the task if found (HTTP 200).
                return Ok(task);
            }
            // Returns an HTTP 404 (Not Found) if the task doesn't exist.
            return NotFound();
        }

        //POST api/task
        [HttpPost]
        public ActionResult CreateTask([FromBody] Task task)
        {
            //Checks if a task with the same ID already exists.
            if (apiTaskManager.getTasks().ContainsKey(task.getTaskID()))
            {
                //Returns an HTTP 409 (Conflict) if the task already exists.
                return Conflict("Task with the same ID already exists.");
            }
            //Adds the new task to the dictionary.
            apiTaskManager.addTasks(task);
            // Returns an HTTP 201 (Created) response, with a URI pointing to the created task.
            return CreatedAtAction(nameof(GetTask), new { taskID = task.getTaskID() }, task);
        }

        //PUT api/task/{taskID}
        [HttpPut("{taskID}")]
        public ActionResult UpdateTask(string taskID, [FromBody] Task updatedTask)
        {
            // Checks if the task exists in the dictionary.
            //if (!Tasks.ContainsKey(id))
            if (!apiTaskManager.getTasks().ContainsKey(taskID))
            {
                // Returns an HTTP 404 (Not Found) if the task doesn't exist.
                return NotFound();
            }
            // Updates the task in the dictionary.
            
            apiTaskManager.editTask(updatedTask);
            // Returns an HTTP 204 (No Content) to indicate the update was successful.
            return NoContent();
        }

        //DELETE api/task/{taskID}
        [HttpDelete("{taskID}")]
        public ActionResult DeleteTask(string taskID)
        {
            // Tries to remove the task from the dictionary.
            if (apiTaskManager.getTask(taskID) == null)
            {
                // Returns an HTTP 404 (Not Found) if the task doesn't exist.
                return NotFound();
            }

            apiTaskManager.deleteTask(apiTaskManager.getTask(taskID));
            // Returns an HTTP 204 (No Content) to indicate successful deletion.
            return NoContent();
        }
    }
}
