using System;
using System.Linq;
using DbServer.Data;
using Newtonsoft.Json;

namespace DbServer.Services
{
    public class DataGetter:IDataGetter
    {
        private static MonstersContext _context;

        public DataGetter(MonstersContext context)
        {
            _context = context;
        }

        public  IQueryable<Monsters> Monsters => _context.MonstersData;
        public string GetData()
        {
            var maxId = Monsters.Max(m => m.Id);
            var rndId = new Random().Next(1, maxId+1);
            var data = Monsters.Where(m => m.Id == rndId);
            var result = JsonConvert.SerializeObject(data.First());
            return result;
        }
    }
}