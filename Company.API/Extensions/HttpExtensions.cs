using System.Linq.Expressions;

namespace Company.API.Extensions
{
    public static class HttpExtensions 
    {
        public static async Task<IResult> HttpGetAsync<TEntity, TDto>(this IDbService db) where TEntity : class, IEntity where TDto : class => Results.Ok(await db.GetAsync<TEntity, TDto>());
        public static async Task<IResult> HttpSingleAsync<TEntity, TDto>(this IDbService db, int id) where TEntity : class, IEntity where TDto : class
        {
            var entitet = await db.SingleAsync<TEntity, TDto>(c => c.Id == id);
            if (entitet is null) return Results.NotFound();
            return Results.Ok(entitet);
        }
        public static async Task<IResult> HttpAddAsync<TEntity, TDto>(this IDbService db, TDto dto) where TEntity : class, IEntity where TDto : class
        {
            if (dto is null) return Results.BadRequest();
            try
            {
                var entity = await db.AddAsync<TEntity, TDto>(dto);
                if (await db.SaveChangesAsync())
                {
                    var node = typeof(TEntity).Name.ToLower();
                    return Results.Created($"/{node}/{entity.Id}", entity);
                }

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to add {typeof(TEntity).Name} entity. {ex}");
            }
            return Results.BadRequest($"Failed to add {typeof(TEntity).Name} entity.");
        }
        public static async Task<IResult> HttpUpdateAsync<TEntity, TDto>(this IDbService db, TDto dto, int id) where TEntity : class, IEntity where TDto : class
        {
            if (dto is null) return Results.BadRequest();
            try
            {

                if (!await db.AnyAsync<TEntity>(e => e.Id.Equals(id))) return Results.NotFound();
                db.Update<TEntity, TDto>(id, dto);
                if (await db.SaveChangesAsync()) return Results.NoContent();

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to update the {typeof(TEntity).Name} entity. {ex}.");
            }
            return Results.BadRequest($"Failed to update the {typeof(TEntity).Name} entity.");
        }
        public static async Task<IResult> HttpDeleteAsync<TEntity>(this IDbService db, int id) where TEntity : class, IEntity
        {
            try
            {
                if (!await db.DeleteAsync<TEntity>(id)) return Results.NotFound();
                if (await db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to delete the {typeof(Companies).Name} entity.{ex}.");
            }
            return Results.BadRequest($"Failed to delete the {typeof(Companies).Name} entity.");
        }
        public static async Task<IResult> HttpDeleteRefAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto) where TReferenceEntity : class, IReferenceEntity where TDto : class
        {
            try
            {
                if (!db.DeleteRef<TReferenceEntity, TDto>(dto)) return Results.NotFound();
                if (await db.SaveChangesAsync()) return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to delete the {typeof(TReferenceEntity).Name} entity.{ex}.");
            }
            return Results.BadRequest($"Failed to delete the {typeof(TReferenceEntity).Name} entity.");
        }
        public static async Task<IResult> HttpAddRefAsync<TReferenceEntity, TDto>(this IDbService db, TDto dto) where TReferenceEntity : class, IReferenceEntity where TDto : class
        {
            try
            {
                var referenceEntity = await db.AddRefAsync<TReferenceEntity, TDto>(dto);
                if (await db.SaveChangesAsync())
                {
                    var node = typeof(TReferenceEntity).Name.ToLower();
                    return Results.Created($"/{node}/{dto}", referenceEntity); //Varför retunerar man entiteten och inte dto? Behöver UI verkligen allt?
                }

            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Failed to add {typeof(TReferenceEntity).Name} entity. {ex}");

            }
            return Results.BadRequest($"Failed to add {typeof(TReferenceEntity).Name} entity.");
        }
    }
}
