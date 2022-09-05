using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BreakfastWebAPI.Controllers
{
    public class ErrorController : ControllerBase
    {
        //[Route("/error")]
        public IActionResult Error()
        {
            return Problem();
        }
    }
}
