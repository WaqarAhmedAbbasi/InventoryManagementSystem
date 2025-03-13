using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Wpf_App.ViewModel;

namespace Test_Wpf_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel test;
        public MainWindow()
        {
            test = new MainWindowViewModel();
            this.DataContext = test;
            InitializeComponent();

            reportLoad();
            //Loaded += MainWindow_Loaded;
        }

        //private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        //{
        //    test.reportLoad(reportViewer);
        //}
        void reportLoad()
        {
            using (Test_WPF_1Entities test = new Test_WPF_1Entities())
            {
                reportViewer.Reset();
                // Load the RDLC file
                string reportPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MainReport.rdlc");
                reportViewer.LocalReport.ReportPath = reportPath;

                // Prepare the DataTable (this could be any data source such as a database)
                DataTable userDataTable = new DataTable();
                var Columns1 = new DataColumn("UserId", typeof(int));
                Columns1.DefaultValue = 10;
                userDataTable.Columns.Add(Columns1);
                var Columns2 = new DataColumn("UserName", typeof(string));
                Columns2.DefaultValue = "TestUserName";
                userDataTable.Columns.Add(Columns2);

                var Columns3 = new DataColumn("Email", typeof(string));
                Columns3.DefaultValue = "EmailTestDV";
                userDataTable.Columns.Add(Columns3);

                var Columns4 = new DataColumn("Password", typeof(string));
                Columns4.DefaultValue = 10;
                userDataTable.Columns.Add(Columns4);

                foreach (var test1 in test.UserProfiles)
                {
                    userDataTable.Rows.Add(test1.UserId, test1.UserName, test1.Email, test1.Password);
                }

                // Set up the Report DataSource (it should match the RDLC dataset name)
                var reportDataSource = new ReportDataSource("User_DS", userDataTable);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(reportDataSource);

                reportViewer.Refresh();
                reportViewer.RefreshReport();
            }
        }
    }
}
