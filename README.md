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
    public interface IItemRepository : IRepository<Item>
    {
    
    }
    
    Class Implementation
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
    
    
    
    
