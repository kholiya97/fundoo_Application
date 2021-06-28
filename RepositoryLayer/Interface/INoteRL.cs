using CommonLayer.DataBase;
using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        IEnumerable<Note> GetAll();
        Note GetNoteById(int id);
        void AddNotes(RequestNotes note);
        void DeleteNote(int id);
        void UpdateNotes(Note note);
        void UpdatePin(Note note);
        void UpdateReminder(Note note);
        void UpdateColour(Note note);
        void UpdateTrash(Note note);
        void UpdateArchive(Note note);
    }
}
