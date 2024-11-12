using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManagerApp
{
    public class User : DefaultUser
    {

        [JsonProperty]
        protected override string ID { get; set; }
        [JsonProperty]
        protected override string Name { get; set; }
        [JsonProperty]
        protected override string ReadPermission { get; } = "self";
        [JsonProperty]
        protected override string WritePermission { get; } = "self";

        public User(string name, string id)
        {
            Name = name;
            ID = id;
        }

        public string getName()
        {
            return Name;
        }

        public string getID()
        {
            return ID;
        }

        public string getReadPermission()
        {
            return ReadPermission;
        }

        public string getWritePermission()
        {
            return WritePermission;
        }



    }
}
