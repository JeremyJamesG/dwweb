using dwweb_rhino.Models;
using dwweb_rhino.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwweb_rhino.ViewModels
{
    public class UserProfileViewModel
    {
        public Action CloseAction { get; set; }

        public Project CurrentProject { get; set; }

        private IDataService _dataService;

        public UserProfileViewModel(IDataService dataService)
        {
            //Start loading icon

            _dataService = dataService;

            //use user to get all projects 
            CurrentProject = _dataService.GetProjectData();

            //get current project details.

            //stop loading
        }
    }
}
