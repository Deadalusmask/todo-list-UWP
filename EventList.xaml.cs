using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using todo_list.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace todo_list
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class EventList : Page
    {
        private List<Event> Events;

        public EventList()
        {
            this.InitializeComponent();
            Events = EventManager.GetEvents();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedEvents = (Event)e.ClickedItem;
            Frame.Navigate(typeof(ViewEvent),selectedEvents);
        }
    }
}
