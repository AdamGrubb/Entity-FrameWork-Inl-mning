using Company.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesJobTitlesController : ControllerBase
    {

        private readonly IDbService _db;
        public EmployeesJobTitlesController(IDbService db) => _db = db;

        [HttpPost]
        public async Task<IResult> Post([FromBody] EmployeesJobTitlesDTO dto)
        {
            try
            {
                //var entity = await _db.AddAsync<Companies, CompaniesDTO>(dto);
                var referenceEntity = await _db.AddRefAsync<EmployeesJobTitles, EmployeesJobTitlesDTO>(dto);
                if (await _db.SaveChangesAsync())
                {
                    var node = typeof(EmployeesJobTitles).Name.ToLower();
                    return Results.Created($"/{node}s/{referenceEntity.JobTitleId}, {referenceEntity.EmployeeId}", referenceEntity); //Fråga jonas om den ska se ut såhär??
                }

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to add {typeof(EmployeesJobTitles).Name} entity. {ex}");

            }
            return Results.BadRequest($"Failed to add {typeof(EmployeesJobTitles).Name} entity.");
        }
    }
}
