using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MVVM_Personendatenbank
{
    public class CustomCommand : ICommand
    {
        public Action<object> ExecuteMethode { get; set; }
        public Func<object, bool> CanExecuteMethode { get; set; }

        public CustomCommand(Func<object, bool> can, Action<object> exe)
        {
            ExecuteMethode = exe;
            CanExecuteMethode = can;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return CanExecuteMethode(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteMethode(parameter);
        }
    }
}
