﻿using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Models;
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

    public class SideMenuViewModel : ViewModel
    {
        public ObservableCollection<SideMenuItemModel> MenuItems { get; set; }

        public ICommand ItemClickedCommand { get; set; }

        public ILogger Logger { get; }

        public SideMenuViewModel(ILoggerFactory loggerFactory)
        {
            MenuItems = new ObservableCollection<SideMenuItemModel>
            {
                new SideMenuItemModel { Name = "recent", Text = "Последние", ImageSource = "pack://application:,,,/Images/Clock.png" },
                new SideMenuItemModel { Name = "files", Text = "Файлы", ImageSource = "pack://application:,,,/Images/Folder.png" },
                new SideMenuItemModel { Name = "myDisks", Text = "Мои диски", ImageSource = "pack://application:,,,/Images/Cloud.png" },
                new SideMenuItemModel { Name = "downloads", Text = "Загрузки", ImageSource = "pack://application:,,,/Images/Download.png" },
                new SideMenuItemModel { Name = "settings", Text = "Настройки", ImageSource = "pack://application:,,,/Images/Gear.png" },
                new SideMenuItemModel { Name = "trash", Text = "Корзина", ImageSource = "pack://application:,,,/Images/Trash.png" },
            };

            ItemClickedCommand = new RelayCommand<object>(ItemClickedCommandHandler);

            Logger = loggerFactory.CreateLogger<SideMenuViewModel>();
        }

        private void ItemClickedCommandHandler(object? obj)
        {
            if (obj is string uid)
            {
                Logger.LogInformation($"Clicked item: uid={uid}");

                var currentSelected = MenuItems.SingleOrDefault(x => x.IsSelected);

                if (currentSelected != null)
                {
                    currentSelected.IsSelected = false;
                }

                var clicked = MenuItems.SingleOrDefault(x => x.Uid == uid);

                clicked.IsSelected = true;
            }
        }
    }
}
