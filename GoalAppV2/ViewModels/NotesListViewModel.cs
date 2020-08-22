using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoalAppV2.Models;

namespace GoalAppV2.ViewModels
{
    public class NotesListViewModel
    {
        public IEnumerable<Note> Notes { get; set; }
    }
}
