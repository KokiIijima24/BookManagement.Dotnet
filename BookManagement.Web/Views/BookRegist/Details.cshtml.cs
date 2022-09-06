using BookManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Web.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly BookManagement.Web.BookManagementDbContext _context;

        public DetailsModel(BookManagement.Web.BookManagementDbContext context)
        {
            _context = context;
        }

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
    }
}
