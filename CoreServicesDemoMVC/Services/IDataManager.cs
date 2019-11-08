using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServicesDemoMVC.Services
{
    public interface IDataManager
    {
        string GetData();
        string GetGreeting(string name);
    }
}
