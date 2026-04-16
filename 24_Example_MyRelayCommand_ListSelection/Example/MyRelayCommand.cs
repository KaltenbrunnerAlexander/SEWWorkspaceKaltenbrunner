using System.Windows.Input;

namespace Example
{
    class MyRelayCommand : ICommand
    {
        private Action _action;
        public MyRelayCommand(Action action)
        {
            this._action = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action();
        }
    }
}
