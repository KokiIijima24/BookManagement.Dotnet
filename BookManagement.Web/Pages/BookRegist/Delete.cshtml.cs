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
    public class DeleteModel : PageModel
    {
        private readonly BookManagement.Web.BooksDbContext _context;

        public DeleteModel(BookManagement.Web.BooksDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Register Register { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Register == null)
            {
                return NotFound();
            }

            var register = await _context.Register.FirstOrDefaultAsync(m => m.Id == id);

            if (register == null)
            {
                return NotFound();
            }
            else 
            {
                Register = register;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Register == null)
            {
                return NotFound();
            }
            var register = await _context.Register.FindAsync(id);

            if (register != null)
            {
                Register = register;
                _context.Register.Remove(Register);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
