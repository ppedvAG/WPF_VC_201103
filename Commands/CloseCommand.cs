using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Commands
{
    public class CloseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return (parameter as MainWindow).Width < 150;
        }

        public void Execute(object parameter)
        {
            (parameter as MainWindow).Close();
        }
    }
}
