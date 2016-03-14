using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace todo_list.Model
{
    public class Event
    {
        public int EventId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool status { get; set; }
    }
}