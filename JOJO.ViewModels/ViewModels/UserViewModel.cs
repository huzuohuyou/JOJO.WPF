using Caliburn.Micro;
using JOJO.UC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOJO.ViewModels
{
    class UserViewModel : Screen, IShell
    {
        public UserViewModel()
        {
            DisplayName = "系统用户";
        }
    }
}
