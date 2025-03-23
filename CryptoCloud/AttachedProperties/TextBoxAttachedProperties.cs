using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoCloud.AttachedProperties
{
    public static class AttachedProperties
    {
        public static readonly DependencyProperty PlaceholderProperty =
                DependencyProperty.RegisterAttached("Placeholder", typeof(String),
                    typeof(AttachedProperties),
                    new PropertyMetadata(String.Empty));

        public static void SetPlaceholder(UIElement element, String value)
        {
            element.SetValue(PlaceholderProperty, value);
        }

        public static String GetPlaceholder(UIElement element)
        {
            return (String)element.GetValue(PlaceholderProperty);
        }
    }
}
