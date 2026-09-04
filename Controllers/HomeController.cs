using DiamondStore.Data;
using DiamondStore.Models;
using DiamondStore.Repositories;
using DiamondStore.Validators;
using Microsoft.AspNetCore.Mvc;

namespace DiamondStore.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    private readonly DataContext _context;
    private readonly GameRepository _repository;

    public HomeController(DataContext context)
    {
        _context = context;
        _repository = new GameRepository(_context);
    }

    [HttpGet]
    [Route("/")]
    public IActionResult Get()
        => Ok("App is working!");

    [HttpGet]
    [Route("/games/get-all")]
    public IActionResult GetGames()
        => Ok(_repository.NoTrackedList());
    

    [HttpPost]
    [Route("/games/")]
    public IActionResult Post([FromBody] Game game)
    {
        var validation = GameValidator.IsValidGame(game);
        if(validation.IsFailure) return BadRequest(validation.ErrorMsg);
        var addRes = _repository.Add(game);
        return CreatedAtAction(nameof(GetGame), new {Id = addRes.Value.Id}, addRes.Value);
    }

    [HttpGet]
    [Route("/games/{id:Guid}")]
    public IActionResult GetGame([FromRoute] Guid id) 
    {
        var result = _repository.FindById(id);
        if(result.IsFailure) 
            return NotFound(new { Message = result.ErrorMsg });
        else return Ok(result.Value);
    }

    [HttpDelete]
    [Route("/games/{id:Guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var deleteRes = _repository.Delete(id);
        if(deleteRes.IsFailure)
            return NotFound(new { Message = deleteRes.ErrorMsg });
        else return NoContent();
    }

    [HttpPut]
    [Route("/games/{id:Guid}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] Game game)
    {
        if(id != game.Id) 
            return BadRequest(new { Message = "route and body Id must match" });
        var validation = GameValidator.IsValidGame(game);
        if(validation.IsFailure) return BadRequest(validation.ErrorMsg);
        var updateRes = _repository.Update(game);
        if(updateRes.IsFailure)
            return NotFound(new { Message = updateRes.ErrorMsg });
        else return NoContent();
    }
}