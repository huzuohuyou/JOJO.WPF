using Caliburn.Micro;
using JOJO.UC;
using System.ComponentModel.Composition;
namespace Sugar.WPF.ViewModels.Account
{
    [Export(typeof(LoginViewModel))]
    public class LoginViewModel : Screen, IShell
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        private readonly IWindowManager _windowManager;

        [ImportingConstructor]
        public LoginViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }
        
        public bool Login()
        {
            var str = UserName + PassWord;
            base.TryClose(true);
            return true;
        }
    }
}
