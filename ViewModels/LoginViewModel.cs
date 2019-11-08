using dwweb_rhino.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dwweb_rhino.ViewModels
{
    public class LoginViewModel
    {
        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        public Action CloseAction { get; set; }

        public LoginViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
            LoginCommand = new LoginCommand(this);
        }

        public string UserName { get; set; }
    }
}
