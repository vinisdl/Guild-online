using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Linq;
using System.Web;

namespace Guild_online
{
    public static class GetGuild
    {
        [FunctionName("GetGuild")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {            
            string name = req.Query["guild"];


            using var client = new HttpClient();

            client.BaseAddress = new Uri($"https://api.tibiadata.com/v4/guild/{HttpUtility.UrlPathEncode(name)}");

            var guild = await client.GetFromJsonAsync<TibiaData>(client.BaseAddress);

            var online = guild.Guild.members.Where(x => x.status.Equals("online")).OrderByDescending(x => x.level);


            return new OkObjectResult(new
            {
                Kinight = online.Where(x=> x.vocation.Contains("Knight")),
                Sorcerer = online.Where(x => x.vocation.Contains("Sorcerer")),
                Druid = online.Where(x => x.vocation.Contains("Druid")),
                Paladin = online.Where(x => x.vocation.Contains("Paladin"))
            });
        }
    }
}
