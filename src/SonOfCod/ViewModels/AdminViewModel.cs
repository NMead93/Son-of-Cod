using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SonOfCod.Models;

namespace SonOfCod.ViewModels
{
    public class AdminViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public virtual Admin User { get; set; }
        public virtual IEnumerable<Subscriber> Subscribers { get; set; }
        public bool LoginFailed { get; set; }
    }
}
