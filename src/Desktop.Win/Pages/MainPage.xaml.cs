using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Desktop.Win.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private NavigationViewItemBase oldItem;
        
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(GetPageType(nameof(Home)), null);
        }

        private void NavigationViewOnItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItemBase item = args.InvokedItemContainer;
            if (oldItem == item)
                return;

            FrameNavigationOptions navOptions = new FrameNavigationOptions
            {
                TransitionInfoOverride = args.RecommendedNavigationTransitionInfo
            };
            
            if (sender.PaneDisplayMode == NavigationViewPaneDisplayMode.Top)
            {
                navOptions.IsNavigationStackEnabled = false;
            }

            ContentFrame.NavigateToType(GetPageType(item.Name), null, navOptions);
            oldItem = item;
        }

        private Type GetPageType(string pageName)
        {
            switch (pageName)
            {
                case nameof(Home):
                    return typeof(Home);
                case nameof(SettingsNavPaneItem):
                    return typeof(SettingsNavPaneItem);
                default:
                    return null;
            }
        }

        private void NavigationViewOnBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
                ContentFrame.GoBack();
        }
    }
}