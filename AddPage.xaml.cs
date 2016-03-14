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
                DatePicker.Visibility = Visibility.Collapsed;
                TimePiacer.Visibility = Visibility.Collapsed;
            }
            else
            {
                DateTextBlock.Visibility = Visibility.Collapsed;

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
                    return;
                }

            StorageFolder storage = await ApplicationData.Current.LocalFolder.GetFolderAsync("TodoList");
            XmlDocument _doc = new XmlDocument();
            XmlElement _item = _doc.CreateElement(Title.Text);
            string datetime;

            if(DateTextBlock.Text!="")
            {
                _item.SetAttribute("date", DateTextBlock.Text);

            }
            else
            {
                TextBlock aaa = new TextBlock();
                aaa.Visibility = Visibility.Collapsed;
                aaa.Text=DatePicker.Date.ToString();
                if (aaa.Text!="")
                {
                    datetime = DatePicker.Date.Value.Year + "年" + DatePicker.Date.Value.Month + "月" + DatePicker.Date.Value.Day + "日" + TimePiacer.Time.Hours + "时" + TimePiacer.Time.Minutes + "分";
                    _item.SetAttribute("date", datetime);
                }
                else
                {
                    await new MessageDialog("Please select a date").ShowAsync();
                    return;
                }
            }

            _item.SetAttribute("describe", Desc.Text);
            _doc.AppendChild(_item);
            StorageFile file = await storage.CreateFileAsync(Title.Text + ".xml", CreationCollisionOption.ReplaceExisting);
            await _doc.SaveToFileAsync(file);
            Frame.GoBack();




        }

        private void DatePicker_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            var selectedDate = sender.Date;
        }

        private void TimePiacer_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            var selectedTime = TimePiacer.Time;
        }
    }
}
