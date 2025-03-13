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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Wpf_App.Legacy_Code;

namespace Test_Wpf_App.CustomControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {


        public string MyTitleProperty
        {
            get { return (string)GetValue(MyTitlePropertyProperty); }
            set { SetValue(MyTitlePropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyTitleProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyTitlePropertyProperty =
            DependencyProperty.Register("MyTitleProperty", typeof(string), typeof(UserControl1), new PropertyMetadata(string.Empty));



        public Brush MyColorProperty
        {
            get { return (Brush)GetValue(MyColorPropertyProperty); }
            set { SetValue(MyColorPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyColorProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyColorPropertyProperty =
            DependencyProperty.Register("MyColorProperty", typeof(Brush), typeof(UserControl1), new PropertyMetadata(Brushes.Transparent));



        public MyDelegateCommand MyCommandProperty
        {
            get { return (MyDelegateCommand)GetValue(MyCommandPropertyProperty); }
            set { SetValue(MyCommandPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyCommandProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCommandPropertyProperty =
            DependencyProperty.Register("MyCommandProperty", typeof(MyDelegateCommand), typeof(UserControl1), new PropertyMetadata(null));



        public string MyContent
        {
            get { return (string)GetValue(MyContentProperty); }
            set { SetValue(MyContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyContentProperty =
            DependencyProperty.Register("MyContent", typeof(string), typeof(UserControl), new PropertyMetadata(string.Empty));



        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
