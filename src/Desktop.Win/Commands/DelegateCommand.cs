using System;
using System.Windows.Input;

namespace Desktop.Win.Commands
{
    internal class DelegateCommand : ICommand
    {
        private readonly Predicate<object> canExecute;
        private readonly Action<object> execute;

        internal DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        internal DelegateCommand(Action<object> execute) : this(execute, null) { }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            if(canExecute(parameter) == false)
                return;

            execute(parameter);
        }

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this,EventArgs.Empty);
        }
    }
}
