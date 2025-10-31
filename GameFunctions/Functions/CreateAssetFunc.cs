// src/GameFunctions/Functions/CreateAssetFunction.cs
using System.IO;
using System.Threading.Tasks;
using GameFunctions.Data;
using GameFunctions.DTO;
using GameFunctions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace GameFunctions.Functions
{
    public class CreateAssetFunction
    {
        private readonly GameDbContext _db;
        public CreateAssetFunction(GameDbContext db) => _db = db;

        [FunctionName("createasset")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "createasset")] HttpRequest req,
            ILogger log)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var dto = JsonSerializer.Deserialize<CreateAssetDTO>(body, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});
            if (dto == null) return new BadRequestObjectResult("Invalid payload.");

            var asset = new Asset
            {
                AssetName = dto.AssetName,
                Description = dto.Description
            };

            _db.Assets.Add(asset);
            await _db.SaveChangesAsync();
            return new OkObjectResult(new { Message = "Asset created", AssetId = asset.Id });
        }
    }
}
