using Microsoft.AspNetCore.Mvc;
using MusicBingo.Domain;
using MusicBingo.Playlists;
using MusicBingo.Writers;

namespace MusicBingo.BingoCards;

[Route("api/bingo-cards")]
[ApiController]
public class BingoCardController(IPlaylistRepository repository, IBingoCardGenerator generator, IBingoDocumentWriter writer) : ControllerBase
{
    [HttpPost]
    public IActionResult GenerateBingoCards(Guid playlistId, [FromBody] int numberOfCards)
    {
        if (numberOfCards < 1)
        {
            return BadRequest("You cannot generate zero or less cards");
        }

        return repository.GetById(playlistId).Match(
            playlist => Handle(playlist, numberOfCards), 
            () => NotFound($"No playlist found with id {playlistId}")
        );
    }

    private IActionResult Handle(Playlist playlist, int numberOfCards)
    {
        if (playlist.Songs.Count == 0)
        {
            return BadRequest("No songs found in the playlist");
        }

        if (playlist.Songs.Count < 25)
        {
            return BadRequest("Playlist must contain at least 25 songs");
        }

        var bingoSheets = generator.Generate(playlist, numberOfCards);

        using var memoryStream = writer.WriteToDocument(bingoSheets);

        var fileName = $"{playlist.Name}_BingoSheets.docx"; 
        return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
    }
}