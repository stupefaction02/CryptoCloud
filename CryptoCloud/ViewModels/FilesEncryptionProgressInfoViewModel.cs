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
    public class FileEncryptionTaskModel
    {
        public string Name { get; set; }

        public string SizeInfo { get; set; }

        /// <summary>
        /// 1-100
        /// </summary>
        public int ProgressValue { get; set; }
    }

    public class FilesEncryptionProgressInfoViewModel : ViewModel
    {
        public bool Collapsed { get; set; }

        public ICommand ToggleCollapsedCommand { get; set; }

        public ObservableCollection<FileEncryptionTaskModel> FileEncryptionTasks { get; set; }

        public FilesEncryptionProgressInfoViewModel()
        {
            ToggleCollapsedCommand = new RelayCommand(ToggleCommandHandler);

            FileEncryptionTasks = new ObservableCollection<FileEncryptionTaskModel>
            {
                new FileEncryptionTaskModel { Name = "File1.png", SizeInfo = "91 мб", ProgressValue = 10 },
                new FileEncryptionTaskModel { Name = "File2.png", SizeInfo = "1 б", ProgressValue = 100 },
                new FileEncryptionTaskModel { Name = "File3.png", SizeInfo = "10 гб", ProgressValue = 0 },
            };
        }

        private void ToggleCommandHandler()
        {
            Collapsed = !Collapsed;

            OnPropertyChanged(nameof(Collapsed));
        }
    }
}
