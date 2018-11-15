using Caliburn.Micro;
using JOJO.UC;
using Panuon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panuon.UIBrowser.ViewModels.Partial
{
    class IndexViewModel : Screen, IShell
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
