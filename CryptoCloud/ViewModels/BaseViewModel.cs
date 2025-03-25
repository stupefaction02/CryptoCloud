using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CryptoCloud.ViewModels
{
	/// <summary>
	/// Description of BaseViewModel.
	/// </summary>
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string prop = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		}

        public string NavigationId { get; set; }
    }
}
