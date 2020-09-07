using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoalAppV2.Models;
using GoalAppV2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        
        public IActionResult Create()
        {
            NotesListViewModel notesListViewModel = new NotesListViewModel();
            return View(notesListViewModel);
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            Note newNote = new Note();
            var userName = User.Claims.First(c => c.Type == "FullName").Value;

            newNote.Title = note.Title;
            newNote.Description = note.Description;
            newNote.CreatedBy = userName;

            _noteRepository.CreateNote(newNote);

            return RedirectToAction("List");
        }

        [Route("[controller]/Edit/{id}")]
        public IActionResult Edit(int id)
        {
            NotesListViewModel notesListViewModel = new NotesListViewModel();
            var currentNote = _noteRepository.GetNoteById(id);
            notesListViewModel.Note = currentNote;

            return View(notesListViewModel);
        }

        [HttpPost]
        public IActionResult Update(Note note)
        {
            _noteRepository.UpdateNote(note);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var currentNote = _noteRepository.GetNoteById(id);

            _noteRepository.Delete(currentNote);
            return RedirectToAction("List");
        }
    }
}
