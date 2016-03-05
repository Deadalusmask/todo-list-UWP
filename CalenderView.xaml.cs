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

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace todo_list
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CalenderView : Page
    {
        public CalenderView()
        {
            this.InitializeComponent();
        }


        private void maincalender_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            var selectedDates = sender.SelectedDates.Select(p =>p.Date.Year.ToString()+"/"+ p.Date.Month.ToString() + "/" + p.Date.Day.ToString()).ToArray();
            var values = string.Join(", ", selectedDates);
            ThisDay.Text = values;
            MyFlyout.ShowAt(FlyOutPlace);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MyFlyout.Hide();
        }

        private void ViewTodayButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EventList));
        }

        private void AddNewEventButton_Click(object sender, RoutedEventArgs e)
        {
            var parameters = new TextBlock();
            parameters.Text = ThisDay.Text;
            Frame.Navigate(typeof(AddPage),parameters);
        }


    }
}
