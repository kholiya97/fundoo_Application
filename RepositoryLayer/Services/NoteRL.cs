using CommonLayer.DataBase;
using RepositoryLayer.Interface;
using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;


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
        //public Note AddNotes(Note note)
        //{
        //    _userDbContext.Notes.Add(note);
        //    _userDbContext.SaveChanges();
        //    return note;
        //}
        public void AddNotes(RequestNotes notes)
        {
            try
            {
                var user = _userDbContext.Users.FirstOrDefault(u => u.UserId == notes.UserId);
                if (user != null)
                {
                    Note note = new Note();
                    note.Title = notes.Title;
                    note.Text = notes.Text;
                    note.ReminderOn = notes.ReminderOn;
                    note.Color = notes.Color;
                    note.IsArchive = notes.IsArchive;
                    note.IsTrash = notes.IsTrash;
                    note.IsPin = notes.IsPin;
                    note.UserId = notes.UserId;
                    _userDbContext.Notes.Add(note);
                    _userDbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("User id doesn't Exist.");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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
        public void UpdatePin(Note note)
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
                    result.IsPin = note.IsPin;
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
        public void UpdateColour(Note note)
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
                    result.Color = note.Color;
                    _userDbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateTrash(Note note)
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
                    result.IsTrash = note.IsTrash;
                    _userDbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateArchive(Note note)
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
                    result.IsArchive = note.IsArchive;
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