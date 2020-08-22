using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalAppV2.Models
{
    public interface INoteRepository
    {
        IEnumerable<Note> AllNotes();
        Note GetNoteById(int noteId);
    }
}
