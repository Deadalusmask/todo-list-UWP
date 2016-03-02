using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace todo_list
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            ApplicationView.PreferredLaunchViewSize = new Size(680,450);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size { Width = 680, Height = 450 });
        

            BackButton.Visibility = Visibility.Collapsed;
            HomeListBoxItem.IsSelected = true;
            MainContent.Navigate(typeof(Home));

        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomeListBoxItem.IsSelected) {
                MainContent.Navigate(typeof(Home));
                BackButton.Visibility = Visibility.Collapsed;
            }
            else if (EventListBoxItem.IsSelected)
            {
                MainContent.Navigate(typeof(EventList));
                BackButton.Visibility = Visibility.Collapsed;
            }
            else if (SettingsListBoxItem.IsSelected) {
                MainContent.Navigate(typeof(Settings));
                BackButton.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainContent.CanGoBack)
            {
                MainContent.GoBack();
                HomeListBoxItem.IsSelected = true;
            }
        }

    }
}
