namespace MusicBingo.Domain;

public static class PlaylistExtensions
{
    public static Song GetRandomSong(this Playlist playlist)
    {
        return playlist.Songs[new Random().Next(0, playlist.Songs.Count)];
    }
}