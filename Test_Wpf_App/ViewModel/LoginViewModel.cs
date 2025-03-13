using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_Wpf_App.Legacy_Code;

namespace Test_Wpf_App.ViewModel
{ 
    public class LoginViewModel : MyNotifyPropertyChanged
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
                NotifyPropertyChanged("UserName");
            }
        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private MyDelegateCommand _LoginCommand;
        public MyDelegateCommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            //MessageBox.Show(FetchMacAddress.GetSystemMACID());
                            using (Test_WPF_1Entities TestWpfEnt = new Test_WPF_1Entities())
                            {
                                //var testSP = TestWpfEnt.spGetUserByUseremail("sewaqarahmed@gmail.com");
                                //if (testSP != null)
                                //{
                                    //MessageBox.Show(testSP.ToList().FirstOrDefault().Email);
                                //}
                                string pass = Encryption_Decryption.Encrypt(Password, "/A?D(G+KbPeShVmYq3s6v9y$B&E)H@Mc");
                                if (TestWpfEnt.UserProfiles.FirstOrDefault(x => UserName != null && x.UserName == UserName && Password != null && x.Password == pass && x.UserName.Equals(UserName) && x.Password.Equals(pass)) != null)
                                {
                                    foreach (Window window in Application.Current.Windows)
                                    {
                                        if (window.DataContext == this)
                                        {
                                            MainWindow mainWindow = new MainWindow();
                                            mainWindow.Show();
                                            window.Close();
                                            //return;
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Credentials","Alert!",MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        },
                        canExecute => true);
                }

                return _LoginCommand;
            }
        }
    }
}
