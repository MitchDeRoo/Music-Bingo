using MusicBingo.Domain;

namespace MusicBingo.Tests;

public class TestDataBuilder
{
    public Playlist BuildPlaylist(string name = "Aussie Pub Rock Songs", List<(string Name, string Artist)>? songInfo = null)
    {
        songInfo ??= GetSongData(); 
        return new Playlist(Guid.NewGuid(), name, BuildSongs(songInfo));
    }

    private List<Song> BuildSongs(List<(string Name, string Artist)> songInfo)
    {
        return songInfo.Select((info, index) => new Song(info.Name, info.Artist, (index + 1).ToString())).ToList();
    }

    private List<(string Name, string Artist)> GetSongData()
    {
        return
        [
            ("Khe Sanh", "Cold Chisel"),
            ("Working Class Man", "Jimmy Barnes"),
            ("Eagle Rock", "Daddy Cool"),
            ("Run to Paradise", "Choirboys"),
            ("Am I Ever Gonna See Your Face Again", "The Angels"),
            ("Take a Long Line", "The Angels"),
            ("Flame Trees", "Cold Chisel"),
            ("The Boys Light Up", "Australian Crawl"),
            ("April Sun in Cuba", "Dragon"),
            ("No Secrets", "The Angels"),
            ("Cheap Wine", "Cold Chisel"),
            ("Bow River", "Cold Chisel"),
            ("It's a Long Way to the Top", "AC/DC"),
            ("Tucker's Daughter", "Ian Moss"),
            ("Most People I Know Think That I'm Crazy", "Billy Thorpe & The Aztecs"),
            ("Evie (Part 1)", "Stevie Wright"),
            ("Good Times", "INXS & Jimmy Barnes"),
            ("Forever Now", "Cold Chisel"),
            ("Horror Movie", "Skyhooks"),
            ("Don't Change", "INXS"),
            ("My Baby", "Cold Chisel"),
            ("Solid Rock", "Goanna"),
            ("Beds Are Burning", "Midnight Oil"),
            ("Power and the Passion", "Midnight Oil")
        ];
    }
}