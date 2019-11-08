using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServicesDemoMVC.Services
{
    public class NoSqlDataManager : IDataManager
    {
        string IDataManager.GetData()
        {
            return "Data manager NOSQL - hello...";
        }

        string IDataManager.GetGreeting(string name)
        {
            return $"Greeting - NOSQL Good morning {name} sir";
        }
    }
}
