namespace DiamondStore.Models;

public class Game
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required DateTime ReleaseDate { get; set; }
}