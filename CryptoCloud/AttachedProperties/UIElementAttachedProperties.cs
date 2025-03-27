using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CryptoCloud.AttachedProperties
{
    public class UIElementAttachedProperties
    {
        public static bool GetForceFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(GetForceFocusProperty);
        }

        public static void SetGetForceFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(GetForceFocusProperty, value);
        }

        public static readonly DependencyProperty GetForceFocusProperty
            = DependencyProperty.RegisterAttached("ForceFocus",
                typeof(bool),
                typeof(CollapsedAttachedProperties),
                new UIPropertyMetadata(false, OnForceFocusChanged));

        private static void OnForceFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)d;

            FocusManager.SetFocusedElement(element, null);
        }
    }
}
