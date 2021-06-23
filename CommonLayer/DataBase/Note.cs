using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.DataBase
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsPin { get; set; }
        public bool IsTrash { get; set; }
        public bool IsArchive { get; set; }  
        public DateTime ReminderOn { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
    }
}
