using System.Windows;
using MahApps.Metro.Controls;

namespace Sugar.WPF.Views.Account
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }
        private void login(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
