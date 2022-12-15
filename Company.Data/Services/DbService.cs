using Company.Data.Interfaces;
using Company.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Company.Data.Services;

public class DbService : IDbService
{
    private readonly CompanyContext _db;
    private readonly IMapper _mapper;
    public DbService(CompanyContext db, IMapper mapper) => (_db, _mapper) = (db, mapper);

    public async Task<List<TDto>> GetAsync<TEntity, TDto>() where TEntity: class, IEntity where TDto : class
    {

        var entities = await _db.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    private async Task<TEntity?> SingleAsync<TEntity>(Expression<Func<TEntity,bool>> expression) where TEntity : class, IEntity =>
    await _db.Set<TEntity>().SingleOrDefaultAsync(expression);

    public async Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity where TDto : class
    {
        var entity = await SingleAsync(expression);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
    {
        return await _db.Set<TEntity>().AnyAsync(expression);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await _db.SaveChangesAsync() >= 0;
    }
}
