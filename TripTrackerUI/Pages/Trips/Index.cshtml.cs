using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TripTracker.BackService.Models;
using TripTrackerUI.Data;

namespace TripTrackerUI.Pages.Trips
{
    public class IndexModel : PageModel
    {
        private readonly TripTrackerUI.Data.ApplicationDbContext _context;

        public IndexModel(TripTrackerUI.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Trip> Trip { get;set; }

        public async Task OnGetAsync()
        {
            Trip = await _context.Trip.ToListAsync();
        }
    }
}
