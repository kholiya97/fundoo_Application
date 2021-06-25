using CommonLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        IEnumerable<Note> GetAll();
        Note GetNoteById(int id);
        Note AddNotes(Note note);
        void DeleteNote(int id);
        void UpdateNotes(Note note);
    }
}
