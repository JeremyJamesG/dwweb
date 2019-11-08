using dwweb_rhino.Services;
using dwweb_rhino.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dwweb_rhino.Views
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Window
    {
        public UserProfile(IDataService dataService)
        {
            UserProfileViewModel model = new UserProfileViewModel(dataService);
            this.DataContext = model;

            if (model.CloseAction == null)
                model.CloseAction = new Action(this.Close);

            InitializeComponent();
        }
    }
}
