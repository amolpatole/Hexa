using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreConfigurationSettingMVC.Models
{
    public class AppConfiguration
    {
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
        public ProjectDetails projectDetails { get; set; }
        public string PROCESSOR_ARCHITECHTURE { get; set; }
        public int NUMBER_OF_PROCESSORS { get; set; }
    }

    public class ProjectDetails
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
