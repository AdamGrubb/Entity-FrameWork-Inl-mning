using Company.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

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
        public async Task<IResult> Post([FromBody] CompaniesDTO dto)
        {
            try
            {
                var entity = await _db.AddAsync<Companies, CompaniesDTO>(dto);
                if (await _db.SaveChangesAsync()) 
                {
                    var node = typeof(Companies).Name.ToLower();
                    return Results.Created($"/{node}s/{entity.Id}", entity);
                }
                
            }
            catch (Exception ex) 
            {
                return Results.BadRequest($"Failed to add {typeof(Companies).Name} entity. {ex}");

            }
            return Results.BadRequest($"Failed to add {typeof(Companies).Name} entity."); //Varför???
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] CompaniesDTO dto) //Här är jag
        {
            try
            {

                if (!await _db.AnyAsync<Companies>(e => e.Id.Equals(id))) return Results.NotFound();
                _db.Update<Companies, CompaniesDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to update the {typeof(Companies).Name} entity. {ex}.");
            }
            return Results.BadRequest($"Failed to update the {typeof(Companies).Name} entity.");
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (!await _db.DeleteAsync<Companies>(id)) return Results.NotFound();
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to delete the {typeof(Companies).Name} entity.{ex}.");
            }
            return Results.BadRequest($"Failed to delete the {typeof(Companies).Name} entity.");
        }
    }
}
