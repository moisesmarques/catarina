using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catarina.Web.Models.Account
{
    public class ConfirmMailModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
