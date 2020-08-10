using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Desktop.Win.Data;
using Desktop.Win.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Desktop.Win.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PasswordInfoPageReadOnly : Page
    {
        private PasswordInfoVM passwordInfo;
        public PasswordInfoPageReadOnly()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                using (var context = new ApplicationContext())
                {
                    passwordInfo = new PasswordInfoVM(context.PasswordInfos.FirstOrDefault(c => c.Id == (int)e.Parameter));
                }
            }

            if (passwordInfo != null)
            {
                nameBox.Text = passwordInfo.Name;
                loginBox.Text = passwordInfo.Login;
                passwordBox.Text = passwordInfo.Password;
                oldPasswordBox.Text = passwordInfo.OldPassword;
            }
        }
    }
}
