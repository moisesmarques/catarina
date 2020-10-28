using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catarina.Web.Models.Account
{
    public class ChangePasswordModel
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
