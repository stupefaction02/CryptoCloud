using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels
{
    public class DiskModel
    {

    }

    public class MyDisksViewModel : BaseViewModel
    {
        public ObservableCollection<DiskModel> Disks { get; set; }

        public MyDisksViewModel()
        {
            Disks = new ObservableCollection<DiskModel>
            {

            };
        }
    }
}
