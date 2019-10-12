using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TripTracker.BackService.Models;
using TripTrackerUI.Data;

namespace TripTrackerUI.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly TripTrackerUI.Data.ApplicationDbContext _context;

        public CreateModel(TripTrackerUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trip.Add(Trip);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}