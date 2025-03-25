using CryptoCloud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels.MainViewViewModels
{
    public class MainViewContentViewModel : ViewModel, IHaveContentViewModel
    {
        private ViewModel content;

        public ViewModel CurrentContent
        {
            get => content; 
            set
            {
                content = value;

                OnPropertyChanged(nameof(CurrentContent));
            }
        }
    }
}
