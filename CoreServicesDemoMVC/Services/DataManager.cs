using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServicesDemoMVC.Services
{
    public class DataManager : IDataManager
    {
        string IDataManager.GetData()
        {
            return "Data manager - hello...";
        }

        string IDataManager.GetGreeting(string name)
        {
            return $"Greeting - Good morning {name} sir";
        }
    }
}
