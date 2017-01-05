using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Chaotica___LingoIO.Core
{

    public static class Navigation<T>
    {
        public static void Navigate(object data = null)
        {
            //Push to Project Bug Reviewer
            var currentAV = ApplicationView.GetForCurrentView();
            var newAV = CoreApplication.CreateNewView();

            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = "Chaotica Speech";

            var frame = new Frame();
            frame.Navigate(typeof(T), data);
            newWindow.Content = frame;
            newWindow.Activate();
        }
    }
    public class ChaoticaCoreWindow
    {

        public static object FindFrameworkElementChild<T>(DependencyObject depObj, String elemName)
        {

            if (typeof(T) == typeof(CheckBox)){
                foreach (var item in FindVisualChildren<CheckBox>(depObj))
                {
                    if (item.Name == elemName)
                    {
                        return item;
                    }
                }
            }
            else if (typeof(T) == typeof(TextBox))
            {
                foreach (var item in FindVisualChildren<TextBox>(depObj))
                {
                    if (item.Name == elemName)
                    {
                        return item;
                    }
                }
            }
            else if (typeof(T) == typeof(Button))
            {
                foreach (var item in FindVisualChildren<Button>(depObj))
                {
                    if (item.Name == elemName)
                    {
                        return item;
                    }
                }
            }


            return null;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);

                    if (child != null && child is T)
                        yield return (T)child;

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
        public static void Navigate(Type type, Object data)
        {
            //Push to Project Bug Reviewer
            var currentAV = ApplicationView.GetForCurrentView();
            var newAV = CoreApplication.CreateNewView();

            var newWindow = Window.Current;
            var newAppView = ApplicationView.GetForCurrentView();
            newAppView.Title = "Chaotica Speech";

            var frame = new Frame();
            frame.Navigate(type, data);
            newWindow.Content = frame;
            newWindow.Activate();
        }

        public static async System.Threading.Tasks.Task xAsync(Func<bool> p)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                p();
            });
        }
    }
}
