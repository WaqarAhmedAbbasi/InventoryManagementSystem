using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Wpf_App.Legacy_Code
{
    public static class FetchMacAddress
    {
        public static string GetSystemMACID()
        {
            string systemName = SystemInformation.ComputerName;
            try
            {
                ManagementScope theScope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
                ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter");
                ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
                ManagementObjectCollection theCollectionOfResults = theSearcher.Get();

                foreach (ManagementObject theCurrentObject in theCollectionOfResults)
                {
                    if (theCurrentObject["MACAddress"] != null)
                    {
                        string macAdd = theCurrentObject["MACAddress"].ToString();
                        return macAdd;
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show(e.Message);

            }
            catch (System.UnauthorizedAccessException e)
            {
                MessageBox.Show(e.Message);
            }
            return string.Empty;
        }
    }
}
