using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TaskManagerApp
{
    public class TaskManager : Manager
    {

        private string JsonString { get; set; }
        private Dictionary<string, Task> Tasks { get; set; }

        // Path to the existing JSON file Folder
        string FilePath = $@"C:\Users\nickr\source\repos\TaskManagerApp\bin\Debug\net6.0\UserTasks\";


        public TaskManager() {

        }

        //Sets the path of Json to the User with the ID entered in the console
        public void setUserFilePath(string userID)
        {
            FilePath = FilePath + $@"Tasks{userID}.json";
        }


        //Adds task to Dictionary, then Dictionary gets rewritten JSON
        public void addTasks(Task task) {
            
            Tasks.Add(task.getTaskID(), task);
            JsonString = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
            File.WriteAllText(FilePath, JsonString);

        }

        //Deletes task from Dictionary, then Dictionary gets rewritten to JSON
        public void deleteTask(Task task){

            Tasks.Remove(task.getTaskID());
            JsonString = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
            File.WriteAllText(FilePath, JsonString);

        }

        //Views task by parsing the Tasks Dictionary
        public void viewTasks() {

            foreach (var task in Tasks)
            {
                Console.WriteLine("     +---------------------------------------------------+");
                Console.WriteLine($"      TaskID: {task.Key}\n" +
                    $"      Title: {task.Value.getTitle()}\n" +
                    $"      Description: {task.Value.getDescription()}\n" +
                    $"      Priority: {task.Value.getPriority()}\n" +
                    $"      DueDate: {task.Value.getDueDate()}");
            }
            Console.WriteLine("     +---------------------------------------------------+");
            
        }

        public void editTask(Task task) {

            Tasks[task.getTaskID()] = task;
            JsonString = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
            File.WriteAllText(FilePath, JsonString);

        }


        //Deserializes the JSon File into a Dictionary<taskID, task>
        public override void JsonFileReader()
        {
            

            // Check if the file exists and read its content
            if (File.Exists(FilePath))
            {
                // Read and deserialize the existing content
                string existingJson = File.ReadAllText(FilePath);
                Tasks = JsonConvert.DeserializeObject<Dictionary<string, Task>>(existingJson) ?? new Dictionary<string, Task>();
            }
            else
            {
                // If the file does not exist, initialize an empty hashMap
                Tasks = new Dictionary<string, Task>();
            }

        }

        //Views a single Task
        public void viewTaskSingle(Task task)
        {
            task.printTask();
        }
        
        //Retrieves task from Dictionary
        public Task getTask(string taskID)
        {
            if (Tasks.TryGetValue(taskID, out Task task))
            {
                Console.WriteLine("Task Exists, retrieving Task...");
                return task;
            }
            else
            {
                Console.WriteLine("Task not found.");
                return null;
            }
            
        }

        //Checks if Dictionary is Empty
        public override bool dictionaryIsEmpty()
        {
            return !Tasks.Any();
        }


        //Returns Dictionary Tasks
        public Dictionary<string, Task> getTasks()
        {
            return Tasks;
        }



    }
}
