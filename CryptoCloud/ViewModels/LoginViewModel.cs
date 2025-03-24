using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginButtonCommand { get; set; }

        public LoginViewModel()
        {
            LoginButtonCommand = new RelayCommand<object>(x => { });
        }
    }
}
