using Company.Data.Interfaces;
using Company.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Company.Data.Services;

public class DbService : IDbService
{
    private readonly CompanyContext _db;
    private readonly IMapper _mapper;
    public DbService(CompanyContext db, IMapper mapper) => (_db, _mapper) = (db, mapper);
}
