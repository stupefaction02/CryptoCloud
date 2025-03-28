﻿using CommunityToolkit.Mvvm.Input;
using CryptoCloud.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoCloud.ViewModels
{
    public class FilesEncryptionProgressInfoViewModel : ViewModel
    {
        public double EncryptionProgress { get; set; }
        public string EncyptionProgressText { get; set; }

        private bool isPopupShown;

        public bool Collapsed { get; set; }

        public ICommand ToggleCollapsedCommand { get; set; }

        public ObservableCollection<FileEncryptionTaskModel> FileEncryptionTasks { get; set; }

        public bool IsPopupShown
        {
            get => isPopupShown;
            internal set
            {
                isPopupShown = value;
                OnPropertyChanged(nameof(IsPopupShown));
            }
        }

        public FilesEncryptionProgressInfoViewModel()
        {
            ToggleCollapsedCommand = new RelayCommand(ToggleCommandHandler);

            FileEncryptionTasks = new ObservableCollection<FileEncryptionTaskModel>
            {
                new FileEncryptionTaskModel { Name = "File1.png", SizeInfo = "91 мб", ProgressValue = 10 },
                new FileEncryptionTaskModel { Name = "File2.png", SizeInfo = "1 б", ProgressValue = 100 },
                new FileEncryptionTaskModel { Name = "File3.png", SizeInfo = "10 гб", ProgressValue = 0 },
            };

            EncryptionProgress = 20;
            EncyptionProgressText = $"Шифруем данные {EncryptionProgress}";
        }

        private void ToggleCommandHandler()
        {
            Collapsed = !Collapsed;

            EncryptionProgress = Collapsed ? 80 : 20;
            EncyptionProgressText = $"Шифруем данные {EncryptionProgress}%";

            OnPropertyChanged(nameof(Collapsed));
            OnPropertyChanged(nameof(EncryptionProgress));
            OnPropertyChanged(nameof(EncyptionProgressText));
        }
    }
}
