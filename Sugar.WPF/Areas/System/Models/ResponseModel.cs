using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugar.WPF.Areas.System.Models
{
    public class ResponseModel<T>
    {
        public string state { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
