using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public DetailsModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public MyMovie MyMovie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyMovie = await _context.MyMovie.SingleOrDefaultAsync(m => m.ID == id);

            if (MyMovie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}