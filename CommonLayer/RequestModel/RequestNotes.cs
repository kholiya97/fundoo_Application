using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModel
{
    public class RequestNotes
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime ReminderOn { get; set; }
        public string Color { get; set; }
        public bool IsArchive { get; set; }
        public bool IsTrash { get; set; }
        public bool IsPin { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }

    }
}
