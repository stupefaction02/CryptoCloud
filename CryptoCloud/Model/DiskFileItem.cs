using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCloud.Models
{
    public abstract class DiskFileItemModel
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
}
