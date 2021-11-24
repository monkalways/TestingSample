using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestingSample.Web.Data;
using TestingSample.Web.Models;

namespace TestingSample.Web.Pages.Artists
{
    public class CreateModel : PageModel
    {
        private readonly TestingSample.Web.Data.MusicCatalogContext _context;

        public CreateModel(TestingSample.Web.Data.MusicCatalogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Artist Artist { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Artists.Add(Artist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
