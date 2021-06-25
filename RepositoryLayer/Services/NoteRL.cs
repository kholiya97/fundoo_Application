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
    }
}