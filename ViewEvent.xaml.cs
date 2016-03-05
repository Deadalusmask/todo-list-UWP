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
            Title.Text = itemName;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
