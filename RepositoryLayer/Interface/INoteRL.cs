using CommonLayer.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        IEnumerable<Note> GetAll();
        Note GetNoteById(int id);
        Note AddNotes(Note note);
        void DeleteNote(int id);
        void UpdateNotes(Note note);
        void UpdatePin(Note note);
        void UpdateReminder(Note note);
        void UpdateColour(Note note);
        void UpdateTrash(Note note);
        void UpdateArchive(Note note);
    }
}
