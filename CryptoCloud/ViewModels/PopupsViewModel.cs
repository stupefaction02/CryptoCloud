using CryptoCloud.ViewModels.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels.Popup
{
    public class FilePopupViewModel
    {
        public DiskModel FileModel { get; set; }
    }
}

namespace CryptoCloud.ViewModels
{
    public class PopupsViewModel
    {
        public bool ToggleFileInfoPopup { get; set; }
        public FilePopupViewModel FileInfoDataContext { get; set; }
    }
}
