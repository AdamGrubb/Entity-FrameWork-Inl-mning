using Company.API.Extensions;
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
        public async Task<IResult> Post([FromBody] EmployeesJobTitlesDTO dto) => await _db.HttpAddRefAsync<EmployeesJobTitles, EmployeesJobTitlesDTO>(dto);

        [HttpDelete]
        public async Task<IResult> Delete([FromBody] EmployeesJobTitlesDTO dto) => await _db.HttpDeleteRefAsync<EmployeesJobTitles, EmployeesJobTitlesDTO>(dto);
    }
}
