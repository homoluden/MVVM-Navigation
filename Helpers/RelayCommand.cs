using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Helpers
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _execute = null;
        private readonly Predicate<object> _canExecute = null;

        #endregion


        #region Constructors

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }
        
        public RelayCommand(Action<T> execute, Predicate<object> canExecute)
        {
            if (execute == null)
	        {
                throw new ArgumentNullException("execute");
	        }

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion


        #region ICommand Implementation
        
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (parameter is T)
            {
                var typedParameter = (T)parameter;
                _execute(typedParameter);
            }            
        }

        #endregion
    }
}
