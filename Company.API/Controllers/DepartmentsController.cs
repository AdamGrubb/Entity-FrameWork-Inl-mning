using Company.API.Extensions;
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
        public async Task<IResult> Get() => await _db.HttpGetAsync<Departments, DepartmentsDTO>();

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => await _db.HttpSingleAsync<Departments, DepartmentsDTO>(id);

        [HttpPost]
        public async Task<IResult> Post([FromBody] DepartmentsDTO dto) => await _db.HttpAddAsync<Departments, DepartmentsDTO>(dto);

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] DepartmentsDTO dto) => await _db.HttpUpdateAsync<Departments, DepartmentsDTO>(dto, id);

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id) => await _db.HttpDeleteAsync<Departments>(id);
    }
}
