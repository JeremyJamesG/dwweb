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
using System.Windows.Navigation;

namespace dwweb_rhino.ViewModels.Commands
{
    internal class LoginCommand : ICommand
    {
        LoginViewModel Model;

        public LoginCommand(LoginViewModel model)
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
            User user = service.AuthenticateUser(Model.UserName, (parameter as PasswordBox).Password);

            if (user == null)
            {
                MessageBox.Show("Invalid Username or Password");

                return;
            }

            DwwebRhinoPlugin.Instance.LoggedInUser = user;

            MessageBox.Show("Login Successful!");

            UserProfile view = new UserProfile(new TestDataService());
            Model.CloseAction();
            view.Show();
        }
    }
}
