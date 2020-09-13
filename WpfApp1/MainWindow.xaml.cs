using Microsoft.Win32;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClickTurnOn(object sender, RoutedEventArgs e)
        {
            #region 设置开机自启
            try
            {
                string strName = AppDomain.CurrentDomain.BaseDirectory + "WpfApp1.exe";//获取要自动运行的应用程序名，也就是本程序的名称
                if (!System.IO.File.Exists(strName))//判断要自动运行的应用程序文件是否存在
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);//获取应用程序文件名，不包括路径
                RegistryKey registry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//检索指定的子项
                if (registry == null)//若指定的子项不存在
                    registry = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//则创建指定的子项
                registry.SetValue(strnewName, strName);//设置该子项的新的“键值对”
                registry.Close();
                MessageBox.Show("开机自启设置成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }

        private void BtnClickTurnOff(object sender, RoutedEventArgs e)
        {
            #region 取消开机自启
            try
            {
                string strName = AppDomain.CurrentDomain.BaseDirectory + "WpfApp1.exe";//获取要自动运行的应用程序名
                if (!System.IO.File.Exists(strName))//判断要取消的应用程序文件是否存在
                    return;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);///获取应用程序文件名，不包括路径
                RegistryKey registry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//读取指定的子项
                if (registry == null)//若指定的子项不存在
                    registry = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");//则创建指定的子项
                registry.DeleteValue(strnewName, false);//删除指定“键名称”的键/值对
                registry.Close();
                MessageBox.Show("取消开机自启。");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }
    }
}
