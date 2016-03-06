using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.Data.Xml.Dom;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using todo_list.Model;
using Windows.Storage;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace todo_list
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>

    public sealed partial class AddPage : Page
    {
        public Event ThisEvent;

        public AddPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter != null)
            {
                var DateText = (TextBlock)e.Parameter;
                DateTextBlock.Text = DateText.Text;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
                if (Title.Text == "" || Desc.Text == "") 
                {
                    await new MessageDialog("Title or Desc couldn't be empty").ShowAsync();
                }

                StorageFolder storage = await ApplicationData.Current.LocalFolder.GetFolderAsync("TodoList");
                XmlDocument _doc = new XmlDocument();
                XmlElement _item = _doc.CreateElement(Title.Text);
                _item.SetAttribute("date", DateTextBlock.Text);
                _item.SetAttribute("describe", Desc.Text);
                _doc.AppendChild(_item);
                StorageFile file = await storage.CreateFileAsync(Title.Text + ".xml", CreationCollisionOption.ReplaceExisting);
                await _doc.SaveToFileAsync(file);
                Frame.GoBack();




        }
    }
}
