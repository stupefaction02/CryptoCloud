﻿using CommunityToolkit.Mvvm.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels
{
    public class DiskFileItemModel
    {
        public string Name { get; set; }

        public string ModificationDate { get; set; }
    }

    public class DiskFolderModel : DiskFileItemModel
    {

    }

    public class DiskFileModel : DiskFileItemModel
    {

    }

    public class DiskItemViewModel : ObservableObject
    {
        public string Type { get; set; }

        public DiskFileItemModel Model { get; set; }
    }

    public class DiskFilesViewModel : BaseViewModel
    {
        public ObservableCollection<DiskItemViewModel> Files { get; set; }

        public string DiskOwner { get; set; }

        //ObservableGroupedCollection

        public DiskFilesViewModel()
        {
            Files = new ObservableCollection<DiskItemViewModel>
            {
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка 1", ModificationDate = "24.03.2025 9:32" } },
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка 123", ModificationDate = "14.02.2015 13:32" } },
                new DiskItemViewModel { Type = "folder", Model = new DiskFolderModel { Name = "Папка - copy (123)", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "file.png", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "x-file.png", ModificationDate = "8.03.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "ABOBA.png", ModificationDate = "28.13.2023 11:32" } },
                new DiskItemViewModel { Type = "file", Model = new DiskFolderModel { Name = "x-file (1).png", ModificationDate = "89.01.2123 29:32" } },
            };
        }
    }
}
