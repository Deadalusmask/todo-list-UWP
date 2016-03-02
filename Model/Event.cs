using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_list.Model
{
    public class Event
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
    }

    public class EventManager
    {
        public static List<Event> GetEvents()
        {
            var events = new List<Event>();

            events.Add(new Event { BookId = 1, Title = "Vulpate", Author = "Futurum" });
            events.Add(new Event { BookId = 2, Title = "Mazim", Author = "Sequiter Que" });
            events.Add(new Event { BookId = 3, Title = "Elit", Author = "Tempor" });
            events.Add(new Event { BookId = 4, Title = "Etiam", Author = "Option" });
            events.Add(new Event { BookId = 5, Title = "Feugait Eros Libex", Author = "Accumsan" });
            events.Add(new Event { BookId = 6, Title = "Nonummy Erat", Author = "Legunt Xaepius" });
            events.Add(new Event { BookId = 7, Title = "Nostrud", Author = "Eleifend" });
            events.Add(new Event { BookId = 8, Title = "Per Modo", Author = "Vero Tation" });
            events.Add(new Event { BookId = 9, Title = "Suscipit Ad", Author = "Jack Tibbles" });
            events.Add(new Event { BookId = 10, Title = "Decima", Author = "Tuffy Tibbles" });
            events.Add(new Event { BookId = 11, Title = "Erat", Author = "Volupat" });
            events.Add(new Event { BookId = 12, Title = "Consequat", Author = "Est Possim" });
            events.Add(new Event { BookId = 13, Title = "Aliquip", Author = "Magna" });

            return events;
        }
    }
}