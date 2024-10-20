using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MusicBingo.BingoCards;
using MusicBingo.Domain;
using MusicBingo.Playlists;
using MusicBingo.Writers;
using NSubstitute;
using Optional;

namespace MusicBingo.Tests;

[TestFixture]
public class BingoCardControllerShould
{
    private readonly TestDataBuilder _testDataBuilder = new();

    private IPlaylistRepository _repository;
    private IBingoDocumentWriter _writer;
    private IBingoCardGenerator _generator;
    private BingoCardController _controller;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<IPlaylistRepository>();
        _writer = Substitute.For<IBingoDocumentWriter>();
        _generator = Substitute.For<IBingoCardGenerator>();

        _controller = new BingoCardController(_repository, _generator, _writer);
    }
    
    [Test]
    public void Return_NotFound_If_Nonexistent_Playlist_Given()
    {
        var id = Guid.NewGuid();
        var result = _controller.GenerateBingoCards(id, 3) as ObjectResult;

        result.Should().BeOfType<NotFoundObjectResult>();
        result.Value.Should().Be($"No playlist found with id {id}");
    }

    [Test]
    public void Return_BadRequest_If_NumberOfCards_Is_Less_Than_Or_Equal_To_Zero()
    {
        var id = Guid.NewGuid();
        _repository.GetById(id).Returns(Option.Some(_testDataBuilder.BuildPlaylist()));

        var result = _controller.GenerateBingoCards(id, 0) as ObjectResult;

        result.Should().BeOfType<BadRequestObjectResult>();
        result.Value.Should().Be("You cannot generate zero or less cards");
    }

    [Test]
    public void Return_BadRequest_If_Playlist_Has_No_Songs()
    {
        var id = Guid.NewGuid();
        _repository.GetById(id).Returns(Option.Some(new Playlist(id, "Empty Playlist", [])));

        var result = _controller.GenerateBingoCards(id, 3) as ObjectResult;

        result.Should().BeOfType<BadRequestObjectResult>();
        result.Value.Should().Be("No songs found in the playlist");
    }

    [Test]
    public void Return_BadRequest_If_Playlist_Has_Less_Than_25_Songs()
    {
        var id = Guid.NewGuid();
        _repository.GetById(id).Returns(Option.Some(new Playlist(id, "Empty Playlist", [
            new Song("ABC", "Me", "1")
        ])));

        var result = _controller.GenerateBingoCards(id, 3) as ObjectResult;

        result.Should().BeOfType<BadRequestObjectResult>();
        result.Value.Should().Be("Playlist must contain at least 25 songs");
    }
}