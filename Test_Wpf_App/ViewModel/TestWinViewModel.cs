using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_Wpf_App.Legacy_Code;
using Test_Wpf_App.View;

namespace Test_Wpf_App.ViewModel
{
    public class TestWinViewModel : MyNotifyPropertyChanged
    {
        private MyDelegateCommand _MyCancelCommand;
        public MyDelegateCommand MyCancelCommand
        {
            get
            {
                if (_MyCancelCommand == null)
                {
                    _MyCancelCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            foreach (Window window in Application.Current.Windows)
                            {
                                if (window.DataContext == this)
                                {
                                    window.Close();
                                    //return;
                                }
                            }
                            //MessageBox.Show("Test");
                            //App.Current.Windows[0].Close();
                        },
                        canExecute => true);
                }

                return _MyCancelCommand;
            }
        }
    }
}
