using Core.Entities;
using System.Linq.Expressions;

namespace Core.Repository;

// The Generic entity of TEntity has to be a child class of The 'Entity' base class,
// and it cannot be an abstract class/interface
public interface IRepository <TEntity, TId> where TEntity: Entity<TId>, new() 
{

    // Summary: 
    //      Initiates the provided entity into the database
    //
    // Parameters:
    //   entity:
    //      An entity of type TEntity
    //
    // Returns:
    //      The initiated entity
    //
    // Throws:
    //      BusinessException
    TEntity Add(TEntity entity);


    // Summary:
    //      Updates the provided Entity in the database 
    //
    // Parameters:
    //   entity:
    //      The Updated version of the Entity of type TEntity
    //
    // Returns:
    //      The Updated version of the Entity
    //
    // Throws:
    //      BusinessException
    //      NotFoundException
    TEntity Update(TEntity entity);


    // Summary:
    //      Deletes the provided entity from the Database
    //
    // Parameters:
    //   entity:
    //      The entity to be deleted
    //
    // Returns:
    //      The deleted entity
    //
    // Throws:
    //      NotFoundException
    TEntity Delete(TEntity entity);


    // Summary:
    //      Retrieves the object in the database with the provided Id
    //
    // Parameters:
    //   id:
    //      An Id of type TId
    //
    // Returns:
    //      An object of type TEntity with the id of 'id'
    //
    // Throws:
    //      NotFoundException
    TEntity? GetById(TId id);


    // Summary:
    //      Retrieves all the objects in the database that fit the lambda
    //      expression in the parameter
    //
    // Parameters:
    //   filter:
    //      A Lambda Expression with a return of bool. Or no parameters
    // 
    // Returns:
    //      A List of objects of type TEntity
    //
    // Remarks:
    //      If no lambda expression is provided, the function will return the list of
    //      all entites of type TEntity 

    List<TEntity> GetAll(Expression<Func<TEntity,bool>>? filter = null);
    
}
