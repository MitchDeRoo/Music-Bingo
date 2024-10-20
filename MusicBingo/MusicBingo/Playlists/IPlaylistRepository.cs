using MusicBingo.Domain;
using Optional;

namespace MusicBingo.Playlists;

public interface IPlaylistRepository
{
    Playlist Create(string playlistName);
    Option<Playlist> GetById(Guid guid);
    IEnumerable<Playlist> GetAll();
}