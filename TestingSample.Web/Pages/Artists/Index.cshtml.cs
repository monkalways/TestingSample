using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestingSample.Web.Data;
using TestingSample.Web.Models;

namespace TestingSample.Web.Pages.Artists
{
    public class IndexModel : PageModel
    {
        private readonly TestingSample.Web.Data.MusicCatalogContext _context;

        public IndexModel(TestingSample.Web.Data.MusicCatalogContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; }

        public async Task OnGetAsync()
        {
            Artist = await _context.Artists.ToListAsync();
        }
    }
}
