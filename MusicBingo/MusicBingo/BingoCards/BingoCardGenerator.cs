using MusicBingo.Domain;

namespace MusicBingo.BingoCards;

public class BingoCardGenerator
{
    public List<BingoCard> Generate(Playlist playlist, int numberOfCards)
    {
        var bingoCards = new List<BingoCard>();

        for (var i = 0; i < numberOfCards; i++)
        {
            var card = new BingoCard
            {
                Title = playlist.Name,
                Cells = new string[6][]
            };

            // Fill first row with BINGO letters
            card.Cells[0] = ["B", "I", "N", "G", "O"];

            // Fill rest with songs
            for (var row = 1; row < 6; row++)
            {
                card.Cells[row] = new string[5];

                for (var col = 0; col < 5; col++)
                {
                    // Set middle square to be empty space
                    if (row == 3 && col == 2)
                    {
                        card.Cells[row][col] = "Free Space";
                    }
                    else
                    {
                        // TODO: Change to be less random
                        card.Cells[row][col] = playlist.GetRandomSong().Name;
                    }
                }
            }

            bingoCards.Add(card);
        }

        return bingoCards;
    }
}