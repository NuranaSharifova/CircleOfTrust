using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp6
{
    class MyCommands:ICommand
    {
        private Action<object> exec;
        Func<bool> canExec;
        public MyCommands(Action<object> exec)
        {
            this.exec = exec;
            this.canExec = () => true;
        }
        public MyCommands(Action<object> exec, Func<bool> canExec)
        {
            this.exec = exec;
            this.canExec = canExec;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExec();
        }

        public void Execute(object parameter)
        {
            this.exec(parameter);
        }
    }
}
