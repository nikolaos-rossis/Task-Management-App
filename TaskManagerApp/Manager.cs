using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp
{
    public abstract class Manager
    {


        public Manager() { }

        public abstract void JsonFileReader();

        public abstract bool dictionaryIsEmpty();
    }
}
