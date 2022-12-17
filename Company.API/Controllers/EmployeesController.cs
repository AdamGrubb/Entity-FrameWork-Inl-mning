using Company.API.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IDbService _db;
        public EmployeesController(IDbService db) => _db = db;


        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<Employees, EmployeesDTO>();

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => await _db.HttpSingleAsync<Employees, EmployeesDTO>(id);

        [HttpPost]
        public async Task<IResult> Post([FromBody] EmployeesDTO dto) => await _db.HttpAddAsync<Employees, EmployeesDTO>(dto);

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] EmployeesDTO dto) => await _db.HttpUpdateAsync<Employees, EmployeesDTO>(dto, id);

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id) => await _db.HttpDeleteAsync<Employees>(id);
    }
}
