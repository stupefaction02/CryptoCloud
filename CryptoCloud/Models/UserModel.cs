using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Models
{
    public class UserModel : ObservableObject
    {
        private string email;

        public string Email { get { return email; } set => email = value; }

        public string Password { get; set; }
    }
}
