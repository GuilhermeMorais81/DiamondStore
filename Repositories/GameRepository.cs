using DiamondStore.Data;
using DiamondStore.Models;
using DiamondStore.Validators;
using Microsoft.EntityFrameworkCore;

namespace DiamondStore.Repositories;

public class GameRepository
{
    private DataContext _context;

    public GameRepository(DataContext context)
    {
        _context = context;
    }

    public Result<Game> Add(Game game)
    {
        _context.Games.Add(game);
        _context.SaveChanges();
        return Result<Game>.Success(game);
    }
    public List<Game> NoTrackedList()
        => _context.Games.AsNoTracking().ToList();
    

    public Result<Game> FindById(Guid id)
    {
        var game = _context.Games.FirstOrDefault(x => x.Id == id);
        return game is null ? 
            Result<Game>.Failure("game not found") : Result<Game>.Success(game);
    }

    public Result Delete(Guid id)
    {
        var rowsAffected = _context.Games
            .Where(x => x.Id == id)
            .ExecuteDelete();
        return rowsAffected == 0 ?
            Result.Failure("game not found") : Result.Success();
    }

    public Result Update(Game game)
    {
        var rowsAffected = _context.Games
            .Where(x => x.Id == game.Id)
            .ExecuteUpdate(x => x
                .SetProperty(x => x.Title, game.Title)
                .SetProperty(x => x.ReleaseDate, game.ReleaseDate)
            );
        return rowsAffected == 0 ?
            Result.Failure("game not found") : Result.Success();
    }
}