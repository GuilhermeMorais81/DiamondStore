using System.Reflection.Metadata.Ecma335;
using DiamondStore.Models;
using Microsoft.VisualBasic;

namespace DiamondStore.Validators;

public class GameValidator
{
    public static Result IsValidTitle(string title)
    {
        if(string.IsNullOrWhiteSpace(title)) 
            return Result.Failure("title can not be empty");
        return title.Length >= 3 && title.Length <= 160 ?
            Result.Success() : Result.Failure("invalid title length");
    }

    public static Result IsValidReleaseDate(DateTime date)
    {
        if(date < DateTime.Now && date.Year > 1900) {
            return Result.Success();
        }
        else   
            return Result.Failure("Release Date has an invalid period"); 
    }

    public static Result IsValidGame(Game game)
    {
        if(game is null) return Result.Failure("game can not be null");
        var validators = new Func<Result>[]
        {
            () => IsValidTitle(game.Title),
            () => IsValidReleaseDate(game.ReleaseDate)
        };

        foreach(var validator in validators)
        {
            var result = validator();
            if(result.IsFailure) return result;
        }
        return Result.Success();
    }
}