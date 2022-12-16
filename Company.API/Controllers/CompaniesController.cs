using Company.API.Extensions;
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


        [HttpGet]
        //public async Task<IResult> Get() =>Results.Ok(await _db.GetAsync<Companies, CompaniesDTO>()); Utan extension-method.
        public async Task<IResult> Get() =>await _db.HttpGetAsync<Companies, CompaniesDTO>();

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id) => await _db.HttpSingleAsync<Companies, CompaniesDTO>(id);

        [HttpPost]
        public async Task<IResult> Post([FromBody] CompaniesDTO dto) => await _db.HttpAddAsync<Companies, CompaniesDTO>(dto);

        [HttpPut("{id}")]
        public async Task<IResult> Put(int id, [FromBody] CompaniesDTO dto) => await _db.HttpUpdateAsync<Companies, CompaniesDTO>(dto, id);

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(int id)=> await _db.HttpDeleteAsync<Companies>(id);
    }
}
 