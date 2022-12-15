using Company.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IDbService _db;
        public CompaniesController(IDbService db) => _db = db;

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IResult> Get()
        {

            return Results.Ok(await _db.GetAsync<Companies, CompaniesDTO>()); //Här får du ändra i routen så att du tar in nått annat än companys
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var entitet = await _db.SingleAsync<Companies, CompaniesDTO>(c => c.Id == id); //Här kan du göra en if.sats. Ifall den returnerar null så kan du göra en bad request.
            return Results.Ok(entitet); //Här får du också ändra
        }

        // POST api/<CompanyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
