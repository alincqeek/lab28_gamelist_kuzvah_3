using System.Data.Common;
using GamesApi.Models;
namespace GamesApi.Data;

public static class GamesStore
{
    // Счётчик для генерации уникальных Id
    private static int _nextId = 4;
    // Список игр — начальные данные
    public static List<Game> Games { get; } = new() {
        new Game {
            Id = 1,
            Title = "Hollow Knight",
            Genre = "Metroidvania",
            ReleaseYear = 2017
        },
        new Game {
            Id = 2,
            Title = "Hades",
            Genre = "Roguelike",
            ReleaseYear = 2020
        },
        new Game {
            Id = 3,
            Title = "Celeste",
            Genre = "Platformer",
            ReleaseYear = 2018
        }
    };
    // Метод для получения следующего Id
    public static int NextId() => _nextId++;
}
