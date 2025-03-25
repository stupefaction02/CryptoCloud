using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels.MainWindowViewModels
{
    public class NavigationViewModel : BaseViewModel
    {
        private BaseViewModel content;

        public BaseViewModel Content
        {
            get => content; set
            {
                content = value;

                OnPropertyChanged(nameof(Content));
            }
        }
    }
}
