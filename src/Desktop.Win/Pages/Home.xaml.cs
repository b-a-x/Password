using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Desktop.Win.Model;
using Desktop.Win.ViewModel;

namespace Desktop.Win.Pages
{
    public sealed partial class Home : Page
    {
        public Home()
        {
            this.InitializeComponent();
            HomePageListView.ItemsSource = PasswordInfoVM.GetPasswordInfo();
        }
    }
}
