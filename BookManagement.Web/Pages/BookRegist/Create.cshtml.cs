using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookManagement.Web;
using BookManagement.Web.Models;

namespace BookManagement.Web.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BookManagement.Web.BookManagementDbContext _context;

        public CreateModel(BookManagement.Web.BookManagementDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Register Register { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Register == null || Register == null)
            {
                return Page();
            }

            _context.Register.Add(Register);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
