using CommunityToolkit.Mvvm.ComponentModel;
using CryptoCloud.ViewModels;

namespace CryptoCloud.Models
{
    public class ViewNavigationModel : ObservableObject
    {
        private string dataContextKey = "_default";

        public BaseViewModel DataContext { get; set; }

        public string ViewKey
        {
            get
            {
                return dataContextKey;
            }

            set
            {
                dataContextKey = value;
            }
        }
    }
}
