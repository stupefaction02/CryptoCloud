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
    public partial class InputTextBox : UserControl
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
                        typeof(InputTextBox),
                        new FrameworkPropertyMetadata(
                                string.Empty,
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender,
                                new PropertyChangedCallback(OnPlaceholderChanged)));

        public string Text
        {
            get { return this.textBox.Text; }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
                DependencyProperty.Register(
                        "Text",
                        typeof(string),
                        typeof(InputTextBox),
                        new FrameworkPropertyMetadata(
                                string.Empty,
                                FrameworkPropertyMetadataOptions.AffectsMeasure |
                                FrameworkPropertyMetadataOptions.AffectsRender | 
                                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                new PropertyChangedCallback(OnTextChanged), null, true, UpdateSourceTrigger.PropertyChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl c = (UserControl)d;

            TextBox tb = (TextBox)c.Content;

            string newValue = e.NewValue as string;
            if (!String.IsNullOrEmpty(newValue))
            {
                // loop prevention
                if (tb.Text != newValue)
                {
                    tb.Text = newValue;
                }
            }
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl c = (UserControl)d;

            TextBox tb = (TextBox)c.Content;

            string newValue = e.NewValue as string;
            if (!String.IsNullOrEmpty(newValue))
            {
                tb.Tag = newValue;
            }
        }

        public InputTextBox()
        {
            InitializeComponent();

            this.textBox.TextChanged += Text_TextChanged;
        }

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = this.textBox.Text;

            //BindingExpression be = this.GetBindingExpression(InputTextBox.TextProperty);
            //be.UpdateSource();
        }
    }
}
