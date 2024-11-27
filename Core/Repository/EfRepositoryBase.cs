using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Repository;

public abstract class EfRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId> // The base repository class for Entity Framework 
     where TEntity : Entity<TId>, new() // The Type TEntity has to inherit from the base class of 'Entity'
     where TContext : DbContext // The Context for the Repository has to inherit from the base class of 'DbContext' 
{
    protected TContext Context { get; }
    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        entity.CreationTime = DateTime.Now; // the Creation time for each entity is set before initiating the entity to the database
        Context.Set<TEntity>().Add(entity); // The Set<Entity>() portion enables the use of the generic parameters by changing the data base table depending on the repository class 
        Context.SaveChanges(); // The changes to the database are saved so that they are retained

        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateTime = DateTime.Now; // The Update time for each entity is set before introducing the changed object to the database
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();

        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();

        return entity;
    }

    public TEntity? GetById(TId id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null) 
    {
        IQueryable<TEntity> query = Context.Set<TEntity>(); // The variable 'query' is basically an SQL query made to the database that retrieves every object of the type TEntity
        if(filter is not null) 
        {
            query = query.Where(filter); // If a filter is provided as a parameter, the filter is added to the query, narrowing down the results
        }
        return query.ToList(); // The ToList() function causes the query to be carried out.
        // Without it, or other similar functions, the query is sent to the database but there is no retrieval of information
    }
}
