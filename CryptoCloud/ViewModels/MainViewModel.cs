using CryptoCloud.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ViewNavigationModel ViewNavigationModel { get; set; }

        public MainViewModel()
        {
            ViewNavigationModel = new ViewNavigationModel { DataContext = new DiskFilesViewModel(), ViewKey = "DiskFiles" };
        }
    }
}
