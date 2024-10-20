using MusicBingo.BingoCards;

namespace MusicBingo.Writers;

public interface IBingoDocumentWriter
{
    MemoryStream WriteToDocument(List<BingoCard> cards);
}