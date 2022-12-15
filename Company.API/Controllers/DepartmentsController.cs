using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDbService _db;
        public DepartmentsController(IDbService db) => _db = db;

        [HttpGet]
        public async Task<IResult> Get()
        {

            return Results.Ok(await _db.GetAsync<Departments, DepartmentsDTO>());
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            var entitet = await _db.SingleAsync<Departments, DepartmentsDTO>(c => c.Id == id);
            return Results.Ok(entitet);
        }
        [HttpPost]
        public async Task<IResult> Post([FromBody] DepartmentsDTO dto)
        {
            try
            {
                var entity = await _db.AddAsync<Departments, DepartmentsDTO>(dto);
                if (await _db.SaveChangesAsync())
                {
                    var node = typeof(Departments).Name.ToLower();
                    return Results.Created($"/{node}s/{entity.Id}", entity);
                }

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to add {typeof(Departments).Name} entity. {ex}");

            }
            return Results.BadRequest($"Failed to add {typeof(Departments).Name} entity.");
        }
        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DepartmentsDTO dto)
        {
            try
            {

                if (!await _db.AnyAsync<Departments>(e => e.Id.Equals(id))) return Results.NotFound();
                _db.Update<Departments, DepartmentsDTO>(id, dto);
                if (await _db.SaveChangesAsync()) return Results.NoContent();

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to update the {typeof(Departments).Name} entity. {ex}.");
            }
            return Results.BadRequest($"Failed to update the {typeof(Departments).Name} entity.");
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)
        {
            try
            {
                if (!await _db.DeleteAsync<Departments>(id)) return Results.NotFound();
                if (await _db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to delete the {typeof(Departments).Name} entity.{ex}.");
            }
            return Results.BadRequest($"Failed to delete the {typeof(Departments).Name} entity.");
        }
    }
}
