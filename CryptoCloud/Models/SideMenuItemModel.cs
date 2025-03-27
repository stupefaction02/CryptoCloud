using CommunityToolkit.Mvvm.ComponentModel;

namespace CryptoCloud.Models
{
    public class SideMenuItemModel : ObservableObject
    {
        private bool isSelected;

        public string Name { get; set; }

        public string Uid { get; set; } = Guid.NewGuid().ToString();

        public string ImageSource { get; set; }

        public string Text { get; set; }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
