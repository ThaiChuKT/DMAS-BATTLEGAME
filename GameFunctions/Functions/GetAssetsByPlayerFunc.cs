// src/GameFunctions/Functions/GetAssetsByPlayerFunction.cs (replace content)
using System.Linq;
using System.Threading.Tasks;
using GameFunctions.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace GameFunctions.Functions
{
    public class GetAssetsByPlayerFunction
    {
        private readonly GameDbContext _db;
        public GetAssetsByPlayerFunction(GameDbContext db) => _db = db;

        [FunctionName("getassetsbyplayer")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getassetsbyplayer")] HttpRequest req,
            ILogger log)
        {
            var list = await _db.PlayerAssets
                .Include(pa => pa.Player)
                .Include(pa => pa.Asset)
                .ToListAsync();

            var result = list.Select((pa, idx) => new {
                No = idx + 1,
                PlayerName = pa.Player!.PlayerName,
                Level = pa.Player.CurrentLevel,
                Age = pa.Player.Age,
                AssetName = pa.Asset!.AssetName
            });

            return new OkObjectResult(result);
        }
    }
}
