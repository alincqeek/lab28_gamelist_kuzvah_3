using Microsoft.AspNetCore.Mvc;
using GamesApi.Models;
using GamesApi.Data;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace GamesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase {
    // GET /api/games — получить все игры
    [HttpGet]
    public ActionResult<List<Game>> GetAll() {
        return Ok(GamesStore.Games);
    }
    // GET /api/games/1 — получить одну игру по id
    [HttpGet("{id}")]
    public ActionResult<Game> GetById(int id) {
        var game = GamesStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null) {
            return NotFound(new { message = $"Игра с id={id} не найдена" });
        }
        return Ok(game);
    }
    // POST /api/games — добавить новую игру
    [HttpPost]
    public ActionResult<Game> Create([FromBody] Game game) {
        game.Id = GamesStore.NextId();
        GamesStore.Games.Add(game);
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
    }
    // DELETE /api/games/1 — удалить игру по id
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var game = GamesStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null)
        {
            return NotFound(new { message = $"Игра с id={id} не найдена" });
        }
        GamesStore.Games.Remove(game);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Game> Update(int id, [FromBody] Game updated)
    {
        var game = GamesStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null)
        {
            return NotFound(new { message = $"Игра с id={id} не найдена" });
        }
        game.Title = updated.Title;
        game.Genre = updated.Genre;
        game.ReleaseYear = updated.ReleaseYear;
        return Ok(game);
    }
    
}

