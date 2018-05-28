# Pantokrator.MongoRepository

Usage:

Entity :

```cs
   [CollectionName("items")]
    public class Item : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
```
    
    
    Custom Repo : 
    
    Interface Implementation
```cs    
    public interface IItemRepository : IRepository<Item>
    {
    
    }
```    
    Class Implementation

```cs    
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
```    
    
    
    
    
