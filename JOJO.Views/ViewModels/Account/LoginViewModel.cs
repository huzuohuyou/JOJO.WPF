using Caliburn.Micro;
using Elight.Infrastructure;
using JOJO.UC;
using Sugar.WPF.Areas.System.Models;
using Sugar.WPF.Utils;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Security.Cryptography;
using System.Text;

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
        
        public Operator Login()
        {
            var str = UserName + PassWord;
            var response = new Ajax<ResponseModel<Operator>, LoginModel>(new LoginModel() {
                userName = UserName,
                password = MD5Encrypt32( PassWord),
            })
            {
                url = @"http://localhost:17924/Account/Login",
            }.Post();
            base.TryClose(true);
            return response.data;
        }
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create(); 
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("x2");
            }
            return pwd;
        }
    }
}
