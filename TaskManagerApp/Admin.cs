using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp
{
    internal class Admin : DefaultUser
    {
        protected override string ID { get; set; } = "0";
        protected override string Name { get; set; } = "Admin";

        protected override string ReadPermission { get; } = "All";

        protected override string WritePermission { get; } = "No";
    }
}
