using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Desktop.Win.Data;
using Desktop.Win.Model;
using Desktop.Win.ViewModel;

namespace Desktop.Win.Pages
{
    public sealed partial class PasswordInfoPage : Page
    {
        private PasswordInfoVM passwordInfo;
        public PasswordInfoPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                int id = (int)e.Parameter;
                using (ApplicationContext context = new ApplicationContext())
                {
                    passwordInfo = new PasswordInfoVM(context.PasswordInfos.FirstOrDefault(c => c.Id == id));
                }
            }

            if (passwordInfo != null)
            {
                headerBlock.Text = "Редактирование информации о пароле";
                nameBox.Text = passwordInfo.Name;
                loginBox.Text = passwordInfo.Login;
                passwordBox.Text = passwordInfo.Password;
            }
        }

        private void SaveOnClick(object sender, RoutedEventArgs e)
        {
            using (var context = new ApplicationContext())
            {
                if (passwordInfo != null)
                {
                    passwordInfo.Name = nameBox.Text;
                    passwordInfo.Login = loginBox.Text;
                    passwordInfo.Password = passwordBox.Text;
                    context.PasswordInfos.Update(passwordInfo.PasswordInfo);
                }
                else
                {
                    context.PasswordInfos.Add(new PasswordInfo
                    {
                        Name = nameBox.Text,
                        Login = loginBox.Text,
                        Password = passwordBox.Text
                    });
                }

                context.SaveChanges();
            }
            GoToMainPage();
        }

        private void CancelOnClick(object sender, RoutedEventArgs e)
        {
            GoToMainPage();
        }

        private void GoToMainPage()
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
            else
                Frame.Navigate(typeof(MainPage));
        }
    }
}
