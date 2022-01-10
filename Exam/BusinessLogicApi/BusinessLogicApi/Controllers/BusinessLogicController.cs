using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Implementation;
using Newtonsoft.Json.Linq;

namespace BusinessLogicApi.Controllers
{
    public class BusinessLogicController : Controller
    {
        [HttpGet]
        [Route("GetData")]
        public string GetData(string jsonMonsters, string jsonHero)
        {
            dynamic dMonster = JObject.Parse(jsonMonsters);
            dynamic dHero = JObject.Parse(jsonHero);
            
            string result = dMonster.MonsterName + "----" + dHero.HeroName;
            return result;
        }
    }
}