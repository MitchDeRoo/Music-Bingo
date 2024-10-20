using MusicBingo.Domain;

namespace MusicBingo.BingoCards;

public interface IBingoCardGenerator
{
    List<BingoCard> Generate(Playlist playlist, int numberOfCards);
}