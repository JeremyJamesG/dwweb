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
    internal class PostCommand : ICommand
    {
        UserProfileViewModel Model;

        public PostCommand(UserProfileViewModel model)
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
            if (Model.TestJson != null)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            APIService service = new APIService();

            string response = service.PostProjet(DwwebRhinoPlugin.Instance.LoggedInUser, Model.TestJson);

            //if (!response.Contains("200"))
            //{
            //    MessageBox.Show("Error Posting Project");

            //    return;
            //}

            MessageBox.Show(response);
        }
    }
}
