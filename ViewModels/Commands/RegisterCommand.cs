using dwweb_rhino.Models;
using dwweb_rhino.Services;
using dwweb_rhino.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace dwweb_rhino.ViewModels.Commands
{
    internal class RegisterCommand : ICommand
    {
        LoginViewModel Model;

        public RegisterCommand(LoginViewModel model)
        {
            Model = model;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (Model.UserName != null && (parameter as PasswordBox).Password != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            APIService service = new APIService();

            User user = service.RegisterUser(Model.UserName, (parameter as PasswordBox).Password);
            
            if (user == null)
            {
                MessageBox.Show("Error registering, user may already exist.");
                return;
            }

            DwwebRhinoPlugin.Instance.LoggedInUser = user;

            MessageBox.Show("Registration Successful");

            Model.CloseAction();
            UserProfile view = new UserProfile(new TestDataService());     
            view.Show();
        }
    }
}
