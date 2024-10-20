using MusicBingo.Domain;
using Optional;

namespace MusicBingo.Playlists;

public class TestingPlaylistRepository : IPlaylistRepository
{
    private readonly Dictionary<Guid, Playlist> _playlists = new();

    public TestingPlaylistRepository()
    {
        var guid = Guid.NewGuid();
        _playlists.Add(guid, new Playlist(guid, "Aussie Pub Rock", [
            new Song("Khe Sanh", "Cold Chisel", "1"),
            new Song("Working Class Man", "Jimmy Barnes", "2"),
            new Song("Eagle Rock", "Daddy Cool", "3"),
            new Song("Run to Paradise", "Choirboys", "4"),
            new Song("Am I Ever Gonna See Your Face Again", "The Angels", "5"),
            new Song("Take a Long Line", "The Angels", "6"),
            new Song("Flame Trees", "Cold Chisel", "7"),
            new Song("The Boys Light Up", "Australian Crawl", "8"),
            new Song("April Sun in Cuba", "Dragon", "9"),
            new Song("No Secrets", "The Angels", "10"),
            new Song("Cheap Wine", "Cold Chisel", "11"),
            new Song("Bow River", "Cold Chisel", "12"),
            new Song("It's a Long Way to the Top", "AC/DC", "13"),
            new Song("Tucker's Daughter", "Ian Moss", "14"),
            new Song("Most People I Know Think That I'm Crazy", "Billy Thorpe & The Aztecs", "15"),
            new Song("Evie (Part 1)", "Stevie Wright", "16"),
            new Song("Good Times", "INXS & Jimmy Barnes", "17"),
            new Song("Forever Now", "Cold Chisel", "18"),
            new Song("Horror Movie", "Skyhooks", "19"),
            new Song("Don't Change", "INXS", "20"),
            new Song("My Baby", "Cold Chisel", "21"),
            new Song("Solid Rock", "Goanna", "22"),
            new Song("Beds Are Burning", "Midnight Oil", "23"),
            new Song("Power and the Passion", "Midnight Oil", "24"),
            new Song("Better", "The Screaming Jets", "25")
        ]));
    }

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