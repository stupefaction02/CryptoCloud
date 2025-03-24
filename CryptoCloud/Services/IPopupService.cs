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
        void ShowFileInfoPopup(DiskFileItemModel fileInfo);
    }
}
