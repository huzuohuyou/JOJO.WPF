using Caliburn.Micro;
using JOJO.UC;
using System;

namespace Panuon.UIBrowser.ViewModels.Partial
{
    public class IndexViewModel : Screen, IShell
    {
        public IndexViewModel()
        {
            DisplayName = "首页";
        }

        public override void CanClose(Action<bool> callback)
        {
            base.CanClose(callback);
        }
    }
}