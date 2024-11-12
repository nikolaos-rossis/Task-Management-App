using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp
{
    public abstract class DefaultUser
    {

        protected abstract string ID { get; set; }
        protected abstract string Name { get; set; }

        protected abstract string ReadPermission { get; }

        protected abstract string WritePermission { get; }


        protected DefaultUser() { }

    }

    
}
