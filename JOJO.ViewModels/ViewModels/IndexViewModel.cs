using Caliburn.Micro;
using JOJO.UC;
using System;

namespace JOJO.ViewModels
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