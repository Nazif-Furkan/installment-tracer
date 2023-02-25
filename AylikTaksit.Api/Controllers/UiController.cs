using Microsoft.AspNetCore.Mvc;

namespace AylikTaksit.Api.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
[Route("[controller]")]
public class UiController: ControllerBase
{
    public IActionResult Get()
    {
        var dolar = Helper.DovizGoster().Dolar;
        return Content(System.IO.File.ReadAllText("index.html").Replace("{dolar}",$"{dolar}"),"text/html");
    }
}