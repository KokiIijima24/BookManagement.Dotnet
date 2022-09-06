using BookManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Web.Pages
{
    public class EditModel : PageModel
    {
        private readonly BookManagement.Web.BookManagementDbContext _context;

        public EditModel(BookManagement.Web.BookManagementDbContext context)
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
            Register = register;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisterExists(Register.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RegisterExists(int id)
        {
            return (_context.Register?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
