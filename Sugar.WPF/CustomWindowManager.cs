using Caliburn.Micro;
using System.Windows;

namespace Sugar.WPF.ViewModels
{
    public class CustomWindowManager: WindowManager
    {
        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            Window window = base.EnsureWindow(model, view, isDialog);
            window.SizeToContent = SizeToContent.Manual;
            return window;
        }
    }
}
