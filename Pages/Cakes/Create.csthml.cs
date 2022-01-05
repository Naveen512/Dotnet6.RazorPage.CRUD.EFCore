using Dot6.Razor.Crud.Demo.Data;
using Dot6.Razor.Crud.Demo.Data.Entities;
using Dot6.Razor.Crud.Demo.Vms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Dot6.Razor.Crud.Demo.Pages.Cakes;

public class CreateModel : PageModel
{
    private readonly MyWorldDbContext _myWorldDbContext;
    public CreateModel(MyWorldDbContext myWorldDbContext)
    {
        _myWorldDbContext = myWorldDbContext;
    }
    [BindProperty]
    public CakeVm CakeVm { get; set; }
    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var entry = _myWorldDbContext.Add(new Cake());
        entry.CurrentValues.SetValues(CakeVm);
        await _myWorldDbContext.SaveChangesAsync();
        return Redirect("home");
    }
}