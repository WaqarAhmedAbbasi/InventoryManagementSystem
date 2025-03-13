using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Wpf_App.Legacy_Code
{
    //
    // Summary:
    //     Defines the contract for commanding.
    public interface ICommand
    {
        //
        // Summary:
        //     Occurs when changes occur that affect whether the command should execute.
        event EventHandler CanExecuteChanged;

        //
        // Summary:
        //     Defines the method that determines whether the command can execute in its current
        //     state.
        //
        // Parameters:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        //
        // Returns:
        //     true if this command can be executed; otherwise, false.
        bool CanExecute(object parameter);
        //
        // Summary:
        //     Defines the method to be called when the command is invoked.
        //
        // Parameters:
        //   parameter:
        //     Data used by the command. If the command does not require data to be passed,
        //     this object can be set to null.
        void Execute(object parameter);
    }
}
