using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalAppV2.Models
{
    public class MockNoteRepository : INoteRepository
    {
        public IEnumerable<Note> AllNotes()
        {
            return new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Title = "The first mock note",
                    Description = "A quick mocked note to test the concept"
                },

                new Note
                {
                    Id = 2,
                    Title = "The second test note",
                    Description = "Lorem ipsum note body for note 2"
                }
            };
        }

        public Note GetNoteById(int noteId)
        {
            return AllNotes().FirstOrDefault(n => n.Id == noteId);
        }

    }
}
