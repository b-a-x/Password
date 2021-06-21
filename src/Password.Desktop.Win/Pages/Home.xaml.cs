using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Animation;
using Password.Desktop.Win.Data;
using Password.Desktop.Win.Model;
using Password.Desktop.Win.ViewModel;

namespace Password.Desktop.Win.Pages
{
    public sealed partial class Home : Page
    {
        private Guid idPasswordInfo;
        public Home()
        {
            this.InitializeComponent();
            this.Loaded += HomeLoaded;
        }

        private void HomeLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
                HomePageListView.ItemsSource = context.PasswordInfos.Select(x => new PasswordInfoVM(x));
        }

        private void HomeCreateOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PasswordInfoPage));
        }

        private void HomeUpdateOnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PasswordInfoPage), idPasswordInfo, new CommonNavigationTransitionInfo());
        }

        private void HomeDeleteOnClick(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                PasswordInfo password = context.PasswordInfos.Find(idPasswordInfo);
                if (password != null)
                {
                    context.PasswordInfos.Remove(password);
                    context.SaveChanges();
                    HomePageListView.ItemsSource = context.PasswordInfos.Select(x => new PasswordInfoVM(x));
                }
            }
        }

        private void HomePageListView_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (HomePageListView?.SelectedItem is PasswordInfoVM info)
                Frame.Navigate(typeof(PasswordInfoPageReadOnly), info.Id, new CommonNavigationTransitionInfo());
        }

        private void HomePageListView_OnRightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            ListView listView = (ListView)sender;
            allContactsMenuFlyout.ShowAt(listView, e.GetPosition(listView));
            idPasswordInfo = ((PasswordInfoVM)((FrameworkElement)e.OriginalSource).DataContext).Id;
        }
    }
}