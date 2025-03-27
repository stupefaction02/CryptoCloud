using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CryptoCloud.AttachedProperties
{
    public class CollapsedAttachedProperties : DependencyObject
    {
        public static bool GetStartCollapseAnimation(DependencyObject obj)
        {
            return (bool)obj.GetValue(StartCollapseAnimationProperty);
        }

        public static void SetStartCollapseAnimation(DependencyObject obj, bool value)
        {
            obj.SetValue(StartCollapseAnimationProperty, value);
        }

        public static readonly DependencyProperty StartCollapseAnimationProperty
            = DependencyProperty.RegisterAttached("StartCollapseAnimation",
                typeof(bool),
                typeof(CollapsedAttachedProperties),
                new UIPropertyMetadata(false, OnStartCollapseAnimationChanged));

        private static void OnStartCollapseAnimationChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = s as FrameworkElement;
            if (uiElement == null)
                throw new InvalidOperationException("This attached property only supports Storyboards.");

            var begin = (bool)e.NewValue;
            if (begin)
            {
                DoAction(uiElement);
            }
            else
            {
                bool loaded = uiElement.IsLoaded;

                if (loaded)
                {
                    UndoAction(uiElement);
                }
            }
        }

        private static void UndoAction(FrameworkElement uiElement)
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 0;
            buttonAnimation.To = uiElement.ActualHeight;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);

            uiElement.BeginAnimation(Canvas.HeightProperty, buttonAnimation);
        }

        private static void DoAction(FrameworkElement uiElement)
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = uiElement.ActualHeight;
            buttonAnimation.To = 0;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);

            uiElement.BeginAnimation(Canvas.HeightProperty, buttonAnimation);
        }
    }
}
