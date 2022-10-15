using Microsoft.AspNetCore.Mvc;

namespace WebApplicationApp.Controllers;

[Route("test")]
public class TestController : Controller
{
    [HttpGet]
    public ActionResult<ResponseDto> Get()
    {
        return new ResponseDto() { Text = "test" };
    }

    public class ResponseDto
    {
        public string Text { get; set; }
    }
}