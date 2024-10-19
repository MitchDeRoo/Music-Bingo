using Microsoft.AspNetCore.Mvc;

namespace MusicBingo;

[Route("api/playlists")]
[ApiController]
public class PlaylistController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello world!");
    }
}