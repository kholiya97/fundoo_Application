using CommonLayer.DataBase;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        private UserContext _userDbContext;
        public NoteRL(UserContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public IEnumerable<Note> GetAll()
        {
            return _userDbContext.Notes.ToList();
        }
        public Note GetNoteById(int id)
        {
            return _userDbContext.Notes
                  .FirstOrDefault(e => e.UserId == id);
        }
        public Note AddNotes(Note note)
        {
            _userDbContext.Notes.Add(note);
            _userDbContext.SaveChanges();
            return note;
        }
        public void DeleteNote(int id)
        {
            var result = _userDbContext.Notes.FirstOrDefault(e => e.NoteID == id);
            if (result == null)
            {
                throw new Exception("No Note Exist");
            }
            else
            {
                _userDbContext.Notes.Remove(result);
                _userDbContext.SaveChanges();

            }
        }
        public void UpdateNotes(Note note)
        {
            try
            {
                var result = _userDbContext.Notes.FirstOrDefault(n => n.NoteID == note.NoteID);
                if (result == null)
                {
                    throw new Exception("No such Notes Exist");
                }
                else
                {
                    result.Title = note.Title;
                    result.Text = note.Text;
                    _userDbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdatePin(int id, bool IsPin)
        {
            try
            {
                var result = _userDbContext.Notes.FirstOrDefault(n => n.NoteID == id);
                if (result == null)
                {
                    throw new Exception("No such Pin Exist");
                }
                else
                {
                    result.IsPin = IsPin;
                    _userDbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateReminder(Note note)
        {
            try
            {
                var result = _userDbContext.Notes.FirstOrDefault(n => n.NoteID == note.NoteID);
                if (result == null)
                {
                    throw new Exception("No such Pin Exist");
                }
                else
                {
                    result.ReminderOn = note.ReminderOn;
                    _userDbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}