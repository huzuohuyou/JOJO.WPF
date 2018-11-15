using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugar.WPF.Areas.System.Models
{
    public class Menus
    {
        public string title { get; set; }
        public string icon { get; set; }
        public string spread { get; set; }
        public List<Childrens> children { get; set; }
    }

    public class Childrens
    {
        public string title { get; set; }
        public string icon { get; set; }
        public string href { get; set; }
    }
}
