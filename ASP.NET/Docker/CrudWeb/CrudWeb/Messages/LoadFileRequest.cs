using Microsoft.AspNetCore.Mvc;

namespace CrudWeb.Messages;

public class LoadFileRequest
{
    [BindProperty(Name = "formFile")] 
    public IFormFile File { get; set; }
}