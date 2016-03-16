using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using todo_list.Model;
using Windows.Data.Xml.Dom;
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
            this.SizeChanged += MainPage_SizeChanged;
            BackButton.Visibility = Visibility.Collapsed;
        }


        async void EventList_Loaded(object sender, RoutedEventArgs e)
        {
            List1.Items.Clear();
            List2.Items.Clear();
            List3.Items.Clear();
            StorageFolder storage = await ApplicationData.Current.LocalFolder.CreateFolderAsync("TodoList", CreationCollisionOption.OpenIfExists);
            var files = await storage.GetFilesAsync();
            {
                foreach (StorageFile file in files)
                {
                    Grid a = new Grid();
                    Grid b = new Grid();
                    Grid c = new Grid();

                    var bounds = Window.Current.Bounds;
                    double height = bounds.Height;
                    double width = bounds.Width;
                    a.Width = width;

                    //ColumnDefinition col = new ColumnDefinition();
                    //col.Width = new GridLength(1,GridUnitType.Star);
                    //a.ColumnDefinitions.Add(col);
                    //ColumnDefinition col2 = new ColumnDefinition();
                    //col2.Width = new GridLength(2,GridUnitType.Star);
                    //a.ColumnDefinitions.Add(col2);
                    //ColumnDefinition col3 = new ColumnDefinition();
                    //col3.Width = new GridLength(1, GridUnitType.Star);
                    //a.ColumnDefinitions.Add(col3);
                    TextBlock txbx = new TextBlock();
                    txbx.Text = file.DisplayName;
                    txbx.HorizontalAlignment = HorizontalAlignment.Left;
                    txbx.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(txbx,0);

                    TextBlock DateTextBlock = new TextBlock();
                    XmlDocument doc = await XmlDocument.LoadFromFileAsync(file);
                    DateTextBlock.Text = doc.DocumentElement.Attributes.GetNamedItem("date").NodeValue.ToString();
                    DateTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    DateTextBlock.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(DateTextBlock, 1);

                    Button btn = new Button();
                    btn.Content = "View";
                    btn.Name = file.DisplayName;
                    btn.HorizontalAlignment = HorizontalAlignment.Left;
                    btn.VerticalAlignment = VerticalAlignment.Center;
                    btn.Click += (s, ea) =>
                    {
                        Frame.Navigate(typeof(ViewEvent), file);
                    };
                    Grid.SetColumn(btn, 2);

                    a.Children.Add(txbx);
                    b.Children.Add(DateTextBlock);
                    c.Children.Add(btn);
                    List1.Items.Add(a);
                    List2.Items.Add(b);
                    List3.Items.Add(c);
                }
            }
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Get the current Windows Size
            var bounds = Window.Current.Bounds;
            double height = bounds.Height;
            double width = bounds.Width;
            bg.Width = width;
            bg.Height = height;
            create.Width = width-44;
            List1.Width = width / 5;
            List1.Width = width / 5 * 2;
            List1.Width = width / 5;
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
