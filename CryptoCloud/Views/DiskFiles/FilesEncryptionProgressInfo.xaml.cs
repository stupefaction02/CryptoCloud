using CryptoCloud.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoCloud.Views.DiskFiles
{
    /// <summary>
    /// Логика взаимодействия для FilesEncryptionProgressInfo.xaml
    /// </summary>
    public partial class FilesEncryptionProgressInfo : UserControl
    {
        public bool Collapsed
        {
            get { return (bool)GetValue(CollapsedProperty); }
            set { SetValue(CollapsedProperty, value); }
        }

        public static readonly DependencyProperty CollapsedProperty =
                DependencyProperty.Register(
                        "Collapsed",
                        typeof(bool),
                        typeof(FilesEncryptionProgressInfo),
                        new FrameworkPropertyMetadata(
                                false,
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender,
                                new PropertyChangedCallback(OnCollapsedChanged)));

        private static void OnCollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((FilesEncryptionProgressInfo)d).Collapse();
        }

        private void Collapse()
        {
            //this.Template.FindName();
        }

        public FilesEncryptionProgressInfo()
        {
            InitializeComponent();
        }
    }
}
