using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Interfaces;

public interface IDbService
{
    Task<List<TDto>> GetAsync<TEntity, TDto>() where TEntity: class, IEntity where TDto : class;
}
