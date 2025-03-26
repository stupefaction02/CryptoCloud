using CryptoCloud.Models;
using CryptoCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Services
{
    public interface IPopupService
    {
        void HideAllPopups();
        void ShowFileInfoPopup(DiskFileItemModel fileInfo);
    }
}
