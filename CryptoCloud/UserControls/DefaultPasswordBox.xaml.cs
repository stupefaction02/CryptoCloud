using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace CryptoCloud.UserControls
{
    /// <summary>
    /// Логика взаимодействия для SearchBox.xaml
    /// </summary>
    public partial class DefaultPasswordBox : UserControl
    {
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly DependencyProperty PlaceholderProperty =
                DependencyProperty.Register(
                        "Placeholder",
                        typeof(string),
                        typeof(DefaultPasswordBox),
                        new FrameworkPropertyMetadata(
                                string.Empty,
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender,
                                new PropertyChangedCallback(OnPlaceholderChanged)));

        public string Text
        {
            get { return this.textBox.Password; }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register(
                        "Text",
                        typeof(string),
                        typeof(DefaultPasswordBox),
                        new FrameworkPropertyMetadata(
                                string.Empty,
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender | 
                                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                new PropertyChangedCallback(OnTextChanged), null, true, UpdateSourceTrigger.PropertyChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl c = (UserControl)d;

            PasswordBox tb = (PasswordBox)c.Content;

            string newValue = e.NewValue as string;
            if (!String.IsNullOrEmpty(newValue))
            {
                // loop prevention
                if (tb.Password != newValue)
                {
                    tb.Password = newValue;
                }
            }
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl c = (UserControl)d;

            PasswordBox tb = (PasswordBox)c.Content;

            string newValue = e.NewValue as string;
            if (!String.IsNullOrEmpty(newValue))
            {
                tb.Tag = newValue;
            }
        }

        public DefaultPasswordBox()
        {
            InitializeComponent();

            this.textBox.PasswordChanged += Text_TextChanged;
        }

        private void Text_TextChanged(object sender, RoutedEventArgs e)
        {
            Text = this.textBox.Password;

            //BindingExpression be = this.GetBindingExpression(InputTextBox.TextProperty);
            //be.UpdateSource();
        }
    }
}
