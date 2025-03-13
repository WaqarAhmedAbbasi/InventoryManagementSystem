using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_Wpf_App.Legacy_Code
{
    public class MyDelegateCommand : ICommand
    {
        public MyDelegateCommand(Action<object> executeMethod)
            : this(executeMethod, null)
        {
        }

        public MyDelegateCommand(Action<object> executeMethod, Predicate<object> canExecute)
        {
            if (executeMethod == null)
                throw new ArgumentNullException("executeMethod");

            this.executeMethod = executeMethod;
            this.canExecute = canExecute;
        }

        #region fields
        private readonly Predicate<object> canExecute;
        private readonly Action<object> executeMethod;
        #endregion

        /// <summary>
        /// Allows user to provide custom data.
        /// </summary>
        //public Object UserState { get; set; }

        /// <summary>
        /// User invokes this method when the state of CanExecute changes to notify
        /// control binding to this command to update its state.
        /// </summary>
        /// <param name="command"></param>
        static public void RaiseCanExecuteChanged(ICommand command)
        {
            if (command is MyDelegateCommand)
            {
                ((MyDelegateCommand)command).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// User invokes this method when the state of CanExecute changes to notify
        /// control binding to this command to update its state.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        ///////////////////////////////////////////////////////////////////////
        // Implemented ICommand CanExecuteChanged property
        ///////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Hooked by command responding to this command.
        /// </summary>
        public event EventHandler CanExecuteChanged;


        ///////////////////////////////////////////////////////////////////////
        // Implemented ICommand Methods
        ///////////////////////////////////////////////////////////////////////

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }

    }
}
