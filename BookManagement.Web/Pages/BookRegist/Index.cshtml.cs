using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookManagement.Web;
using BookManagement.Web.Models;

namespace BookManagement.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookManagement.Web.BooksDbContext _context;

        public IndexModel(BookManagement.Web.BooksDbContext context)
        {
            _context = context;
        }

        public IList<Register> Register { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Register != null)
            {
                Register = await _context.Register.ToListAsync();
            }
        }
    }
}
