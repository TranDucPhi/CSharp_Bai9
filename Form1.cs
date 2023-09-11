using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Bai9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            long DungLuongRAM = 0;
            lblname.Text = Environment.MachineName.ToString();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
            ("SELECT * FROM Win32_Computersystem");
            foreach (ManagementObject obj in searcher.Get())
            {
                DungLuongRAM = long.Parse(obj["TotalPhysicalMemory"].ToString());
                DungLuongRAM = DungLuongRAM / (1024 * 1024); 
            }
            lblram.Text = DungLuongRAM.ToString() + " GB";
            string sCPUName = "";
            ManagementObjectSearcher searcher2 = new ManagementObjectSearcher
            ("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in searcher2.Get())
            {
                sCPUName = obj["Name"].ToString();
            }
            lblcpu.Text = sCPUName;
            string sHDDName = "";
            float sHDDSize = 0;
            ManagementObjectSearcher searcher3 = new ManagementObjectSearcher
            ("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject obj in searcher3.Get())
            {
                foreach (PropertyData pd in obj.Properties)
                {
                    if (pd.Name == "Model")
                    {
                        sHDDName = pd.Value.ToString();
                    }
                    if (pd.Name == "Size")
                    {
                        string size = pd.Value.ToString();
                        sHDDSize = float.Parse(size) / (1024 * 1024 * 1024);
                    }
                }
            }
            lblhdd.Text = sHDDName + " - Size: " + sHDDSize.ToString() + " GB";
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
