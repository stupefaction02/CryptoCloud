using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class DiskModel
    {
        public string Type { get; set; }
        public string Owner { get; set; }
        public string Size { get; set; }
    }

    public class DiskItemModel
    {
        /// <summary>
        /// item or addButton
        /// </summary>
        public string Type { get; set; } = "item";

        public DiskModel DiskModel { get; set; }
    }

    public class MyDisksViewModel : BaseViewModel
    {
        public ICommand AddDiskCommand { get; set; }

        public void AddDiskCommnadHandler(object obj)
        {
        }

        public ObservableCollection<DiskItemModel> Disks { get; set; }

        public MyDisksViewModel()
        {
            AddDiskCommand = new RelayCommand<object>(AddDiskCommnadHandler);

            Disks = new ObservableCollection<DiskItemModel>
            {
                new DiskItemModel { Type = "addButton" },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "Ivan", Size = "15 ГБ", Type = "Disk" } },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "@Stepan", Size = "215 ГБ", Type = "Disk" } },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "vasily.zadov1957@mail.ru", Size = "15 МБ", Type = "Disk" } },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "Anon", Size = "1512 ТБ", Type = "Disk" } },
            };
        }
    }
}
