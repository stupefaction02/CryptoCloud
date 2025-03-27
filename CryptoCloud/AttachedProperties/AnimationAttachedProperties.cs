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
                DoSlideFromScreenTopAnimation(uiElement);
            }
            else
            {
                bool loaded = uiElement.IsLoaded;

                if (loaded)
                {
                    UndoSlideFromScreenTopAnimation(uiElement);
                }
            }
        }

        private static void UndoSlideFromScreenTopAnimation(FrameworkElement uiElement)
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 0;
            buttonAnimation.To = -(uiElement.ActualHeight);
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);

            uiElement.BeginAnimation(Canvas.TopProperty, buttonAnimation);
        }

        private static void DoSlideFromScreenTopAnimation(FrameworkElement uiElement)
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


        public static bool GetStartSlideFromScreenBottomAnimation(DependencyObject obj)
        {
            return (bool)obj.GetValue(StartSlideFromScreenBottomAnimationProperty);
        }

        public static void SetStartSlideFromScreenBottomAnimation(DependencyObject obj, bool value)
        {
            obj.SetValue(StartSlideFromScreenBottomAnimationProperty, value);
        }

        public static readonly DependencyProperty StartSlideFromScreenBottomAnimationProperty
            = DependencyProperty.RegisterAttached("StartSlideFromScreenBottomAnimation",
                typeof(bool),
                typeof(AnimationAttachedProperties),
                new UIPropertyMetadata(false, StartSlideFromScreenBottomAnimationChangedCallback));

        private static void StartSlideFromScreenBottomAnimationChangedCallback(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = s as FrameworkElement;
            if (uiElement == null)
                throw new InvalidOperationException("This attached property only supports Storyboards.");

            var begin = (bool)e.NewValue;
            if (begin)
            {
                DoSlideFromScreenBottomAnimation(uiElement);
            }
            else
            {
                bool loaded = uiElement.IsLoaded;

                if (loaded)
                {
                    UndoSlideFromScreenBottomAnimation(uiElement);
                }
            }
        }

        private static void DoSlideFromScreenBottomAnimation(FrameworkElement uiElement)
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = -(uiElement.ActualHeight);
            buttonAnimation.To = 0 + 20;
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);

            uiElement.BeginAnimation(Canvas.BottomProperty, buttonAnimation);
        }

        private static void UndoSlideFromScreenBottomAnimation(FrameworkElement uiElement)
        {
            if (uiElement.Visibility == Visibility.Collapsed || uiElement.Visibility == Visibility.Hidden)
            {
                uiElement.Visibility = Visibility.Visible;
            }

            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 0;
            buttonAnimation.To = -(uiElement.ActualHeight + 20);
            buttonAnimation.Duration = TimeSpan.FromSeconds(0.5);

            uiElement.BeginAnimation(Canvas.BottomProperty, buttonAnimation);
        }
    }
}
