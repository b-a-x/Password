using Desktop.Win.Commands;

namespace Desktop.Win.ViewModel
{
    public class MainPageVM : BaseVM
    {
        private DelegateCommand showMessageCommand;
        private string name;
        private bool messageReady;

        public MainPageVM()
        {
            ShowMessageCommand = new DelegateCommand(ExecuteShowMessage, CanExecuteShowMessage);
        }

        internal DelegateCommand ShowMessageCommand
        {
            get => showMessageCommand;
            set => SetProperty(ref showMessageCommand, value);
        }

        public string Name
        {
            get => name;
            set
            {
                SetProperty(ref name, value);
                showMessageCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool MessageReady
        {
            get => messageReady;
            set => SetProperty(ref messageReady, value);
        }

        private void ExecuteShowMessage(object obj)
        {
            MessageReady = true;
        }

        private bool CanExecuteShowMessage(object obj)
        {
            return string.IsNullOrWhiteSpace(Name) == false;
        }
    }
}
