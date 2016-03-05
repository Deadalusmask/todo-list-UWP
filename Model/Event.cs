using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_list.Model
{
    public class Event
    {
        public int EventId { get; set; }
        public int Date { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
    }

    public class EventManager
    {
        public static List<Event> GetEvents()
        {
            var events = new List<Event>();

            events.Add(new Event { EventId = 1, Title = "Vulpate", Desc = "Futurum" });
            events.Add(new Event { EventId = 2, Title = "Mazim", Desc = "Sequiter Que" });
            events.Add(new Event { EventId = 3, Title = "Elit", Desc = "Tempor" });
            events.Add(new Event { EventId = 4, Title = "Etiam", Desc = "Option" });
            events.Add(new Event { EventId = 5, Title = "Feugait Eros Libex", Desc = "Accumsan" });
            events.Add(new Event { EventId = 6, Title = "Nonummy Erat", Desc = "Legunt Xaepius" });
            events.Add(new Event { EventId = 7, Title = "Nostrud", Desc = "Eleifend" });
            events.Add(new Event { EventId = 8, Title = "Per Modo", Desc = "Vero Tation" });
            events.Add(new Event { EventId = 9, Title = "Suscipit Ad", Desc = "Jack Tibbles" });
            events.Add(new Event { EventId = 10, Title = "Decima", Desc = "Tuffy Tibbles" });
            events.Add(new Event { EventId = 11, Title = "Erat", Desc = "Volupat" });
            events.Add(new Event { EventId = 12, Title = "Consequat", Desc = "Est Possim" });
            events.Add(new Event { EventId = 13, Title = "Aliquip", Desc = "Magna" });

            return events;
        }
    }
}