using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using todo_list.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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


        public EventList()
        {
            this.InitializeComponent();
            Loaded += EventList_Loaded;
        }


        async void EventList_Loaded(object sender, RoutedEventArgs e)
        {
            List.Items.Clear();
            StorageFolder storage = await ApplicationData.Current.LocalFolder.CreateFolderAsync("TodoList", CreationCollisionOption.OpenIfExists);
            var files = await storage.GetFilesAsync();
            {
                foreach (StorageFile file in files)
                {
                    Grid a = new Grid();
                    ColumnDefinition col = new ColumnDefinition();
                    col.Width = GridLength.Auto;
                    a.ColumnDefinitions.Add(col);
                    ColumnDefinition col2 = new ColumnDefinition();
                    col2.Width = GridLength.Auto;
                    a.ColumnDefinitions.Add(col2);
                    TextBlock txbx = new TextBlock();
                    txbx.Text = file.DisplayName;
                    txbx.HorizontalAlignment = HorizontalAlignment.Center;
                    Grid.SetColumn(txbx, 0);
                    HyperlinkButton btn = new HyperlinkButton();
                    btn.Content = "查看详细";
                    btn.Name = file.DisplayName;
                    btn.Click += (s, ea) =>
                    {
                        Frame.Navigate(typeof(ViewEvent), file);
                    };
                    Grid.SetColumn(btn, 1);

                    a.Children.Add(txbx);
                    a.Children.Add(btn);

                    List.Items.Add(a);
                }
            }
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

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddPage));
        }
    }
}
