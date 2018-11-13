using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugar.WPF.Areas.System.Models
{
    public class LoginModel
    {
        public string userName { get; set; }
        public string password { get; set; }

        public string verifyCode { get; set; }

        //{
        //     {"userName", "admin"},
        //     {"password", "wuhailong123"},
        //     {"verifyCode", "1"},
        //  }
    }
}
