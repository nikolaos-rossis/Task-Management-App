using Newtonsoft.Json;
using Task = TaskManagerRESTAPI.Models.Task;

namespace TaskManagerRESTAPI
{
    public class TaskManager
    {
        //string Json { get; set; }

        private string JsonString { get; set; }
        private Dictionary<string, Task> Tasks { get; set; }


        public TaskManager()
        {

            //Deserializes the JSon File the moment an instance of TaskManager is created.
            JsonFileReader();
        }

        public void addTasks(Task task)
        {

            Tasks.Add(task.getTaskID(), task);
            JsonString = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
            File.WriteAllText("Tasks.json", JsonString);

        }

        public void deleteTask(Task task)
        {

            Tasks.Remove(task.getTaskID());
            JsonString = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
            File.WriteAllText("Tasks.json", JsonString);

        }

        public void viewTasks()
        {

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
            //JsonString = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
            //File.WriteAllText("Tasks.json", JsonString);
            //Console.WriteLine(JsonString);
        }

        public void editTask(Task task)
        {

            Tasks[task.getTaskID()] = task;
            JsonString = JsonConvert.SerializeObject(Tasks, Formatting.Indented);
            File.WriteAllText("Tasks.json", JsonString);

        }

        public void JsonFileReader()
        {
            // Path to the existing JSON file
            string filePath = @"C:\Users\nickr\source\repos\TaskManagerRESTAPI\Tasks.json";

            // Check if the file exists and read its content
            if (File.Exists(filePath))
            {
                // Read and deserialize the existing content
                string existingJson = File.ReadAllText(filePath);
                Tasks = JsonConvert.DeserializeObject<Dictionary<string, Task>>(existingJson) ?? new Dictionary<string, Task>();
            }
            else
            {
                // If the file does not exist, initialize an empty hashMap
                Tasks = new Dictionary<string, Task>();
            }

        }

        public void viewTaskSingle(Task task)
        {
            task.printTask();
        }

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

        public bool dictionaryIsEmpty()
        {
            return !Tasks.Any();
        }

        public Dictionary<string, Task> getTasks()
        {
            return Tasks;
        }



    }
}
