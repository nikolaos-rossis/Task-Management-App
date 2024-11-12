namespace TaskManagerRESTAPI.Models
{
    public class Task
    {
        public string TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string DueDate { get; set; }

        public Task(string taskID = "0", string title = "", string description = "", string priority = "", string duedate = "")
        {
            TaskID = taskID;
            Title = title;
            Description = description;
            Priority = priority;
            DueDate = duedate;
        }

        public void setTitle(string title)
        {
            Title = title;
        }

        public void setDescription(string description)
        {
            Description = description;
        }

        public void setPriority(string priority)
        {
            Priority = priority;
        }

        public void setDueDate(string duedate)
        {
            DueDate = duedate;
        }

        public void setTaskID(string taskID)
        {
            TaskID = taskID;
        }

        public string getTitle()
        {
            return Title;
        }

        public string getDescription()
        {
            return Description;
        }

        public string getPriority()
        {
            return Priority;
        }

        public string getDueDate()
        {
            return DueDate;
        }

        public string getTaskID()
        {
            return TaskID;
        }

        public void printTask()
        {
            Console.WriteLine($"TaskID: {this.TaskID}\n" +
                    $" Title: {this.Title}\n" +
                    $" Description: {this.Description}\n" +
                    $" Priority: {this.Priority}\n" +
                    $" DueDate: {this.DueDate}\n");

        }
    }
}

