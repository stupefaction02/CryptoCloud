using CryptoCloud.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.ViewModels
{
    public class InputErrorViewModel : ViewModel
    {
        public List<string> Errors { get; set; }

        public bool IsShown { get; set; }
    }
}
