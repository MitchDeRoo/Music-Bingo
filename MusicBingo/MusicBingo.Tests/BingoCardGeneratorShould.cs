using FluentAssertions;
using MusicBingo.BingoCards;
using MusicBingo.Domain;

namespace MusicBingo.Tests;

[TestFixture]
public class BingoCardGeneratorShould
{
    private readonly TestDataBuilder _builder = new();
    private BingoCardGenerator _generator;
    private Playlist _playlist;

    [SetUp]
    public void Setup()
    {
        _generator = new BingoCardGenerator();
        _playlist = _builder.BuildPlaylist();
    }

    [Test]
    public void Return_Correct_Number_Of_Bingo_Cards()
    {
        var cards = _generator.Generate(_playlist, 3);

        cards.Count.Should().Be(3);
    }

    [Test]
    public void Generate_Bingo_Cards_Correctly()
    {
        var cards = _generator.Generate(_playlist, 3);

        foreach (var card in cards)
        {
            // Have correct title
            card.Title.Should().Be(_playlist.Name);
            
            // Have the correct dimensions
            card.Cells.Length.Should().Be(6);
            card.Cells[0].Length.Should().Be(5);

            // Have the first row be filled with BINGO letters
            card.Cells[0][0].Should().Be("B");
            card.Cells[0][1].Should().Be("I");
            card.Cells[0][2].Should().Be("N");
            card.Cells[0][3].Should().Be("G");
            card.Cells[0][4].Should().Be("O");

            // Fill middle cell with Free Space
            card.Cells[3][2].Should().Be("Free Space");
        }
    }
}