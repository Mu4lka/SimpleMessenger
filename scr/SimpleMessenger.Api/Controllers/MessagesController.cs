using Infrastucture.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SimpleMessenger.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class MessagesController(IMessagesService service)
{
    [HttpPost]
    public Task<IActionResult> 
}
