using FluentAssertions;
using MusicBingo.BingoCards;
using MusicBingo.Writers;

namespace MusicBingo.Tests;

[TestFixture]
public class BingoDocumentWriterShould
{
    [Test]
    public void Return_MemoryStream()
    {
        var writer = new BingoDocumentWriter();
        var cards = new List<BingoCard>
        {
            new()
            {
                Title = "Example Song",
                Cells =
                [
                    ["B", "I", "N", "G", "O"],
                    ["Song A", "Song B", "Song C", "", "Song D"],
                    ["Song E", "Song F", "Song G", "Song H", "Song I"],
                    ["Song J", "Song K", "Free Space", "Song L", "Song M"],
                    ["Song N", "Song O", "Song P", "Song Q", "Song R"],
                    ["Song S", "Song T", "Song U", "Song V", "Song W"]
                ]
            }
        };

        var memoryStream = writer.WriteToDocument(cards);

        memoryStream.Should().BeOfType<MemoryStream>();
        memoryStream.Length.Should().BeGreaterThan(0);
    }
}