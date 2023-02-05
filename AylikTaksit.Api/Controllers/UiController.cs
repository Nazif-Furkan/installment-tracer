using Microsoft.AspNetCore.Mvc;

namespace AylikTaksit.Api.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
public class UiController: ControllerBase
{
    public IActionResult Get()
    {
        
        return Content(System.IO.File.ReadAllText("index.html"),"text/html");
    }
}