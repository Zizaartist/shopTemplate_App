using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Click.ViewModels
{
    public class GetDataCommand : ICommand
    {
        private Func<Task> task;
        private Action<bool> dataLockSetter;
        private Func<bool> dataLockGetter;

        public GetDataCommand(Func<Task> _task, Action<bool> _dataLockSetter, Func<bool> _dataLockGetter) 
        {
            task = _task;
            dataLockGetter = _dataLockGetter;
            dataLockSetter = _dataLockSetter;
        }

        public event EventHandler CanExecuteChanged; //useless

        public bool CanExecute(object parameter)
        {
            return !dataLockGetter();
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(null))
            {
                dataLockSetter(true);
                await task();
                dataLockSetter(false);
            }
        }

        public async Task ExecuteAsSubtask() 
        {
            await task();
        }
    }
}
