using Azure.Core.GeoJson;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IdentityModel.Metadata;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms.Integration;
using Test_Wpf_App.Legacy_Code;
using Test_Wpf_App.View;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Test_Wpf_App.ViewModel
{
    public class MainWindowViewModel : MyNotifyPropertyChanged
    {
        public ObservableCollection<UserProfile> Users { get; set; }

        public void reportLoad(ReportViewer reportViewer)
        {
            using (Test_WPF_1Entities test = new Test_WPF_1Entities())
            {

                if (reportViewer == null)
                {
                    reportViewer = new ReportViewer();
                    
                }
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

                //reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.Refresh();
                // Refresh the report
                reportViewer.RefreshReport();
            }
        }
        public MainWindowViewModel()
        {

            //_window = mainWin; 
            //this.reportViewer = _window.reportViewer;
            TestWpfEnt = new Test_WPF_1Entities();
            ListOfUser = new ObservableCollection<Customer>(TestWpfEnt.Customers);
            ListOfDist = new ObservableCollection<Distribution>(TestWpfEnt.Distributions);
            ListOfSO = new ObservableCollection<SalesInfo>(TestWpfEnt.SalesInfoes);

            _SelectedItem = new Customer();
            _SelectedDistItem = new Distribution();
            _SelectedSOItem = new SalesInfo();
            //reportLoad();
        }
        //private MainWindow _window;
        //private ReportViewer reportViewer;
        private Test_WPF_1Entities TestWpfEnt;

        private ObservableCollection<Customer> listOfUser;
        public ObservableCollection<Customer> ListOfUser
        {
            get
            {
                return listOfUser;
            }
            set
            {
                if (listOfUser != value)
                {
                    listOfUser = value;
                    NotifyPropertyChanged(nameof(ListOfUser));
                    NotifyPropertyChanged(nameof(SelectedItem));
                    AddCustCommand.RaiseCanExecuteChanged();
                    EditCustCommand.RaiseCanExecuteChanged();
                    DeleteCustCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private ObservableCollection<Distribution> listOfDist;
        public ObservableCollection<Distribution> ListOfDist
        {
            get
            {
                return listOfDist;
            }
            set
            {
                if (listOfDist != value)
                {
                    listOfDist = value;
                    NotifyPropertyChanged(nameof(ListOfDist));
                    NotifyPropertyChanged(nameof(SelectedDistItem));
                    AddDistCommand.RaiseCanExecuteChanged();
                    EditDistCommand.RaiseCanExecuteChanged();
                    DeleteDistCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private ObservableCollection<SalesInfo> listOfSO;
        public ObservableCollection<SalesInfo> ListOfSO
        {
            get
            {
                return listOfSO;
            }
            set
            {
                if (listOfSO != value)
                {
                    listOfSO = value;
                    NotifyPropertyChanged(nameof(ListOfSO));
                    NotifyPropertyChanged(nameof(SelectedSOItem));
                    AddSOCommand.RaiseCanExecuteChanged();
                    EditSOCommand.RaiseCanExecuteChanged();
                    DeleteSOCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _CustomerName;
        public string CustomerName
        {
            get => _CustomerName;
            set
            {
                _CustomerName = value;
                NotifyPropertyChanged(nameof(CustomerName));
            }
        }
        private string _CustomerCNIC;
        public string CustomerCNIC
        {
            get => _CustomerCNIC;
            set
            {
                _CustomerCNIC = value;
                NotifyPropertyChanged(nameof(CustomerCNIC));
            }
        }
        
        private string _CustomerContactNumber;
        public string CustomerContactNumber
        {
            get => _CustomerContactNumber;
            set
            {
                _CustomerContactNumber = value;
                NotifyPropertyChanged(nameof(CustomerContactNumber));
            }
        }

        private string _CustomerNTN;
        public string CustomerNTN
        {
            get => _CustomerNTN;
            set
            {
                _CustomerNTN = value;
                NotifyPropertyChanged(nameof(CustomerNTN));
            }
        }

        private string _CustomerSTRN;
        public string CustomerSTRN
        {
            get => _CustomerSTRN;
            set
            {
                _CustomerSTRN = value;
                NotifyPropertyChanged(nameof(CustomerSTRN));
            }
        }
        
        private string _OutletName;
        public string OutletName
        {
            get => _OutletName;
            set
            {
                _OutletName = value;
                NotifyPropertyChanged(nameof(OutletName));
            }
        }

        private string _OutletNumber;
        public string OutletNumber
        {
            get => _OutletNumber;
            set
            {
                _OutletNumber = value;
                NotifyPropertyChanged(nameof(OutletNumber));
            }
        }

        private string _CustomerAddress;
        public string CustomerAddress
        {
            get => _CustomerAddress;
            set
            {
                _CustomerAddress = value;
                NotifyPropertyChanged(nameof(CustomerAddress));
            }
        }
        private Customer _SelectedItem;
        public Customer SelectedItem
        {

            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.CustomerName))
                {
                    CustomerName = _SelectedItem.CustomerName;
                }
                else
                {
                    CustomerName = string.Empty;
                }
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.CustomerCNIC))
                {
                    CustomerCNIC = _SelectedItem.CustomerCNIC;
                }
                else
                {
                    CustomerCNIC = string.Empty;
                }
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.CustomerAddress))
                {
                    CustomerAddress = _SelectedItem.CustomerAddress;
                }
                else
                {
                    CustomerAddress = string.Empty;
                }
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.CustomerContactNumber))
                {
                    CustomerContactNumber = _SelectedItem.CustomerContactNumber;
                }
                else
                {
                    CustomerContactNumber = string.Empty;
                }
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.CustomerNTN))
                {
                    CustomerNTN = _SelectedItem.CustomerNTN;
                }
                else
                {
                    CustomerNTN = string.Empty;
                }
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.CustomerSTRN))
                {
                    CustomerSTRN = _SelectedItem.CustomerSTRN;
                }
                else
                {
                    CustomerSTRN = string.Empty;
                }
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.OutletName))
                {
                    OutletName = _SelectedItem.OutletName;
                }
                else
                {
                    OutletName = string.Empty;
                }
                if (_SelectedItem != null && !string.IsNullOrWhiteSpace(_SelectedItem.OutletNumber))
                {
                    OutletNumber = _SelectedItem.OutletNumber;
                }
                else
                {
                    OutletNumber = string.Empty;
                }
                NotifyPropertyChanged(nameof(CustomerName));
                NotifyPropertyChanged(nameof(CustomerCNIC));
                NotifyPropertyChanged(nameof(CustomerAddress));
                NotifyPropertyChanged(nameof(CustomerContactNumber));
                NotifyPropertyChanged(nameof(CustomerNTN));
                NotifyPropertyChanged(nameof(CustomerSTRN));
                NotifyPropertyChanged(nameof(OutletName));
                NotifyPropertyChanged(nameof(OutletNumber));
                NotifyPropertyChanged(nameof(SelectedItem));
                NotifyPropertyChanged(nameof(ListOfUser));
                AddCustCommand.RaiseCanExecuteChanged();
                EditCustCommand.RaiseCanExecuteChanged();
            }
        }


        private string _DistibutionName;
        public string DistibutionName
        {
            get => _DistibutionName;
            set
            {
                _DistibutionName = value;
                NotifyPropertyChanged(nameof(DistibutionName));
            }
        }

        private string _DistibutionAddress;
        public string DistibutionAddress
        {
            get => _DistibutionAddress;
            set
            {
                _DistibutionAddress = value;
                NotifyPropertyChanged(nameof(DistibutionAddress));
            }
        }

        private string _DistibutionNTN;
        public string DistibutionNTN
        {
            get => _DistibutionNTN;
            set
            {
                _DistibutionNTN = value;
                NotifyPropertyChanged(nameof(DistibutionNTN));
            }
        }
        
        private string _DistibutionSTRN;
        public string DistibutionSTRN
        {
            get => _DistibutionSTRN;
            set
            {
                _DistibutionSTRN = value;
                NotifyPropertyChanged(nameof(DistibutionSTRN));
            }
        }
        private Distribution _SelectedDistItem;
        public Distribution SelectedDistItem
        {

            get { return _SelectedDistItem; }
            set
            {

                _SelectedDistItem = value;

                if (_SelectedDistItem != null && !string.IsNullOrWhiteSpace(_SelectedDistItem.DistibutionName))
                {
                    DistibutionName = _SelectedDistItem.DistibutionName;
                }
                else
                {
                    DistibutionName = string.Empty;
                }
                if (_SelectedDistItem != null && !string.IsNullOrWhiteSpace(_SelectedDistItem.DistibutionAddress))
                {
                    DistibutionAddress = _SelectedDistItem.DistibutionAddress;
                }
                else
                {
                    DistibutionAddress = string.Empty;
                }
                if (_SelectedDistItem != null && !string.IsNullOrWhiteSpace(_SelectedDistItem.DistibutionNTN))
                {
                    DistibutionNTN = _SelectedDistItem.DistibutionNTN;
                }
                else
                {
                    DistibutionNTN = string.Empty;
                }
                if (_SelectedDistItem != null && !string.IsNullOrWhiteSpace(_SelectedDistItem.DistibutionSTRN))
                {
                    DistibutionSTRN = _SelectedDistItem.DistibutionSTRN;
                }
                else
                {
                    DistibutionSTRN = string.Empty;
                }
                NotifyPropertyChanged(nameof(DistibutionName));
                NotifyPropertyChanged(nameof(DistibutionAddress));
                NotifyPropertyChanged(nameof(DistibutionNTN));
                NotifyPropertyChanged(nameof(DistibutionSTRN));
                NotifyPropertyChanged(nameof(SelectedDistItem));
                NotifyPropertyChanged(nameof(ListOfDist));
                AddDistCommand.RaiseCanExecuteChanged();
                EditDistCommand.RaiseCanExecuteChanged();
                DeleteDistCommand.RaiseCanExecuteChanged();
            }
        }

        private string _SaleOfficerName;
        public string SaleOfficerName
        {
            get => _SaleOfficerName;
            set
            {
                _SaleOfficerName = value;
                NotifyPropertyChanged(nameof(SaleOfficerName));
            }
        }

        private string _DeliveryManName;
        public string DeliveryManName
        {
            get => _DeliveryManName;
            set
            {
                _DeliveryManName = value;
                NotifyPropertyChanged(nameof(DeliveryManName));
            }
        }

        private SalesInfo _SelectedSOItem;
        public SalesInfo SelectedSOItem
        {

            get { return _SelectedSOItem; }
            set
            {
                _SelectedSOItem = value;
                if (SelectedSOItem != null && !string.IsNullOrWhiteSpace(SelectedSOItem.SalesOfficerName))
                {
                    SaleOfficerName = SelectedSOItem.SalesOfficerName;
                }
                else
                {
                    SaleOfficerName = string.Empty;
                }
                if (SelectedSOItem != null && !string.IsNullOrWhiteSpace(SelectedSOItem.DeliveryManName))
                {
                    DeliveryManName = SelectedSOItem.DeliveryManName;
                }
                else
                {
                    DeliveryManName = string.Empty;
                }

                NotifyPropertyChanged(nameof(SaleOfficerName));
                NotifyPropertyChanged(nameof(DeliveryManName));
                NotifyPropertyChanged(nameof(SelectedSOItem));
                NotifyPropertyChanged(nameof(ListOfSO));
                AddSOCommand.RaiseCanExecuteChanged();
                EditSOCommand.RaiseCanExecuteChanged();
                DeleteSOCommand.RaiseCanExecuteChanged();
            }
        }

        private MyDelegateCommand _LogOutCommand;
        public MyDelegateCommand LogOutCommand
        {
            get
            {
                if (_LogOutCommand == null)
                {
                    _LogOutCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                            {
                                if (window.DataContext == this)
                                {
                                    window.Close();
                                    return;
                                }
                            }
                        },
                        canExecute => true);
                }
                return _LogOutCommand;
            }
        }

        private MyDelegateCommand _AddCustCommand;
        public MyDelegateCommand AddCustCommand
        {
            get
            {
                if (_AddCustCommand == null)
                {
                    _AddCustCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            if (!string.IsNullOrWhiteSpace(OutletNumber) && !string.IsNullOrWhiteSpace(OutletName) && !string.IsNullOrWhiteSpace(CustomerName) && !string.IsNullOrWhiteSpace(CustomerAddress) && !string.IsNullOrWhiteSpace(CustomerCNIC) && !string.IsNullOrWhiteSpace(CustomerContactNumber) && !string.IsNullOrWhiteSpace(CustomerNTN) && !string.IsNullOrWhiteSpace(CustomerSTRN))
                            {
                                using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                {
                                    //Items.Add(new MyItem { Name = this.Name, Description = this.Description });

                                    Customer customer = new Customer { CustomerName = CustomerName, CustomerAddress = CustomerAddress, CustomerCNIC = CustomerCNIC, CustomerNTN = CustomerNTN , CustomerSTRN = CustomerSTRN , CustomerContactNumber=CustomerContactNumber, OutletName=OutletName,OutletNumber=OutletNumber};
                                    test.Customers.Add(customer);
                                    ListOfUser.Add(customer);
                                    //SelectedDistItem = null;
                                    CustomerName = string.Empty;
                                    CustomerAddress = string.Empty;
                                    CustomerCNIC = string.Empty;
                                    CustomerContactNumber = string.Empty;
                                    CustomerNTN = string.Empty;
                                    CustomerSTRN = string.Empty;
                                    OutletName = string.Empty;
                                    OutletNumber = string.Empty;
                                    
                                    NotifyPropertyChanged(nameof(CustomerName));
                                    NotifyPropertyChanged(nameof(CustomerAddress));
                                    NotifyPropertyChanged(nameof(CustomerContactNumber));
                                    NotifyPropertyChanged(nameof(CustomerCNIC));
                                    NotifyPropertyChanged(nameof(CustomerNTN));
                                    NotifyPropertyChanged(nameof(CustomerSTRN));
                                    NotifyPropertyChanged(nameof(OutletName));
                                    NotifyPropertyChanged(nameof(OutletNumber));
                                    NotifyPropertyChanged(nameof(SelectedItem));
                                    NotifyPropertyChanged(nameof(ListOfUser));
                                    test.SaveChanges();
                                }
                            }
                        },
                        canExecute => true);
                }
                return _AddCustCommand;
            }
        }

        private MyDelegateCommand _AddDistCommand;
        public MyDelegateCommand AddDistCommand
        {
            get
            {
                if (_AddDistCommand == null)
                {
                    _AddDistCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            if (!string.IsNullOrWhiteSpace(DistibutionName) && !string.IsNullOrWhiteSpace(DistibutionAddress) && !string.IsNullOrWhiteSpace(DistibutionNTN) && !string.IsNullOrWhiteSpace(DistibutionSTRN))
                            {
                                using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                {
                                    //Items.Add(new MyItem { Name = this.Name, Description = this.Description });

                                    Distribution distribution = new Distribution { DistibutionName= DistibutionName , DistibutionAddress= DistibutionAddress , DistibutionNTN= DistibutionNTN ,DistibutionSTRN= DistibutionSTRN };
                                    test.Distributions.Add(distribution);
                                    ListOfDist.Add(distribution);
                                    //SelectedDistItem = null;
                                    DistibutionName= string.Empty;
                                    DistibutionAddress= string.Empty;
                                    DistibutionNTN= string.Empty;
                                    DistibutionSTRN= string.Empty;
                                    NotifyPropertyChanged(nameof(DistibutionName));
                                    NotifyPropertyChanged(nameof(DistibutionAddress));
                                    NotifyPropertyChanged(nameof(DistibutionNTN));
                                    NotifyPropertyChanged(nameof(DistibutionSTRN));
                                    NotifyPropertyChanged(nameof(SelectedDistItem));
                                    NotifyPropertyChanged(nameof(ListOfDist));
                                    test.SaveChanges();
                                }
                            }
                        },
                        canExecute => true);
                }
                return _AddDistCommand;
            }
        }

        private MyDelegateCommand _AddSOCommand;
        public MyDelegateCommand AddSOCommand
        {
            get
            {
                if (_AddSOCommand == null)
                {
                    _AddSOCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            if (!string.IsNullOrWhiteSpace(SaleOfficerName) &&  !string.IsNullOrWhiteSpace(DeliveryManName))
                            {
                                using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                {
                                    //Items.Add(new MyItem { Name = this.Name, Description = this.Description });

                                    SalesInfo SaleInfo = new SalesInfo { SalesOfficerName= SaleOfficerName, DeliveryManName= DeliveryManName };
                                    test.SalesInfoes.Add(SaleInfo);
                                    ListOfSO.Add(SaleInfo);
                                    SaleOfficerName=string.Empty;
                                    DeliveryManName=string.Empty;
                                    NotifyPropertyChanged(nameof(SaleOfficerName));
                                    NotifyPropertyChanged(nameof(DeliveryManName));
                                    //SelectedSOItem = null;
                                    NotifyPropertyChanged(nameof(SelectedSOItem));
                                    NotifyPropertyChanged(nameof(ListOfSO));
                                    test.SaveChanges();
                                }
                            }
                        },
                        canExecute => true);
                }
                return _AddSOCommand;
            }
        }

        private MyDelegateCommand _EditCustCommand;
        public MyDelegateCommand EditCustCommand
        {
            get
            {
                if (_EditCustCommand == null)
                {
                    _EditCustCommand = new MyDelegateCommand(
                        actionObject =>
                        {

                            if (SelectedItem != null)
                            {
                                using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                {
                                    var customer = test.Customers.Where(s => s.CustomerId == SelectedItem.CustomerId).FirstOrDefault();

                                    if (customer != null)
                                    {
                                        SelectedItem.CustomerName = CustomerName;
                                        SelectedItem.CustomerCNIC = CustomerCNIC;
                                        SelectedItem.CustomerContactNumber = CustomerContactNumber;
                                        SelectedItem.CustomerNTN = CustomerNTN;
                                        SelectedItem.CustomerSTRN = CustomerSTRN;
                                        SelectedItem.OutletName = OutletName;
                                        SelectedItem.OutletNumber = OutletNumber;
                                        SelectedItem.CustomerAddress = CustomerAddress;

                                        test.Entry(SelectedItem).State = EntityState.Detached;
                                        test.Entry(customer).State = EntityState.Modified;


                                        var found = ListOfUser.FirstOrDefault(x => x.CustomerId == SelectedItem.CustomerId);
                                        int i = ListOfUser.IndexOf(found);
                                        ListOfUser[i].CustomerName = SelectedItem.CustomerName;
                                        ListOfUser[i].CustomerCNIC = SelectedItem.CustomerCNIC;
                                        ListOfUser[i].CustomerAddress = SelectedItem.CustomerAddress;
                                        ListOfUser[i].CustomerContactNumber = SelectedItem.CustomerContactNumber;
                                        ListOfUser[i].CustomerNTN = SelectedItem.CustomerNTN;
                                        ListOfUser[i].CustomerSTRN = SelectedItem.CustomerSTRN;
                                        ListOfUser[i].OutletName = SelectedItem.OutletName;
                                        ListOfUser[i].OutletNumber = SelectedItem.OutletNumber;
                                        CollectionViewSource.GetDefaultView(ListOfUser).Refresh();

                                        NotifyPropertyChanged(nameof(SelectedItem));
                                        NotifyPropertyChanged(nameof(ListOfUser));

                                        test.SaveChanges();
                                    }
                                }
                            }
                        },
                        canExecute => true);
                }
                return _EditCustCommand;
            }
        }

        private MyDelegateCommand _EditDistCommand;
        public MyDelegateCommand EditDistCommand
        {
            get
            {
                if (_EditDistCommand == null)
                {
                    _EditDistCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            if (SelectedDistItem != null)
                            {
                                using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                {
                                    var distribution = test.Distributions.Where(s => s.DistibutionId == SelectedDistItem.DistibutionId).FirstOrDefault();

                                    if (distribution != null)
                                    {
                                        SelectedDistItem.DistibutionName = DistibutionName;
                                        SelectedDistItem.DistibutionAddress = DistibutionAddress;
                                        SelectedDistItem.DistibutionNTN = DistibutionNTN;
                                        SelectedDistItem.DistibutionSTRN = DistibutionSTRN;

                                        test.Entry(SelectedDistItem).State = EntityState.Detached;
                                        test.Entry(distribution).State = EntityState.Modified;
                                        //SelectedSOItem = null;

                                        var found = ListOfDist.FirstOrDefault(x => x.DistibutionId == SelectedDistItem.DistibutionId);
                                        int i = ListOfDist.IndexOf(found);
                                        ListOfDist[i].DistibutionName = SelectedDistItem.DistibutionName;
                                        ListOfDist[i].DistibutionAddress = SelectedDistItem.DistibutionAddress;
                                        ListOfDist[i].DistibutionNTN = SelectedDistItem.DistibutionNTN;
                                        ListOfDist[i].DistibutionSTRN = SelectedDistItem.DistibutionSTRN;
                                        CollectionViewSource.GetDefaultView(ListOfDist).Refresh();

                                        NotifyPropertyChanged(nameof(SelectedDistItem));
                                        NotifyPropertyChanged(nameof(ListOfDist));

                                        test.SaveChanges();
                                    }
                                }
                            }
                        },
                        canExecute => true);
                }
                return _EditDistCommand;
            }
        }

        private MyDelegateCommand _EditSOCommand;
        public MyDelegateCommand EditSOCommand
        {
            get
            {
                if (_EditSOCommand == null)
                {
                    _EditSOCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            if (SelectedSOItem != null)
                            {
                                using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                {
                                    var saleInfo = test.SalesInfoes.Where(s => s.SalesOfficerId == SelectedSOItem.SalesOfficerId).FirstOrDefault();

                                    if (saleInfo != null)
                                    {
                                        SelectedSOItem.SalesOfficerName=SaleOfficerName;
                                        SelectedSOItem.DeliveryManName=DeliveryManName;

                                        saleInfo.SalesOfficerName = SelectedSOItem.SalesOfficerName;
                                        saleInfo.DeliveryManName = SelectedSOItem.DeliveryManName;

                                        test.Entry(SelectedSOItem).State = EntityState.Detached;
                                        test.Entry(saleInfo).State = EntityState.Modified;
                                        //SelectedSOItem = null;

                                        var found = ListOfSO.FirstOrDefault(x => x.SalesOfficerId == SelectedSOItem.SalesOfficerId);
                                        int i = ListOfSO.IndexOf(found);
                                        ListOfSO[i].SalesOfficerName = SelectedSOItem.SalesOfficerName;
                                        ListOfSO[i].DeliveryManName = SelectedSOItem.DeliveryManName;
                                        CollectionViewSource.GetDefaultView(ListOfSO).Refresh();

                                        NotifyPropertyChanged(nameof(SelectedSOItem));
                                        NotifyPropertyChanged(nameof(ListOfSO));
                                        
                                        test.SaveChanges();
                                    }
                                }
                            }
                        },
                        canExecute => true);
                }
                return _EditSOCommand;
            }
        }

        private MyDelegateCommand _DeleteCustCommand;
        public MyDelegateCommand DeleteCustCommand
        {
            get
            {
                if (_DeleteCustCommand == null)
                {
                    _DeleteCustCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            if (SelectedItem != null && SelectedItem.CustomerName != null)
                            {
                                try
                                {
                                    using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                    {
                                        DbEntityEntry<Customer> entityEntry = test.Entry(SelectedItem);
                                        if ((entityEntry.State != EntityState.Detached))
                                        {
                                            entityEntry.State = EntityState.Deleted;
                                        }
                                        else
                                        {
                                            test.Customers.Attach(SelectedItem);
                                            test.Customers.Remove(SelectedItem);
                                        }
                                        listOfUser.Remove(SelectedItem);
                                        SelectedItem = null;
                                        NotifyPropertyChanged(nameof(ListOfUser));
                                        test.SaveChanges();
                                    }
                                }
                                catch (DbUpdateConcurrencyException ex)
                                {
                                    MessageBox.Show("Alert! Log Out , press Ok to logout. " + ex.Message, "Alert! Log Out");
                                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                                    {
                                        if (window.DataContext == this)
                                        {
                                            window.Close();
                                            return;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Alert! Log Out , press Ok to logout. " + ex.Message, "Alert! Log Out");
                                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                                    {
                                        if (window.DataContext == this)
                                        {
                                            window.Close();
                                            return;
                                        }
                                    }
                                }
                            }
                        },
                        canExecute => true);
                }
                return _DeleteCustCommand;
            }
        }

        private MyDelegateCommand _DeleteDistCommand;
        public MyDelegateCommand DeleteDistCommand
        {
            get
            {
                if (_DeleteDistCommand == null)
                {
                    _DeleteDistCommand = new MyDelegateCommand(
                        actionObject =>
                        {
                            if (SelectedDistItem != null && SelectedDistItem.DistibutionName != null)
                            {
                                try
                                {
                                    using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                    {
                                        DbEntityEntry<Distribution> entityEntry = test.Entry(SelectedDistItem);
                                        if ((entityEntry.State != EntityState.Detached))
                                        {
                                            entityEntry.State = EntityState.Deleted;
                                        }
                                        else
                                        {
                                            test.Distributions.Attach(SelectedDistItem);
                                            test.Distributions.Remove(SelectedDistItem);
                                        }
                                        listOfDist.Remove(SelectedDistItem);
                                        SelectedDistItem = null;
                                        NotifyPropertyChanged(nameof(ListOfSO));
                                        test.SaveChanges();
                                    }
                                }
                                catch (DbUpdateConcurrencyException ex)
                                {
                                    MessageBox.Show("Alert! Log Out , press Ok to logout. " + ex.Message, "Alert! Log Out");
                                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                                    {
                                        if (window.DataContext == this)
                                        {
                                            window.Close();
                                            return;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Alert! Log Out , press Ok to logout. " + ex.Message, "Alert! Log Out");
                                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                                    {
                                        if (window.DataContext == this)
                                        {
                                            window.Close();
                                            return;
                                        }
                                    }

                                }
                            }
                          },
                        canExecute => true);
                }
                return _DeleteDistCommand;
            }
        }

        private MyDelegateCommand _DeleteSOCommand;
        public MyDelegateCommand DeleteSOCommand
        {
            get
            {
                if (_DeleteSOCommand == null)
                {
                    _DeleteSOCommand = new MyDelegateCommand(
                        actionObject =>
                        {   
                                if (SelectedSOItem != null && SelectedSOItem.SalesOfficerName != null)
                                {
                                try
                                {
                                    using (Test_WPF_1Entities test = new Test_WPF_1Entities())
                                    {
                                        DbEntityEntry<SalesInfo> entityEntry = test.Entry(SelectedSOItem);
                                        if ((entityEntry.State != EntityState.Detached))
                                        {
                                            entityEntry.State = EntityState.Deleted;
                                        }
                                        else
                                        {
                                            test.SalesInfoes.Attach(SelectedSOItem);
                                            test.SalesInfoes.Remove(SelectedSOItem);
                                        }
                                        listOfSO.Remove(SelectedSOItem);
                                        SelectedSOItem = null;
                                        NotifyPropertyChanged(nameof(ListOfSO));
                                        test.SaveChanges();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Alert! Log Out , press Ok to logout. " + ex.Message, "Alert! Log Out");
                                    foreach (System.Windows.Window window in System.Windows.Application.Current.Windows)
                                    {
                                        if (window.DataContext == this)
                                        {
                                            window.Close();
                                            return;
                                        }
                                    }

                                }
                            }
                        },
                        canExecute => true);
                }
                return _DeleteSOCommand;
            }
        }

    }
}
