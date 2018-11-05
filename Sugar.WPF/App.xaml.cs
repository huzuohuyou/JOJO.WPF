using Sugar.WPF.Views.Account;
using System.Windows;

namespace Sugar.WPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
            Login window = new Login();
            bool? dialogResult = window.ShowDialog();
            if ((dialogResult.HasValue == true) &&
                (dialogResult.Value == true))
            {
                base.OnStartup(e);
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            else
            {
                this.Shutdown();
            }
        }
    }
}
