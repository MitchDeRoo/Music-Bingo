namespace MusicBingo.Domain;

public record Playlist(Guid Guid, string Name, List<Song> Songs);