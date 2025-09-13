using Microsoft.AspNetCore.Mvc;

namespace MasterNet9.WebApi.Controllers;

[ApiController]
[Route("Demo")]
public class DemoController : ControllerBase
{
    [HttpGet("getstring")]
    public string GetNombre()
    {
        return "medicode.com.br";
    }
}
