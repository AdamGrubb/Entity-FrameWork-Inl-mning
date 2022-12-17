using Company.API.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitlesController : ControllerBase
    {
        private readonly IDbService _db;
        public JobTitlesController(IDbService db) => _db = db;


        [HttpGet]
        public async Task<IResult> Get() => await _db.HttpGetAsync<JobTitles, JobTitlesDTO>();

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => await _db.HttpSingleAsync<JobTitles, JobTitlesDTO>(id);

        [HttpPost]
        public async Task<IResult> Post([FromBody] JobTitlesDTO dto) => await _db.HttpAddAsync<JobTitles, JobTitlesDTO>(dto);

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] JobTitlesDTO dto) => await _db.HttpUpdateAsync<JobTitles, JobTitlesDTO>(dto, id);

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id) => await _db.HttpDeleteAsync<JobTitles>(id);
    }
}
