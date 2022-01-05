using Dot6.Razor.Crud.Demo.Data;
using Dot6.Razor.Crud.Demo.Data.Entities;
using Dot6.Razor.Crud.Demo.Vms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Dot6.Razor.Crud.Demo.Pages.Cakes;

public class EditModel : PageModel
{
    private MyWorldDbContext _myWorldDbContext;
    public EditModel(MyWorldDbContext myWorldDbContext)
    {
        _myWorldDbContext = myWorldDbContext;
    }

    [BindProperty]
    public CakeVm? CakeVm { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        CakeVm = await _myWorldDbContext.Cake
                .Where(_ => _.Id == id)
                .Select(_ =>
                new CakeVm
                {
                    Description = _.Description,
                    Id = _.Id,
                    Name = _.Name,
                    Price = _.Price
                }).FirstOrDefaultAsync();

        if (CakeVm == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var cakeToUpdate = await _myWorldDbContext.Cake.FindAsync(id);

        if (cakeToUpdate == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync<Cake>(
            cakeToUpdate,
            "CakeVm",
            c => c.Name, c => c.Description, c => c.Price
        ))
        {
            await _myWorldDbContext.SaveChangesAsync();
            return Redirect("home");
        }

        return Page();
    }
}