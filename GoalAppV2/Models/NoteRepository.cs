using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GoalAppV2.Models
{
    public class NoteRepository : INoteRepository
    {

        private readonly AppDbContext _appDbContext;

        public NoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Note> AllNotes()
        {
            return _appDbContext.Notes;
        }

        public Note GetNoteById(int noteId)
        {
            return _appDbContext.Notes.FirstOrDefault(n => n.Id == noteId);
        }

        public void CreateNote(Note note)
        {
            _appDbContext.Notes.Add(note);
            _appDbContext.SaveChanges();
        }

        public void UpdateNote(Note note)
        {
            _appDbContext.Notes.Update(note);
            _appDbContext.SaveChanges();
        }

        public void Delete(Note note)
        {
            _appDbContext.Notes.Remove(note);
            _appDbContext.SaveChanges();
        }
    }
}
