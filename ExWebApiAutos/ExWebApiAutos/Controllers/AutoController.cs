using System;
using System.Linq;
using System.Threading.Tasks;
using ExWebApiAutos.Model;
using ExWebApiAutos.Model.ExWebApiAutos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExWebApiAutos.Controllers
{
    [Route("api/[controller]")]
    public class AutoController : Controller
    {
        private IAutoRepository repositorio;
        public AutoController(IAutoRepository repo)
        {
            repositorio = repo;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TAuto> Get()
        {
            return repositorio.Autos;
        }
        // GET api/<controller>/5
        [HttpGet("{AutoId}")]
        
        public TAuto Get(Guid AutoId)
        {
            return repositorio.Autos.Where(p => p.AutoId == AutoId).FirstOrDefault();
        }
        // POST api/<controller>
        [HttpPost]
        public async Task <IActionResult> Post([FromBody]TAuto auto)
        {
            await repositorio.SaveProject(auto);
            return Ok(true);
        }
        // PUT api/<controller>/5
        [HttpPut("{AutoId}")]
        public async Task <IActionResult> Put(Guid AutoId, [FromBody]TAuto auto)
        {
            auto.AutoId = AutoId;
            await repositorio.SaveProject(auto);
            return Ok(true);
        }
        // DELETE api/<controller>/5
        [HttpDelete("{AutoId}")]
        public IActionResult Delete(Guid AutoId)
        {
            repositorio.DeleteProyecto(AutoId);
            return Ok(true);
        }
    }
}
