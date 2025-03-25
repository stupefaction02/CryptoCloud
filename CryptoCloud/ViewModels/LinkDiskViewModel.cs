using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class LinkDiskViewModel : BaseViewModel
    {
        public ICommand LinkDiskCommand { get; set; }

        public LinkDiskViewModel()
        {
            LinkDiskCommand = new RelayCommand(LinkDiskCommandHandler);
        }

        private void LinkDiskCommandHandler()
        {
            
        }
    }
}
