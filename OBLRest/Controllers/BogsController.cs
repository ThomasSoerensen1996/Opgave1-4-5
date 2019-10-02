using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBLBog;

namespace OBLRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BogsController : ControllerBase
    {
        private static List<Bog> bogListe = new List<Bog>()
        {
            new Bog("C# Advanced", "Anders", 100, "1111111111111"),
            new Bog("Network and Unicorns", "Peter", 200, "2222222222222"),
            new Bog("Rest Service for elderly", "Iben", 300, "3333333333333"),
            new Bog("Do you know your computer?", "Louise", 400, "4444444444444"),
            new Bog("Best Friends", "Frank", 500, "5555555555555")
        };


        // GET: api/Bogs
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return bogListe;
        }

        // GET: api/Bogs/5
        [HttpGet("{IDIsbn13}", Name = "Get")]
        public Bog Get(string IDisbn13)
        {
            return bogListe.Find(c => c.Isbn13 == IDisbn13);
        }

        // POST: api/Bogs
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            bogListe.Add(value);
        }

        // PUT: api/Bogs/5
        [HttpPut("{IDIsbn13}")]
        public void Put(string IDisbn13, [FromBody] Bog value)
        {
            Bog bog = Get(IDisbn13);

            if (bog != null)
            {
                bog.Titel = value.Titel;
                bog.Forfatteer = value.Forfatteer;
                bog.Sidetal = value.Sidetal;
                bog.Isbn13 = value.Isbn13;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{IDIsbn13}")]
        public void Delete(string IDisbn13)
        {
            Bog bog = Get(IDisbn13);
            if (bog != null)
            {
                bogListe.Remove(bog);
            }
        }
    }
}
