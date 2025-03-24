using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels
{
    public class SideMenuItemModel
    {
        public string ImageSource { get; set; }
        public string Text { get; set; }

        public bool IsSelected { get; set; }
    }

    public class SideMenuViewModel : BaseViewModel
    {
        public ObservableCollection<SideMenuItemModel> MenuItems { get; set; }

        public SideMenuViewModel()
        {
            MenuItems = new ObservableCollection<SideMenuItemModel>
            {
                new SideMenuItemModel { Text = "Последние", ImageSource = "pack://application:,,,/Images/Clock.png" },
                new SideMenuItemModel { Text = "Файлы", ImageSource = "pack://application:,,,/Images/Folder.png" },
                new SideMenuItemModel { IsSelected = true, Text = "Мои диски", ImageSource = "pack://application:,,,/Images/Cloud.png" },
                new SideMenuItemModel { Text = "Загрузки", ImageSource = "pack://application:,,,/Images/Download.png" },
                new SideMenuItemModel { Text = "Настройки", ImageSource = "pack://application:,,,/Images/Gear.png" },
                new SideMenuItemModel { Text = "Корзина", ImageSource = "pack://application:,,,/Images/Trash.png" },
            };
        }
    }
}
