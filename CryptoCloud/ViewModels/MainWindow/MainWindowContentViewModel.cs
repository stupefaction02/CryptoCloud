using CryptoCloud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels.MainWindowViewModels
{
    public class MainWindowContentViewModel : BaseViewModel, IHaveContentViewModel
    {
        private BaseViewModel content;

        public BaseViewModel CurrentContent
        {
            get => content; set
            {
                content = value;

                OnPropertyChanged(nameof(CurrentContent));
            }
        }
    }
}
