using MusicBingo.BingoCards;
using MusicBingo.Playlists;
using MusicBingo.Writers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IPlaylistRepository, TestingPlaylistRepository>();
builder.Services.AddSingleton<IBingoCardGenerator, BingoCardGenerator>();
builder.Services.AddSingleton<IBingoDocumentWriter, BingoDocumentWriter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();