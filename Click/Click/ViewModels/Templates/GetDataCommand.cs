using AsyncVoid;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Click.ViewModels
{
    public class GetDataCommand : ICommand
    {
        readonly Func<bool> _canExecute;
        readonly Action<bool> _setter;
        readonly Func<Task> _execute;
        bool _isWorking;

        public GetDataCommand(Func<Task> execute, Func<bool> canExecute, Action<bool> setter)
        {
            _execute = execute;
            _setter = setter;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute() || _isWorking;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            if (CanExecute(null))
            {
                _isWorking = true;
                _setter(true);
                await _execute();
                _isWorking = false;
                _setter(false);
            }
        }

        public async Task ExecuteAsSubTask() 
        {
            await _execute();
        }
    }
}
