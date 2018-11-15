using Sugar.WPF.Utils;

namespace Sugar.WPF.ViewModels.Account
{
    public class UserModel :  BindableObject
    {
        
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
    }
}
