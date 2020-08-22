using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoalAppV2.Models;
using GoalAppV2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoalAppV2.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IActionResult List()
        {
            ViewBag.Title = "Welcome to the Goal App";
            NotesListViewModel notesListViewModel = new NotesListViewModel();
            notesListViewModel.Notes = _noteRepository.AllNotes();
            return View(notesListViewModel);
        }
    }
}
