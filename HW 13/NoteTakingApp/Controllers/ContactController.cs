using Microsoft.AspNetCore.Mvc;
using NoteTakingApp.Models;

namespace NoteTakingApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            List<Contact> contacts = GetSampleContacts();
            return View(contacts);
        }
        private List<Contact> GetSampleContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact(
                    "Alice Smith",
                    "555-0101",
                    "alice.smith@example.com",
                    "Lead Developer on the P project.",
                    "555-0102"
                ),
                new Contact(
                    "Bob Johnson",
                    "555-0103",
                    "bob.j@example.com",
                    "Marketing specialist. Met at the 2023 tech conference."
                ),
                new Contact(
                    "Charlie Brown",
                    "555-0104",
                    "charlie.brown@example.com",
                    "Client from the 'Innovate' account.",
                    "555-0105"
                )
            };
            return contacts;
        }
    }
}
