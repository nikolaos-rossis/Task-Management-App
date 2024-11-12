using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManagerApp
{
    public class Task
    {

        [JsonProperty]
        private string TaskID { get; set; }

        [JsonProperty]
        private string Title { get; set; }

        [JsonProperty]
        private string Description { get; set; }

        [JsonProperty]
        private string Priority { get; set; }

        [JsonProperty]   
        private string DueDate { get; set; }

        public Task(string taskID = "0", string title = "", string description = "", string priority = "", string duedate = "")
        {
            TaskID = taskID;
            Title = title;
            Description = description;
            Priority = priority;
            DueDate = duedate;
        }

        public void setTitle(string title) {
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

        public string getTitle() {
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
