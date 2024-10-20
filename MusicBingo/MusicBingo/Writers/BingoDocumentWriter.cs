using MusicBingo.BingoCards;
using Xceed.Words.NET;

namespace MusicBingo.Writers;

public class BingoDocumentWriter : IBingoDocumentWriter
{
    public MemoryStream WriteToDocument(List<BingoCard> cards)
    {
        var memoryStream = new MemoryStream();

        using (var document = DocX.Create(memoryStream))
        {
            foreach (var bingoCard in cards)
            {
                document.InsertParagraph(bingoCard.Title).FontSize(16).Bold().Spacing(10);
                var table = document.InsertTable(6, 5);

                for (int row = 0; row < 6; row++)
                {
                    for (int col = 0; col < 5; col++)
                    {
                        table.Rows[row].Cells[col].Paragraphs[0].Append(bingoCard.Cells[row][col]);
                    }
                }
                document.InsertParagraph().SpacingAfter(10);
            }
            document.Save();
        }

        memoryStream.Position = 0;
        return memoryStream;
    }
}