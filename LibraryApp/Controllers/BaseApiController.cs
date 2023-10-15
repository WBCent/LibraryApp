using Microsoft.AspNetCore.Mvc;

// It is better to create your own base controller than using the main one.
namespace LibraryApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{  
    
}