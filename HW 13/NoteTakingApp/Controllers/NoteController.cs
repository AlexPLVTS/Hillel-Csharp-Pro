using Microsoft.AspNetCore.Mvc;
using NoteTakingApp.Models;

namespace NoteTakingApp.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            var notes = GetSampleNotes();
            return View(notes);
        }
        private List<Note> GetSampleNotes()
        {
            var notes = new List<Note>
            {
                new Note(
                    "Meeting Recap",
                    "Discussed further plans for project",
                    new List<string> { "work", "plans", "meeting" }
                ),
                new Note(
                    "Shopping List",
                    "- Milk\n- Bread\n- Eggs\n- Coffee",
                    new List<string> { "personal", "groceries" }
                ),
                new Note(
                    "Cooking practice",
                    "Make chocolate cake",
                    new List<string> { "cooking", "desert" }
                )
            };
            return notes;
        }
    }
}
