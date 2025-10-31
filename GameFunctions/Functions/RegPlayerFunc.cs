// src/GameFunctions/Functions/RegisterPlayerFunction.cs
using System.IO;
using System.Threading.Tasks;
using GameFunctions.Data;
using GameFunctions.DTO;
using GameFunctions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace GameFunctions.Functions
{
    public class RegisterPlayerFunction
    {
        private readonly GameDbContext _db;
        public RegisterPlayerFunction(GameDbContext db) => _db = db;

        [FunctionName("registerplayer")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "registerplayer")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var dto = JsonSerializer.Deserialize<RegPlayerDto>(body, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
            if (dto == null) return new BadRequestObjectResult("Invalid payload.");

            var player = new Player
            {
                PlayerName = dto.PlayerName,
                FullName = dto.FullName,
                Age = dto.Age,
                CurrentLevel = dto.CurrentLevel
            };

            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return new OkObjectResult(new { Message = "Player registered", PlayerId = player.Id });
        }
    }
}
