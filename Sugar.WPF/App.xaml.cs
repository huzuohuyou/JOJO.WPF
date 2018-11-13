using Caliburn.Micro;
using Sugar.WPF.ViewModels.Account;
using Sugar.WPF.Views.Account;
using System.ComponentModel.Composition;
using System.Windows;

namespace Sugar.WPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    //[Export(typeof(App))]
    public partial class App : Application
    {


        //public App() { }
        //private readonly IWindowManager _windowManager;
        //[ImportingConstructor]
        //public App(IWindowManager windowManager)
        //{
        //    _windowManager = windowManager;

        //}
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnExplicitShutdown;
        //    var loginViewModel = IoC.Get<LoginViewModel>();
        //    //var loginViewModel = new LoginViewModel(_windowManager);
        //    var dialogResult = _windowManager.ShowDialog(loginViewModel);
        //    if ((dialogResult.HasValue == true) &&
        //        (dialogResult.Value == true))
        //    {
        //        base.OnStartup(e);
        //        Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
        //    }
        //    else
        //    {
        //        this.Shutdown();
        //    }
        //}
    }
}
