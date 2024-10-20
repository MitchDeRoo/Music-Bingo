using Microsoft.AspNetCore.Mvc;

namespace MusicBingo.Playlists;

[Route("api/playlists")]
[ApiController]
public class PlaylistController(IPlaylistRepository repository) : ControllerBase
{
    [HttpPost]
    public IActionResult CreatePlaylist([FromBody] string playlistName)
    {
        var playlist = repository.Create(playlistName);
        return Ok(playlist);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return repository.GetById(id).Match<IActionResult>(Ok, () => NotFound($"No playlist found with id {id}"));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(repository.GetAll());
    }
}