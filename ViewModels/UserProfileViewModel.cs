using dwweb_rhino.Models;
using dwweb_rhino.Services;
using dwweb_rhino.ViewModels.Commands;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dwweb_rhino.ViewModels
{
    public class UserProfileViewModel
    {
        public Action CloseAction { get; set; }

        public ICommand PostCommand { get; set; }

        public Project CurrentProject { get; set; }

        public string TestJson { get; set; }

        private IDataService _dataService;

        public UserProfileViewModel(IDataService dataService)
        {
            PostCommand = new PostCommand(this);

            _dataService = dataService;

            //use user to get all projects 
            CurrentProject = _dataService.GetProjectData();

            //get current project details.
            string json = JsonConvert.SerializeObject(CurrentProject);

            TestJson = JValue.Parse(json).ToString(Formatting.Indented);

            //stop loading
        }
    }
}
