using System;
using DbServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DbServer.Controllers
{
    [ApiController]
    public class DbController : Controller
    {
        [HttpGet]
        [Route("GetMonsterData")]
        public string Index([FromServices] IDataGetter dataGetter)
        {
            var result = dataGetter.GetData();
            return result;
        }
    }
}