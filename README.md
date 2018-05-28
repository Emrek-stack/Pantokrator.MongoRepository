# Pantokrator.MongoRepository

Usage:

Entity :

```cs
    // Entity 
    [CollectionName("items")]
    public class Item : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
```
    
    
    Custom Repo : 
    
    
```cs    
    // Interface Implementation
    public interface IItemRepository : IRepository<Item>
    {
    
    }
```    
    
```cs    
   // Class Implementation
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
```    
    
    
    
    
