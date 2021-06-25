using BusinessLayer.Interface;
using CommonLayer.DataBase;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{

    public class NoteBL : INoteBL
    {
        INoteRL noteRl;
        public NoteBL(INoteRL noteRl)
        {
            this.noteRl = noteRl;
        }
        public IEnumerable<Note> GetAll()
        {
            return this.noteRl.GetAll();
        }
        public Note GetNoteById(int id)
        {
            return this.noteRl.GetNoteById(id);
        }
        public Note AddNotes(Note Note)
        {
            this.noteRl.AddNotes(Note);
            return Note;
        }
        public void DeleteNote(int id)
        {
            this.noteRl.DeleteNote(id);
        }
        public void UpdateNotes(Note note)
        {
            this.noteRl.UpdateNotes(note);
        }
        public void UpdatePin(Note note)
        {
            this.noteRl.UpdatePin(note);
        }
        public void UpdateReminder(Note note)
        {
            this.noteRl.UpdateReminder(note);
        }
        public void UpdateColour(Note note)
        {
            this.noteRl.UpdateColour(note);
        }
        public void UpdateTrash(Note note)
        {
            this.noteRl.UpdateTrash(note);
        }
        public void UpdateArchive(Note note)
        {
            this.noteRl.UpdateArchive(note);
        }
    }
}