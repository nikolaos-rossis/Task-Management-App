using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp
{

    
    public class UserManager : Manager
    {
        public Dictionary<string, User> Users { get; set; }

        string FilePath = @"C:\Users\nickr\source\repos\TaskManagerApp\bin\Debug\net6.0\Users.json";

        private string JsonString { get; set; }

        //private Dictionary<string, Task> Tasks { get; set; }
        public UserManager()
        {
            JsonFileReader();
        }

        public override void JsonFileReader() {

            if (File.Exists(FilePath))
            {
                // Read and deserialize the existing content
                string existingJson = File.ReadAllText(FilePath);
                Users = JsonConvert.DeserializeObject<Dictionary<string, User>>(existingJson) ?? new Dictionary<string, User>();
            }
            else
            {
                // If the file does not exist, initialize an empty hashMap
                Users = new Dictionary<string, User>();
            }
        }

        public override bool dictionaryIsEmpty() {

            return false;
        }

        public void addUser(User user)
        {

            Users.Add(user.getID(), user);
            JsonString = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(FilePath, JsonString);

        }

        public bool userExists(string userID)
        {
            return Users.ContainsKey(userID);
        }

        public User getUser(string userID)
        {
            if (Users.TryGetValue(userID, out User user))
            {
                
                return user;
            }
            else
            {
                Console.WriteLine("Task not found.");
                return null;
            }
        }

        public void setName(string name)
        {
            
        }

        public void setID(string userID) { 
            

        }
    }
}
