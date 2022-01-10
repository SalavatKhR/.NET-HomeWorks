using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UiServer.Models;

namespace UiServer.Controllers
{
    public class DnDController : Controller
    {
        static readonly HttpClient _client = new HttpClient();
        [HttpGet]
        public IActionResult CreateHero()
        {
            return View(new Hero());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateHero([FromForm] Hero hero)
        {
            HttpResponseMessage dbResponse = await _client.GetAsync("https://localhost:5001/GetMonsterData");
            dbResponse.EnsureSuccessStatusCode();
            string jsonMonster = await dbResponse.Content.ReadAsStringAsync(); //json-monster
            var jsonHero = JsonConvert.SerializeObject(hero); //json-hero
            HttpResponseMessage BusinessRespones = await _client.GetAsync($"https://localhost:44351/GetData?jsonMonsters={jsonMonster}&jsonHero={jsonHero}");
            BusinessRespones.EnsureSuccessStatusCode();
            string result = await BusinessRespones.Content.ReadAsStringAsync();
            return Content(result);
        }
    }
}