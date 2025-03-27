using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace CryptoCloud.AttachedProperties
{
    public class AnimationAttachedProperties : DependencyObject
    {
        public static bool GetStartSlideFromScreenTopAnimation(DependencyObject obj)
        {
            return (bool)obj.GetValue(StartSlideFromScreenTopAnimationProperty);
        }

        public static void SetStartSlideFromScreenTopAnimation(DependencyObject obj, bool value)
        {
            obj.SetValue(StartSlideFromScreenTopAnimationProperty, value);
        }

        public static readonly DependencyProperty StartSlideFromScreenTopAnimationProperty 
            = DependencyProperty.RegisterAttached("StartSlideFromScreenTopAnimation", 
                typeof(bool), 
                typeof(AnimationAttachedProperties), 
                new UIPropertyMetadata(false, StartSlideFromScreenEdgeAnimationChangedCallback));

        private static void StartSlideFromScreenEdgeAnimationChangedCallback(DependencyObject s, DependencyPropertyChangedEventArgs e)
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
            buttonAnimation.To = -(uiElement.ActualHeight);
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);

            uiElement.BeginAnimation(Canvas.TopProperty, buttonAnimation);
        }

        private static void DoAction(FrameworkElement uiElement)
        {
            if (uiElement.Visibility == Visibility.Collapsed || uiElement.Visibility == Visibility.Hidden)
            {
                uiElement.Visibility = Visibility.Visible;
            }

            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = -(uiElement.ActualHeight);
            buttonAnimation.To = 0;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);

            uiElement.BeginAnimation(Canvas.TopProperty, buttonAnimation);
        }
    }
}
