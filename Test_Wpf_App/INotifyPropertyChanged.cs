using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Wpf_App.Legacy_Code
{

    //
    // Summary:
    //     Represents the method that will handle the System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    //     event raised when a property is changed on a component.
    //
    // Parameters:
    //   sender:
    //     The source of the event.
    //
    //   e:
    //     A System.ComponentModel.PropertyChangedEventArgs that contains the event data.
    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);

    //
    // Summary:
    //     Notifies clients that a property value has changed.
    public interface INotifyPropertyChanged
    {
        //
        // Summary:
        //     Occurs when a property value changes.
        event PropertyChangedEventHandler PropertyChanged;
    }
}
