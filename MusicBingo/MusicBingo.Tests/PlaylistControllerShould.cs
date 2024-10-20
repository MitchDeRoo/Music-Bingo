using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MusicBingo.Domain;
using MusicBingo.Playlists;
using NSubstitute;
using Optional;

namespace MusicBingo.Tests;

[TestFixture]
public class PlaylistControllerShould
{
    private IPlaylistRepository _repository;
    private PlaylistController _controller;

    [SetUp]
    public void Setup()
    {
        _repository = Substitute.For<IPlaylistRepository>();
        _controller = new PlaylistController(_repository);
    }

    [Test]
    public void Create_New_Playlist()
    {
        var playlist = new Playlist(Guid.NewGuid(), "Hit That 80s", []);
        _repository.Create("Hit That 80s").Returns(playlist);

        var result = _controller.CreatePlaylist("Hit That 80s") as ObjectResult;

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().Be(playlist);
    }

    [Test]
    public void Return_Playlist_When_Using_Id_If_It_Exists()
    {
        var playlist = new Playlist(Guid.NewGuid(), "Hit That 80s", []);

        _repository.GetById(playlist.Guid).Returns(Option.Some(playlist));

        var result = _controller.GetById(playlist.Guid) as ObjectResult;

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().Be(playlist);
    }

    [Test]
    public void Return_BadRequest_When_Using_Id_And_Playlist_Doesnt_Exist()
    {
        var id = Guid.NewGuid();
        _repository.GetById(id).Returns(Option.None<Playlist>());

        var result = _controller.GetById(id) as ObjectResult;

        result.Should().NotBeNull();
        result.Should().BeOfType<NotFoundObjectResult>();
        result.Value.Should().Be($"No playlist found with id {id}");
    }

    [Test]
    public void Return_All_Playlists()
    {
        List<Playlist> playlists =
        [
            new Playlist(Guid.NewGuid(), "", []),
            new Playlist(Guid.NewGuid(), "", []),
            new Playlist(Guid.NewGuid(), "", [])
        ];
        _repository.GetAll().Returns(playlists);

        var result = _controller.GetAll() as ObjectResult;

        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().Be(playlists);
    }
}