using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
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
        public string Uid { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// item or addButton
        /// </summary>
        public string Type { get; set; } = "item";

        public DiskModel DiskModel { get; set; }
    }

    public class MyDisksViewModel : ViewModel
    {
        public ICommand DiskClickedCommand { get; set; }

        public ICommand AddDiskCommand { get; set; }

        public void AddDiskCommnadHandler(object obj)
        {
        }

        public ObservableCollection<DiskItemModel> Disks { get; set; }

        ILogger logger;

        public MyDisksViewModel(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<MyDisksViewModel>();

            AddDiskCommand = new RelayCommand<object>(AddDiskCommnadHandler);

            DiskClickedCommand = new RelayCommand<object>(DiskClickedCommandHandler);

            Disks = new ObservableCollection<DiskItemModel>
            {
                new DiskItemModel { Type = "addButton" },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "Ivan", Size = "15 ГБ", Type = "Disk" } },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "@Stepan", Size = "215 ГБ", Type = "Disk" } },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "vasily.zadov1957@mail.ru", Size = "15 МБ", Type = "Disk" } },
                new DiskItemModel { DiskModel = new DiskModel { Owner = "Anon", Size = "1512 ТБ", Type = "Disk" } },
            };
        }

        private void DiskClickedCommandHandler(object? obj)
        {
            if (obj is string uid)
            {
                var clickedDisk = Disks.SingleOrDefault(x => x.Uid == uid);

                DiskModel model = clickedDisk.DiskModel;

                logger.LogInformation($"Disk item click. DiskModel = {{ owner = {model.Owner} }}");
            }
        }
    }
}
