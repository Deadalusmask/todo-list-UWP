using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using todo_list.Model;
using Windows.Storage;
using Windows.Data.Xml.Dom;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace todo_list
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ViewEvent : Page
    {
        public ViewEvent()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            StorageFile file = e.Parameter as StorageFile;
            if (file == null) return;
            String itemName = file.DisplayName;
            Title.Text = itemName;
            XmlDocument doc = await XmlDocument.LoadFromFileAsync(file);
            DateTextBlock.Text = doc.DocumentElement.Attributes.GetNamedItem("date").NodeValue.ToString();
            Desc.Text = doc.DocumentElement.Attributes.GetNamedItem("describe").NodeValue.ToString();
            string status = doc.DocumentElement.Attributes.GetNamedItem("status").NodeValue.ToString();
            if (status.Length == 4)
            { 
                DoneA.Visibility = Visibility.Collapsed;
                DoneIm.Visibility = Visibility.Visible;
            }

            
            Confirm.Click += async (s, ea) =>
            {
                await file.DeleteAsync();
                ConfirmFlyout.Hide();
                Frame.Navigate(typeof(EventList));
            };
            DoneButton.Click += async (s, ea) =>
            {
                await file.DeleteAsync();
                StorageFolder storage = await ApplicationData.Current.LocalFolder.GetFolderAsync("TodoList");
                XmlDocument _doc = new XmlDocument();
                XmlElement _item = _doc.CreateElement(Title.Text);
                _item.SetAttribute("date",DateTextBlock.Text);
                _item.SetAttribute("describe", Desc.Text);
                _item.SetAttribute("status","Done");
                _doc.AppendChild(_item);
                StorageFile Done = await storage.CreateFileAsync(Title.Text  + ".xml", CreationCollisionOption.ReplaceExisting);
                await _doc.SaveToFileAsync(Done);

                DoneA.Visibility = Visibility.Collapsed;
                DoneConfirmFly.Hide();
                DoneIm.Visibility = Visibility.Visible;
            };
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        //private void Confirm_Click(object sender, RoutedEventArgs e)
        //{
            
        //    File.Delete(@"C:\Users\Deadalus\AppData\Local\Packages\a55a8e9d-c444-48ae-9fa5-b408eb896bdf_zkff6pj1bgdp2\LocalState\TodoList\"+Title.Text+".xml");
        //    ConfirmFlyout.Hide();
        //    Frame.Navigate(typeof(EventList));
        //}

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ConfirmFlyout.Hide();
        }

        private void Not_yet_Click(object sender, RoutedEventArgs e)
        {
            DoneConfirmFly.Hide();
        }
    }
}