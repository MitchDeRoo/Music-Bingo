using MusicBingo.Domain;
using Optional;

namespace MusicBingo.Playlists;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly Dictionary<Guid, Playlist> _playlists = new();

    public Playlist Create(string playlistName)
    {
        var playlist = new Playlist(Guid.NewGuid(), playlistName, []);
        _playlists.Add(playlist.Guid, playlist);
        return playlist;
    }

    public Option<Playlist> GetById(Guid guid)
    {
        return _playlists.TryGetValue(guid, out var playlist) ? Option.Some(playlist) : Option.None<Playlist>();
    }

    public IEnumerable<Playlist> GetAll()
    {
        return _playlists.Values.ToList();
    }
}