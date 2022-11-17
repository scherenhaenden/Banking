using BankingDataAccess.Core.Configuration;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SmallConsoleView.Pages;

public class GridView : PageModel
{
    private readonly IUnitOfWorkV2 _unitOfWorkV2;

    public GridView(IUnitOfWorkV2 unitOfWorkV2)
    {
        _unitOfWorkV2 = unitOfWorkV2;
    }
    
   
    public List<string> Tables { get; set; }
    public List<string> Columnes { get; set; }
    
    public bool IsTableSelected { get; set; } 

    // Get all entities from the unit of work
    public void GetAllEntities()
    {
        // Get all properties from object
        var properties = _unitOfWorkV2.GetType().GetProperties();
        
        // Make a list of the name of each property
        Tables = new List<string>();
        Tables.Add("");
        Tables.AddRange(properties.Select(p => p.Name).ToList());
        
        
    }

    public IActionResult OnTableSelected(ChangeEventArgs arg)
    {
        IsTableSelected = true;
        var nameOfTable = arg.Value.ToString();

        var value = _unitOfWorkV2?.GetType()?.GetProperty(nameOfTable)?.GetValue(_unitOfWorkV2);
        
        var properties = _unitOfWorkV2.GetType().GetProperties();
        
        Columnes = properties.Select(p => p.Name).ToList();

        //return value != null ? Page() : NotFound();
        
        
        
        return Page();

    }


    public void OnGet()
    {
        GetAllEntities();
    }
}