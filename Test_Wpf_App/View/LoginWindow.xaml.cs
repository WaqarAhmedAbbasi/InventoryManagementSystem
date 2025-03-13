using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Test_Wpf_App.ViewModel;

namespace Test_Wpf_App.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            //Show splash screen
            SplashScreen splashScreen = new SplashScreen("../SplashScreen/Splash_Screen.png");
            splashScreen.Show(false, false);
            
            this.DataContext = new LoginViewModel();
            InitializeComponent();
            //Closing the Splashscreen with fadding effect
            //splashScreen.Close(TimeSpan.FromSeconds(1));
        }
    }
}
